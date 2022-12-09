using Company.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entities
{
    public class JobTitles: IEntity
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? Title { get; set; }
        public virtual ICollection<Employees>? Employee { get; set; }
    }
}
