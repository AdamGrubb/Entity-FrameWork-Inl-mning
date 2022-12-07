using Company.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entities
{
    public class Company : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string? Name { get; set; }
        [MaxLength(15), Required]
        public string? Organisationsnummer { get; set; }
        public virtual ICollection<Department>? Department { get; set; }


    }
}
