using QuizVersus.Core.Services.Interfaces;

namespace QuizVersus.Core.Services.Factory
{
    public interface IServiceManager
    {
        IApplicationUserService ApplicationUsers { get; }
    }
}