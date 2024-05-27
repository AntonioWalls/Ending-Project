using System;
using System.Collections.Generic;

namespace API_ENDING2.Models;

public partial class Propiedad
{
    public int IdPropiedad { get; set; }

    public string? Calle { get; set; }

    public string? Num { get; set; }

    public string? Colonia { get; set; }

    public string? Municipio { get; set; }

    public string? Estado { get; set; }

    public int? Cp { get; set; }

    public string? Subtipo { get; set; }

    public double? Latitud { get; set; }

    public double? Altitud { get; set; }

    public double? SuperficieTerreno { get; set; }

    public double? SuperficieCons { get; set; }

    public virtual ICollection<Incluye> Incluyes { get; set; } = new List<Incluye>();
}
