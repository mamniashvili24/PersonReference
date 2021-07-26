using Domain.Entities;
using System.Collections.Generic;

namespace Application.Queries.Report
{
    public class ReportQueryRespons
    {
        public Person Person { get; set; }
        public IEnumerable<TypeAndCount> TypeAndCount { get; set; }
    }
    public class TypeAndCount
    {
        public int Count { get; set; }
        public string Type { get; set; }
    }
}