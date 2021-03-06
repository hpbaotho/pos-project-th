﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.BL.Service.SO;
using POS.BL.Service.SU;
using POS.BL.Service.IN;
using POS.BL.Service.DB;

using POS.BL.Service.SC;
using POS.BL.DTO.SU;

using POS.BL.Service.KC;
//using POS.BL.Service.KC;

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

        private static MaterialGroupService materialGroupService;
        public static MaterialGroupService MaterialGroupService
        {
            get
            {
                if (materialGroupService == null)
                {
                    materialGroupService = new MaterialGroupService();
                }
                return materialGroupService;
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
        private static KCSaleOrderDetailService kcSaleOrderDetailService;
        public static KCSaleOrderDetailService KCSaleOrderDetailService
        {
            get
            {
                if (kcSaleOrderDetailService == null)
                {
                    kcSaleOrderDetailService = new KCSaleOrderDetailService();
                }
                return kcSaleOrderDetailService;
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


        private static ScreenImageService _ScreenImageService;
        public static ScreenImageService ScreenImageService
        {
            get
            {
                if (_ScreenImageService == null) _ScreenImageService = new ScreenImageService();
                return _ScreenImageService;
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


        private static SOTableService _SOTableService;
        public static SOTableService SOTableService
        {
            get
            {
                if (_SOTableService == null) _SOTableService = new SOTableService();
                return _SOTableService;
            }

        }

        private static OrderCheckService _OrderCheckService;
        public static OrderCheckService OrderCheckService
        {
            get
            {
                if (_OrderCheckService == null) _OrderCheckService = new OrderCheckService();
                return _OrderCheckService;
            }

        }

        private static MenuDiningTypeService _MenuDiningTypeService;
        public static MenuDiningTypeService MenuDiningTypeService
        {
            get
            {
                if (_MenuDiningTypeService == null) _MenuDiningTypeService = new MenuDiningTypeService();
                return _MenuDiningTypeService;
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

        private static StockHeadService stockHeadService;
        public static StockHeadService StockHeadService
        {
            get
            {
                if (stockHeadService == null)
                {
                    stockHeadService = new StockHeadService();
                }
                return stockHeadService;
            }
        }
        private static StockDetailService stockDetailService;
        public static StockDetailService StockDetailService
        {
            get
            {
                if (stockDetailService == null)
                {
                    stockDetailService = new StockDetailService();
                }
                return stockDetailService;
            }
        }

        private static BFLogicalService bfLogicalService;
        public static BFLogicalService BFLogicalService
        {
            get
            {
                if (bfLogicalService == null)
                {
                    bfLogicalService = new BFLogicalService();
                }
                return bfLogicalService;
            }
        }

        private static BFPhysicalService bfPhysicalService;
        public static BFPhysicalService BFPhysicalService
        {
            get
            {
                if (bfPhysicalService == null)
                {
                    bfPhysicalService = new BFPhysicalService();
                }
                return bfPhysicalService;
            }
        }

        private static PortfolioDetailService portfolioDetailService;
        public static PortfolioDetailService PortfolioDetailService
        {
            get
            {
                if (portfolioDetailService == null)
                {
                    portfolioDetailService = new PortfolioDetailService();
                }
                return portfolioDetailService;
            }
        }

        private static PortfolioHeadService portfolioHeadService;
        public static PortfolioHeadService PortfolioHeadService
        {
            get
            {
                if (portfolioHeadService == null)
                {
                    portfolioHeadService = new PortfolioHeadService();
                }
                return portfolioHeadService;
            }
        }
    }
    public sealed class UserAccount
    {
        private static readonly UserAccount _instance = new UserAccount();
        private static UserAccountDTO _userAccount;
        public static void SignOut()
        {
            _userAccount = null;
        }
        public static UserAccountDTO SignIn(string password)
        {
            _userAccount = new UserAccountDTO();
            _userAccount.UserName = "TestUser";
            return _userAccount;

        }
        public static UserAccountDTO UserData { get { return _userAccount; } }

    }

}
