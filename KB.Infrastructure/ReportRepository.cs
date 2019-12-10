using System;
using KB.Domain.IRepository;

namespace KB.Infrastructure
{
    public class ReportRepository : IReportRepository
    {
        public ReportRepository(KBDataContext context)
        {
        }

        public object GetArticleReport()
        {
            //
            //throw new NotImplementedException();
            return null;
        }
    }
}
