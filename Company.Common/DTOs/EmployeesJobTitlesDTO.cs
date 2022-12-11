using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Common.DTOs;

public record EmployeesJobTitlesDTO
{
    public int JobTitleId { get; set; }
    public int EmployeeId { get; set; }

    public EmployeesJobTitlesDTO (int jobTitleId, int employeeId)
    {
        JobTitleId = jobTitleId;
        EmployeeId = employeeId;
    }
}
