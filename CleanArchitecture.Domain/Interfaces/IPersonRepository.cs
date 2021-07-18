using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
        Person GetPersonById(Guid? id);
        void Add(Person person);
        void Update(Person person);
        void Remove(Person person);
        IEnumerable<Person> Search(string personSearch);
        IEnumerable<ContactInformation> GetContacts();
    }
}
