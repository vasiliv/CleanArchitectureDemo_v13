using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContactInformation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContactType { get; set; }
        // one-to-many relationship
        public IEnumerable<Person> Persons { get; set; }
    }
}
