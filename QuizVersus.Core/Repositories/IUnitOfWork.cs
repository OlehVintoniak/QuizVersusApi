using System.Threading.Tasks;

namespace QuizVersus.Core.Repositories
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}