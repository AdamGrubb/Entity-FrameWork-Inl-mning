using Company.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entities
{
    public class Employees : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? FirstName { get; set; }
        [MaxLength(50), Required]
        public string? LastName { get; set; }
        [Required]
        public bool Unionized { get; set; }
        public virtual ICollection<JobTitles>? JobTitle { get; set;}
        [Required]
        public int Salary { get; set; }

        public int DepartmentId { get; set; }
        public virtual Departments? Department { get; set; }

    }
}
