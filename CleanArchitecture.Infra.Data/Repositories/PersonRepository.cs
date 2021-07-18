using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public LibraryDbContext _context;
        public PersonRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Person> GetPersons()
        {
            return _context.Persons;
        }
        public Person GetPersonById(Guid? id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }
        public void Update(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }
        public void Remove(Person person)
        {
            _context.Remove(person);
            _context.SaveChanges();
        }
        public IEnumerable<Person> Search(string personSearch)
        {
            return _context.Persons.Where(p => p.FirstNameLatin.Contains(personSearch) || p.SecondNameLatin.Contains(personSearch));
        }
        public IEnumerable<ContactInformation> GetContacts()
        {
            return _context.ContactInformation;
        }
    }
}
