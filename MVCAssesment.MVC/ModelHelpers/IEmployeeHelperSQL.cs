using MVCAssesment.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAssesment.MVC.ModelHelpers
{
    public interface IEmployeeHelperSQL
    {
        IEnumerable<EmployeeSalaryDeptIndex> GetEmployeeWithRank();
    }
}
