using DAL.Models;
using DAL.Repositories;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICoverageRepository CoverageRepository { get; }

        void Save();

        Task SaveAsync();
    }
}
