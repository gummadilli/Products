using Products.Models;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface ISecretQuestions
    {
        Task<dynamic> GetAllSecretQuestions();
        Task<dynamic> GetSecretQuestionById(long id);
        Task<dynamic> SaveSecretQuestion(SecretQuestions secretQuestions);
        Task<dynamic> UpdateSecretQuestion(SecretQuestions secretQuestions);
        Task<dynamic> DeleteSecretQuestion(SecretQuestions secretQuestions);
    }
}
