using System;
using System.Collections.Generic;

namespace API_ENDING2.Models;

public partial class Inmobiliaria
{
    public int IdInmobiliaria { get; set; }

    public string? RazonSocial { get; set; }

    public string? Rfc { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Remate> Remates { get; set; } = new List<Remate>();
}
