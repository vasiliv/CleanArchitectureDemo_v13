using CleanArchitecture.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IPersonService
    {
        PersonViewModel GetPersons();
        PersonViewModel GetPersonById(Guid? id);
        void Add(PersonViewModel person);
        void Update(PersonViewModel person);
        void Remove(PersonViewModel person);
        PersonViewModel Search(string personSearch);
        PersonViewModel GetContacts();
    }
}
