using SoapApiExample.Models;
using System.ServiceModel;

namespace SoapApiExample.Services
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        Task<string> GetPersonNameAsync(int id);

        [OperationContract]
        Task AddPersonAsync(string name);

        [OperationContract]
        Task<List<Person>> GetAllPersonsAsync();
    }
}
