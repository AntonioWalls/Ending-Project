using System;
using System.Collections.Generic;

namespace API_ENDING2.Models;

public partial class Litigio
{
    public int IdLitigio { get; set; }

    public int IdLitigioso { get; set; }

    public int IdRemate { get; set; }

    public string? Procedimiento { get; set; }

    public string? Juzgado { get; set; }

    public string? Expediente { get; set; }

    public string? EdoJuzgado { get; set; }

    public double? AdeudoTotal { get; set; }

    public virtual Litigioso oLitigioso { get; set; } = null!;

    public virtual Remate oRemate { get; set; } = null!;

    public virtual ICollection<Incluye> Incluyes { get; set; } = new List<Incluye>();
}
