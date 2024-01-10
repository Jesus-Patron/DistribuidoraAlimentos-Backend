﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DistribuidoraAlimentos.DTO;

namespace DistribuidoraAlimentos.BLL.Servicios.Contratos
{
    public interface IProductoService
    {
        Task<List<ProductosDTO>> Lista();
        Task<ProductosDTO> Crear(ProductosDTO modelo);
        Task<bool> Editar(ProductosDTO modelo);
        Task<bool> Eliminar(int id);
    }
}