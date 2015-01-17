using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Service.SO;
using POS.BL.Service.SU;
using POS.BL.Service.IN;
using POS.BL.Service.DB;
namespace POS.BL
{
    public static class ServiceProvider
    {
        private static SystemConfigGroupService systemConfigGroupService;
        public static SystemConfigGroupService SystemConfigGroupService
        {
            get
            {
                if (systemConfigGroupService == null)
                {
                    systemConfigGroupService = new SystemConfigGroupService();
                }

                return systemConfigGroupService;
            }
        }
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

        private static EmployeeService employeeService;
        public static EmployeeService EmployeeService
        {
            get
            {
                if (employeeService == null)
                {
                    employeeService = new EmployeeService();
                }
                return employeeService;
            }
        }
        private static RoleService roleService;
        public static RoleService RoleService
        {
            get
            {
                if (roleService == null)
                {
                    roleService = new RoleService();
                }
                return roleService;
            }
        }

        private static TranHeadService tranHeadService;
        public static TranHeadService TranHeadService
        {
            get
            {
                if (tranHeadService == null)
                {
                    tranHeadService = new TranHeadService();
                }
                return tranHeadService;
            }
        }

        private static WareHouseService wareHouseService;
        public static WareHouseService WareHouseService
        {
            get
            {
                if (wareHouseService == null)
                {
                    wareHouseService = new WareHouseService();
                }
                return wareHouseService;
            }
        }

        private static SupplierService supplierService;
        public static SupplierService SupplierService
        {
            get
            {
                if (supplierService == null)
                {
                    supplierService = new SupplierService();
                }
                return supplierService;
            }
        }

        private static DocumentLastRunningNumberService documentLastRunningNumberService;
        public static DocumentLastRunningNumberService DocumentLastRunningNumberService
        {
            get
            {
                if (documentLastRunningNumberService == null)
                {
                    documentLastRunningNumberService = new DocumentLastRunningNumberService();
                }
                return documentLastRunningNumberService;
            }
        }

        private static DocumentNumberFormatService documentNumberFormatService;
        public static DocumentNumberFormatService DocumentNumberFormatService
        {
            get
            {
                if (documentNumberFormatService == null)
                {
                    documentNumberFormatService = new DocumentNumberFormatService();
                }
                return documentNumberFormatService;
            }
        }

        private static DocumentTypeService documentTypeService;
        public static DocumentTypeService DocumentTypeService
        {
            get
            {
                if (documentTypeService == null)
                {
                    documentTypeService = new DocumentTypeService();
                }
                return documentTypeService;
            }
        }

        private static ReasonService reasonService;
        public static ReasonService ReasonService
        {
            get
            {
                if (reasonService == null)
                {
                    reasonService = new ReasonService();
                }
                return reasonService;
            }
        }
        private static LogLotService logLotService;
        public static LogLotService LogLotService
        {
            get
            {
                if (logLotService == null)
                {
                    logLotService = new LogLotService();
                }
                return logLotService;
            }
        }

        private static MaterialService materialService;
        public static MaterialService MaterialService
        {
            get
            {
                if (materialService == null)
                {
                    materialService = new MaterialService();
                }
                return materialService;
            }
        }


        private static PhyLotService phyLotService;
        public static PhyLotService PhyLotService
        {
            get
            {
                if (phyLotService == null)
                {
                    phyLotService = new PhyLotService();
                }
                return phyLotService;
            }
        }

        private static PeriodService periodService;
        public static PeriodService PeriodService
        {
            get
            {
                if (periodService == null)
                {
                    periodService = new PeriodService();
                }
                return periodService;
            }
        }


        private static TranDetailService tranDetailService;
        public static TranDetailService TranDetailService
        {
            get
            {
                if (tranDetailService == null)
                {
                    tranDetailService = new TranDetailService();
                }
                return tranDetailService;
            }
        }

