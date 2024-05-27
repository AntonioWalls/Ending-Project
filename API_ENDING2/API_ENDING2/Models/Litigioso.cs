using System;
using System.Collections.Generic;

namespace API_ENDING2.Models;

public partial class Litigioso
{
    public int IdLitigioso { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Rfc { get; set; }

    public string? Curp { get; set; }

    public string? Telefono { get; set; }

    public string? Calle { get; set; }

    public string? Num { get; set; }

    public string? Colonia { get; set; }

    public string? Municipio { get; set; }

    public string? Estado { get; set; }

    public int? Cp { get; set; }

    public virtual ICollection<Incluye> Incluyes { get; set; } = new List<Incluye>();

    public virtual ICollection<Litigio> Litigios { get; set; } = new List<Litigio>();
}
