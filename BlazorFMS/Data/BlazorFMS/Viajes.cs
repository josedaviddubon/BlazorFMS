﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BlazorFMS.Data.BlazorFMS;

public partial class Viajes
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Distancia { get; set; }

    public int? ColaboradorId { get; set; }

    public int? TransportistaId { get; set; }

    public string UserName { get; set; }

    public virtual Colaboradores Colaborador { get; set; }

    public virtual Transportistas Transportista { get; set; }


}