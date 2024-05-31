using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_ENDING2.Models;

namespace API_ENDING2.Services
{
    public class ReportService : IReportService
    {
        private readonly ProyectoWebContext _context;

        public ReportService(ProyectoWebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReportDataDto>> GetReportData(DateTime startDate, DateTime endDate)
        {
            var data = await _context.Remates
                .Where(r => r.Fecha >= startDate && r.Fecha <= endDate)
                .Select(r => new ReportDataDto
                {
                    IdRemate = r.IdRemate,
                    Fecha = r.Fecha,
                    Descripcion = r.Descripcion,
                    Inmobiliaria = r.oInmobiliaria.RazonSocial,
                    Adjudicados = r.Adjudicados.Select(a => new AdjudicadoDto
                    {
                        IdAdjudicado = a.IdAdjudicado,
                        Nombres = a.Nombres,
                        Apellidos = a.Apellidos,
                        Rfc = a.Rfc,
                        Curp = a.Curp,
                        Telefono = a.Telefono,
                        Municipio = a.Municipio,
                        Estado = a.Estado,
                        Cp = a.Cp
                    }).ToList(),
                    Litigios = r.Litigios.Select(l => new LitigioDto
                    {
                        IdLitigio = l.IdLitigio,
                        Procedimiento = l.Procedimiento,
                        Juzgado = l.Juzgado,
                        Expediente = l.Expediente,
                        EdoJuzgado = l.EdoJuzgado,
                        AdeudoTotal = l.AdeudoTotal
                    }).ToList()
                }).ToListAsync();

            return data;
        }
    }

    public class ReportDataDto
    {
        public int IdRemate { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Descripcion { get; set; }
        public string Inmobiliaria { get; set; }
        public List<AdjudicadoDto> Adjudicados { get; set; }
        public List<LitigioDto> Litigios { get; set; }
    }

    public class AdjudicadoDto
    {
        public int IdAdjudicado { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Rfc { get; set; }
        public string? Curp { get; set; }
        public string? Telefono { get; set; }
        public string? Municipio { get; set; }
        public string? Estado { get; set; }
        public int? Cp { get; set; }
    }

    public class LitigioDto
    {
        public int IdLitigio { get; set; }
        public string? Procedimiento { get; set; }
        public string? Juzgado { get; set; }
        public string? Expediente { get; set; }
        public string? EdoJuzgado { get; set; }
        public double? AdeudoTotal { get; set; }
    }
}
