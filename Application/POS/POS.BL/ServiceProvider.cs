using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Service.SO;
using POS.BL.Service.SU;
namespace POS.BL
{
    public static class ServiceProvider
    {

        private static SystemConfigurationService systemConfigurationService;
        public static SystemConfigurationService SystemConfigurationService
        {
            get
            {
                if (systemConfigurationService == null)
                {
                    systemConfigurationService = new SystemConfigurationService();
                }

                return systemConfigurationService;
            }
        }
        private static ScreenConfigService _ScreenConfigService;
        public static ScreenConfigService ScreenConfigService
        {
            get
            {
                if (_ScreenConfigService == null) _ScreenConfigService = new ScreenConfigService();
                return _ScreenConfigService;
            }

        }
        //private static EmployeeService employeeService;
        //public static EmployeeService EmployeeService
        //{
        //    get
        //    {
        //        if (employeeService == null)
        //        {
        //            employeeService = new EmployeeService();
        //        }
        //        return employeeService;
        //    }
        //}
        //private static RoleService roleService;
        //public static RoleService RoleService
        //{
        //    get
        //    {
        //        if (roleService == null)
        //        {
        //            roleService = new RoleService();
        //        }
        //        return roleService;
        //    }
        //}
    }
}
