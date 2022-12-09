using Company.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entities
{
    public class EmployeesJobTitles : IReferenceEntity
    {
        public int JobTitleId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employees? Employee { get; set; }
        public virtual JobTitles? JobTitle {get; set;}


    }
}
