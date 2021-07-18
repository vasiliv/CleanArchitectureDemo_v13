using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class PersonService : IPersonService
    {
        public IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public PersonViewModel GetPersons()
        {
            return new PersonViewModel()
            {
                Persons = _personRepository.GetPersons()
            };
        }
        public PersonViewModel GetPersonById(Guid? id)
        {
            return new PersonViewModel()
            {
                Person = _personRepository.GetPersonById(id)
            };
        }
        public void Add(PersonViewModel personViewModel)
        {
            _personRepository.Add(personViewModel.Person);           
        }
        public void Update(PersonViewModel personViewModel)
        {
            _personRepository.Update(personViewModel.Person);
        }
        public void Remove(PersonViewModel personViewModel)
        {
            _personRepository.Remove(personViewModel.Person);
        }
        public PersonViewModel Search(string personSearch)
        {
            return new PersonViewModel()
            {
                Persons = _personRepository.Search(personSearch)
            };
        }
        public PersonViewModel GetContacts()
        {
            return new PersonViewModel()
            {
                ContactInformations = _personRepository.GetContacts()
            };
        }
    }
}
