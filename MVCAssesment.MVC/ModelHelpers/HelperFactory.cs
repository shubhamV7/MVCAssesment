/// <summary>
/// factory class to provide instance of IDepartmentHelper and IEmployeeHelper
/// </summary>
namespace MVCAssesment.MVC.ModelHelpers
{
    public static class HelperFactory
    {
        public static IDepartmentHelper GetDepartmentHelper()
        {
            return new DepartmentHelper();
        }

        public static IEmployeeHelper GetEmployeeHelper()
        {
            return new EmployeeHelper();
        }
    }
}