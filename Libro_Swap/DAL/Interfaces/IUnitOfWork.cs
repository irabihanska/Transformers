using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IBookCoverageRepository CoverageRepository { get; }

        void Save();

        Task SaveAsync();
    }
}
