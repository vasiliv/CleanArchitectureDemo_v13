using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ViewModels
{
    public class PersonViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
        public Person Person { get; set; }
        public IEnumerable<ContactInformation> ContactInformations { get; set; }
    }
}
