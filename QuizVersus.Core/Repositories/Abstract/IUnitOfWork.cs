using System.Threading.Tasks;

namespace QuizVersus.Core.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}