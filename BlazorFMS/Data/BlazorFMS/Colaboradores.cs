﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BlazorFMS.Data.BlazorFMS;

public partial class Colaboradores
{
    public int ColaboradorId { get; set; }

    public string Nombre { get; set; }

    public string DireccionCasa { get; set; }

    public string UserName { get; set; }
    //public bool Seleccionado { get; set; }

    public virtual ICollection<SucursalDetalles> SucursalDetalle { get; set; } = new List<SucursalDetalles>();

    public virtual ICollection<Viajes> Viaje { get; set; } = new List<Viajes>();
}