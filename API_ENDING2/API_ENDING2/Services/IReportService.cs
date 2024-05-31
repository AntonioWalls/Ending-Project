using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_ENDING2.DTO;
namespace API_ENDING2.Services
{
        public interface IReportService
        {
            Task<IEnumerable<ReportDataDto>> GetReportData(DateTime startDate, DateTime endDate);

        }
}
