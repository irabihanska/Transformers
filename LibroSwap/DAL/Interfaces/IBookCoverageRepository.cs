using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Models;

namespace DAL
{
    public interface IBookCoverageRepository : IRepository<BookCoverage>
    {
    }
}
