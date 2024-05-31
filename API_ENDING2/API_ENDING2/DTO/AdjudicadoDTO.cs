namespace API_ENDING2.DTO
{
    public class AdjudicadoDTO
    {
        public int IdAdjudicado { get; set; }

        public int IdRemate { get; set; }

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

        public string? SemafonoEscrituracion { get; set; }

        public string? Consideraciones { get; set; }

        public bool? EstadoAdjudicacion { get; set; }
    }
}
