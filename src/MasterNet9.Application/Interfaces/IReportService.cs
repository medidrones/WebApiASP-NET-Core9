using MasterNet9.Domain;

namespace MasterNet9.Application.Interfaces;

public interface IReportService<T> where T : BaseEntity
{
    Task<MemoryStream> GetCsvReport(List<T> records);
}
