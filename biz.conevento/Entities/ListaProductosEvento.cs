﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace biz.conevento.Entities
{
    public partial class ListaProductosEvento
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public int IdCatProducto { get; set; }
        public int CantidadSolicitada { get; set; }
        public int UnidadesIncluidas { get; set; }

        public virtual CatProductosServicio IdCatProductoNavigation { get; set; }
        public virtual Evento IdEventoNavigation { get; set; }
    }
}