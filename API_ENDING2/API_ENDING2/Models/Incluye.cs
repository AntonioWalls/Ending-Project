using System;
using System.Collections.Generic;

namespace API_ENDING2.Models;

public partial class Incluye
{
    public int IdPropiedad { get; set; }

    public int IdLitigioso { get; set; }

    public int IdLitigio { get; set; }

    public int IdAdjudicado { get; set; }

    public virtual Adjudicado oAdjudicado { get; set; } = null!;

    public virtual Litigio oLitigio { get; set; } = null!;

    public virtual Litigioso oLitigioso { get; set; } = null!;

    public virtual Propiedad oPropiedad { get; set; } = null!;
}
