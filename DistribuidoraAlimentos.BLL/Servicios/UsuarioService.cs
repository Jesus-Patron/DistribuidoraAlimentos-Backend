using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using AutoMapper;
using DistribuidoraAlimentos.BLL.Servicios.Contratos;
using DistribuidoraAlimentos.DAL.Repositorios.Contratos;
using DistribuidoraAlimentos.DTO;
using DistribuidoraAlimentos.Model;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraAlimentos.BLL.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuarios> _usuariosRepositorio;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericRepository<Usuarios> usuariosRepositorio, IMapper mapper)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _mapper = mapper;
        }

        public async Task<List<UsuariosDTO>> Lista()
        {
            try
            {
                var queryUsuario = await _usuariosRepositorio.Consultar();
                var listaUsuarios = queryUsuario.Include(Roles => Roles.IdRolNavigation).ToList();

                return _mapper.Map<List<UsuariosDTO>>(listaUsuarios);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SesionDTO> ValidarCredenciales(string correo, int contrasena)
        {
            try
            {
                var queryUsuario = await _usuariosRepositorio.Consultar(u =>
                u.Correo == correo &&
                u.Contrasena == contrasena
                );

                if (queryUsuario.FirstOrDefault() == null)
                    throw new TaskCanceledException("El usuario no existe");

                Usuarios devolverUsuarios = queryUsuario.Include(rol => rol.IdRolNavigation).First();

                return _mapper.Map<SesionDTO>(devolverUsuarios);
            }
            catch
            {
                throw;
            }
        }

        public async Task<UsuariosDTO> Crear(UsuariosDTO modelo)
        {
            try
            {
                var usuarioCreado = await _usuariosRepositorio.Crear(_mapper.Map<Usuarios>(modelo));

                if (usuarioCreado.Id == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _usuariosRepositorio.Consultar(u => u.Id == usuarioCreado.Id);

                usuarioCreado = query.Include(rol => rol.IdRolNavigation).First();

                return _mapper.Map<UsuariosDTO>(usuarioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(UsuariosDTO modelo)
        {
            try
            {
                var usuarioModelo = _mapper.Map<Usuarios>(modelo);

                var usuarioEncontrado = await _usuariosRepositorio.Obtener(u => u.Id == usuarioModelo.Id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                usuarioEncontrado.Nombre = usuarioModelo.Nombre;

                //Validacion del correo, si no tiene las terminaciones @outlook.com, @hotmail.com y @gmail.com marcara error
                if (!Regex.IsMatch(usuarioModelo.Correo, @"@(outlook\.com|hotmail\.com|gmail\.com)$"))
                    throw new TaskCanceledException("Correo electrónico inválido");
                usuarioEncontrado.Correo = usuarioModelo.Correo;

                //Validacion de la contraseña, si la longitud de la contraseña es menor a 3 caracteres marcara error
                if (usuarioModelo.Contrasena.ToString().Length < 3)
                    throw new TaskCanceledException("Longitud de contraseña inválida");
                usuarioEncontrado.Contrasena = usuarioModelo.Contrasena;

                //Validacion del telefono, la longitud del telefono tiene que ser de 9 caracteres exactos, de lo contrario marcara error
                if (usuarioModelo.Telefono.ToString().Length != 9)
                    throw new TaskCanceledException("Longitud de teléfono inválida");
                usuarioEncontrado.Telefono = usuarioModelo.Telefono;

                usuarioEncontrado.IdRol = usuarioModelo.IdRol;
                usuarioEncontrado.Estatus = usuarioModelo.Estatus;

                bool respuesta = await _usuariosRepositorio.Editar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var usuarioEncontrado = await _usuariosRepositorio.Obtener(u => u.Id == id);

                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool respuesta = await _usuariosRepositorio.Eliminar(usuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }
    }
}
