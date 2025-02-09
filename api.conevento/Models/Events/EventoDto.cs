﻿using biz.conevento.Entities;
using System;
using System.Collections.Generic;

namespace api.conevento.Models.Events
{
    public class EventoDto
    {
        public EventoDto()
        {

        }

        public int Id { get; set; }
        public string NombreContratane { get; set; }
        public string NombreEvento { get; set; }
        public DateTime? FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }
        public int? FormaPago { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int? IdUsuario { get; set; }
        public int IdCatMunicipio { get; set; }
        public int GenteEsperada { get; set; }
        public string CalleNumero { get; set; }
        public string Cp { get; set; }
        public string Colonia { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string DetallesEvento { get; set; }
        public DateTime? FechaPago { get; set; }
        public string ReferenciaPago { get; set; }
        public bool? Pagado { get; set; }
        public string ClaveSeguimientoCarrito { get; set; }

        public virtual ICollection<ListaProductosEventoDto> ListaProductosEventos { get; set; }

    }
}
