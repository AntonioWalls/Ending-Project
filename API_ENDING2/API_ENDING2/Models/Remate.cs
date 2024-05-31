using System;
using System.Collections.Generic;

namespace API_ENDING2.Models;

public partial class Remate
{
    public int IdRemate { get; set; }

    public int IdInmobiliaria { get; set; }

    public string? Fiscalia { get; set; }

    public bool Estado { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Adjudicado> Adjudicados { get; set; } = new List<Adjudicado>();

    public virtual Inmobiliaria oInmobiliaria { get; set; } = null!;

    public virtual ICollection<Litigio> Litigios { get; set; } = new List<Litigio>();
}
