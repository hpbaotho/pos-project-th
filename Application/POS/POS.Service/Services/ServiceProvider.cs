using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.Service.Services.Service;

namespace POS.Service.Services
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
    }
}
