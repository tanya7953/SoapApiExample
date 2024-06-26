using SoapApiExample.Data;
using SoapApiExample.Models;

namespace SoapApiExample.Services
{
    public class PersonService : IPersonService
    {
        private static readonly List<Person> Persons = new List<Person>
    {
        new Person { Id = 1, Name = "John Doe" },
        new Person { Id = 2, Name = "Jane Smith" }
    };
        public Task<string> GetPersonNameAsync(int id)
        {
            var person = Persons.Find(p => p.Id == id);
            return Task.FromResult(person?.Name);
        }

        public Task AddPersonAsync(string name)
        {
            var newPerson = new Person
            {
                Id = Persons.Count + 1,
                Name = name
            };
            Persons.Add(newPerson);
            return Task.CompletedTask;
        }

        public Task<List<Person>> GetAllPersonsAsync()
        {
            return Task.FromResult(Persons);
        }
    }
}
