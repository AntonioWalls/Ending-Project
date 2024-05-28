namespace API_ENDING2.DTO
{
    public class LitigioDTO
    {
        public int IdLitigio { get; set; }

        public int IdLitigioso { get; set; }

        public int IdRemate { get; set; }

        public string? Procedimiento { get; set; }

        public string? Juzgado { get; set; }

        public string? Expediente { get; set; }

        public string? EdoJuzgado { get; set; }

        public double? AdeudoTotal { get; set; }
    }
}
