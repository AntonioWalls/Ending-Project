using System;
using System.Collections.Generic;

namespace API_ENDING.Models;

public partial class Remate
{
    public int IdRemate { get; set; }

    public int IdInmobiliaria { get; set; }

    public string? Fiscalia { get; set; }

    public bool Estado { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Adjudicado> oAdjudicado { get; set; } = new List<Adjudicado>();

    public virtual Inmobiliaria oInmobiliaria { get; set; } = null!;

    public virtual ICollection<Litigio> oLitigio { get; set; } = new List<Litigio>();
}
