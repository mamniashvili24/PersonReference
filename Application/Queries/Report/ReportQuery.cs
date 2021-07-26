using Infrastructure.CommonTypes.Abstractions;
using System.Collections.Generic;
using Infrastructure.CQRS.Queries;

namespace Application.Queries.Report
{
    public class ReportQuery : IQuery<IDataResponse<IEnumerable<ReportQueryRespons>>>
    {
    }
}