        private static MenuService menuService;
        public static MenuService MenuService
        {
            get
            {
                if (menuService == null)
                {
                    menuService = new MenuService();
                }
                return menuService;
            }
        }
        private static WorkPeriodService workPeriodService;
        public static WorkPeriodService WorkPeriodService
        {
            get
            {
                if (workPeriodService == null)
                {
                    workPeriodService = new WorkPeriodService();
                }
                return workPeriodService;
            }
        }

        private static SaleOrderHeaderService saleOrderHeaderService;
        public static SaleOrderHeaderService SaleOrderHeaderService
        {
            get
            {
                if (saleOrderHeaderService == null)
                {
                    saleOrderHeaderService = new SaleOrderHeaderService();
                }
                return saleOrderHeaderService;
            }
        }
        private static SaleOrderDetailService saleOrderDetailService;
        public static SaleOrderDetailService SaleOrderDetailService
        {
            get
            {
                if (saleOrderDetailService == null)
                {
                    saleOrderDetailService = new SaleOrderDetailService();
                }
                return saleOrderDetailService;
            }
        }
        private static DiningTypeService diningTypeService;
        public static DiningTypeService DiningTypeService
        {
            get
            {
                if (diningTypeService == null)
                {
                    diningTypeService = new DiningTypeService();
                }
                return diningTypeService;
            }
        }

        private static MenuGroupService menuGroupService;
        public static MenuGroupService MenuGroupService
        {
            get
            {
                if (menuGroupService == null)
                {
                    menuGroupService = new MenuGroupService();
                }
                return menuGroupService;
            }
        }

        private static MenuCategoryService menuCategoryService;
        public static MenuCategoryService MenuCategoryService
        {
            get
            {
                if (menuCategoryService == null)
                {
                    menuCategoryService = new MenuCategoryService();
                }
                return menuCategoryService;
            }
        }

        private static MenuMappingService menuMappingService;
        public static MenuMappingService MenuMappingService
        {
            get
            {
                if (menuMappingService == null)
                {
                    menuMappingService = new MenuMappingService();
                }
                return menuMappingService;
            }
        }

        private static BillOfMaterialGroupService billOfMaterialGroupService;
        public static BillOfMaterialGroupService BillOfMaterialGroupService
        {
            get
            {
                if (billOfMaterialGroupService == null)
                {
                    billOfMaterialGroupService = new BillOfMaterialGroupService();
                }
                return billOfMaterialGroupService;
            }
        }

        private static BillOfMaterialHeadService billOfMaterialHeadService;
        public static BillOfMaterialHeadService BillOfMaterialHeadService
        {
            get
            {
                if (billOfMaterialHeadService == null)
                {
                    billOfMaterialHeadService = new BillOfMaterialHeadService();
                }
                return billOfMaterialHeadService;
            }
        }

        private static BillOfMaterialDetailService billOfMaterialDetailService;
        public static BillOfMaterialDetailService BillOfMaterialDetailService
        {
            get
            {
                if (billOfMaterialDetailService == null)
                {
                    billOfMaterialDetailService = new BillOfMaterialDetailService();
                }
                return billOfMaterialDetailService;
            }
        }

        private static UOMService uOMService;
        public static UOMService UOMService
        {
            get
            {
                if (uOMService == null)
                {
                    uOMService = new UOMService();
                }
                return uOMService;
            }
        }

        private static UOMRatioService uOMRatioService;
        public static UOMRatioService UOMRatioService
        {
            get
            {
                if (uOMRatioService == null)
                {
                    uOMRatioService = new UOMRatioService();
                }
                return uOMRatioService;
            }
        }

        private static PeriodGroupService periodGroupService;
        public static PeriodGroupService PeriodGroupService
        {
            get
            {
                if (periodGroupService == null)
                {
                    periodGroupService = new PeriodGroupService();
                }
                return periodGroupService;
            }
        }
    }
}
