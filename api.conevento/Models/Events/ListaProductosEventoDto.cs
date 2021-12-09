﻿using biz.conevento.Entities;
using System;
using System.Collections.Generic;

namespace api.conevento.Models.Events
{
    public class ListaProductosEventoDto
    {
        public ListaProductosEventoDto()
        {

        }

        public int Id { get; set; }
        public int IdEvento { get; set; }
        public int IdCatProducto { get; set; }
        public int CantidadSolicitada { get; set; }
        public int UnidadesIncluidas { get; set; }

    }
}
