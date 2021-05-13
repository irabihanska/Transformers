using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IBookCoverageRepository CoverageRepository { get; }

        IBookRepository BookRepository { get;  }

        IUserRepository UserRepository { get; }

        void Save();

        Task SaveAsync();
    }
}
