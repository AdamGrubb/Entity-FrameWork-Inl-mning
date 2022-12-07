using Company.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entities
{
    public class EmployeeJobTitles : IReferenceEntity
    {
        public int JobTitleId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual JobTitle? JobTitle {get; set;}


    }
}
