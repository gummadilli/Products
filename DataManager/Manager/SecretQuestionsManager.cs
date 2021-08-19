using CommonLibraries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Manager
{ 
    public class SecretQuestionsManager : ISecretQuestions
    {
        private readonly IDataUoW _dataUow;
        public SecretQuestionsManager(IDataUoW dataUow)
        {
            _dataUow = dataUow;
        }
        public async Task<dynamic> GetAllSecretQuestions()
        {
            var secretQuestionsData = await _dataUow.SecretQuestions.GetAll().ToListAsync();
            return secretQuestionsData;
        }
        public async Task<dynamic> DeleteSecretQuestion(SecretQuestions secretQuestions)
        {
            _dataUow.SecretQuestions.Delete(secretQuestions);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> UpdateSecretQuestion(SecretQuestions secretQuestions)
        {
            _dataUow.SecretQuestions.Update(secretQuestions);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> SaveSecretQuestion(SecretQuestions secretQuestions)
        {
            _dataUow.SecretQuestions.Add(secretQuestions);
            await _dataUow.CommitAsync("");
            return "Success";
        }
        public async Task<dynamic> GetSecretQuestionById(long id)
        {
            var secretQuestionsData = await _dataUow.SecretQuestions.GetAllWithNoTracking().Where(p => p.SecretQuestionId == id).FirstOrDefaultAsync();
            return secretQuestionsData;
        }
    }
}
