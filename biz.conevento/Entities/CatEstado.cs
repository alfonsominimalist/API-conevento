﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace biz.conevento.Entities
{
    public partial class CatEstado
    {
        public CatEstado()
        {
            CatMunicipios = new HashSet<CatMunicipio>();
        }

        public int Id { get; set; }
        public string Estado { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<CatMunicipio> CatMunicipios { get; set; }
    }
}