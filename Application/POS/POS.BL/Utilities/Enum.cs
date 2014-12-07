using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.BL.Utilities
{
    #region :: System ::
    public struct ConnectionStringName
    {
        public const string POSConnection = "POS";
    }
    public struct ControlCode
    {
        public const string Login = "LN001";
    }
    public struct ControlType
    {
        public const string Form = "Form";
        public const string Button = "Button";
        public const string Table = "Table";
    }
    public struct ObjectState
    {
        public const string Nothing = "N";
        public const string Update = "U";
        public const string Delete = "D";
        public const string Add = "A";
    }
    public struct GeneralMessage
    {

        public const string MessageBoxTitle = "System Message";

        public const string NoSelectedDataUpdate = "Please select data to update";
        public const string NoSelectedDataPrint = "Please select data to print";
        public const string NoSelectedDataComplete = "Please select data to complete";
        public const string NoSelectedDataIncomplete = "Please select data to Incomplete";
        public const string NoSelectedData = "Please select data to delete";
        public const string NoSelectedDataAdd = "Please select data to add";
        public const string NoSelectedDataGenerate = "Please select data to generate";
        public const string SaveComplete = "Save data completed";
        public const string DeleteComplete = "Delete data completed";
        public const string GenerateComplete = "Generate data completed";
        public const string CannotSaveNotChange = "Cannot Save , Please change data before.";
        public const string UploadSuccessfully = "Upload data completed";
        public const string NoDataComplete = "Completed {0} rows(s)";

        //------------ Confirm
        public const string ConfirmComplete = "Are you sure to complete?";
        public const string ConfirmIncomplete = "Are you sure to Incomplete?";
        public const string ConfirmUpdate = "Are you sure to update data?";
        public const string ConfirmReject = "Are you sure to reject?";
        public const string ConfirmDelete = "Are you sure to delete?";
        public const string ConfirmProcess = "Are you sure to process?";
        public const string ConfirmOverWrite = "The data already existed in system, Are you sure to overwrite?";
        public const string ConfirmUpdateChanged = "The data has been changed, do you want to replace?";

    }
    public struct ErrorMessage
    {
        // For SO 
        public const string ScreenCodeIsRequire = "Screen Code is require.";
        public const string IsDuplicate = "{0} is duplicate in system.";
    }
    public struct CustomControl
    {
        public const int GridSize = 20;
        public const int ResizeBox = 8;
    }
    public struct ModuleName
    {
        public const string Setting = "Setting";
        public const string Inventory = "Inventory";
    }
    public struct ProgramName
    {
        public const string SetupEmployee = "Setup Employee";
        public const string SetupRole = "Setup Role";
        public const string AssignEmployeeRole = "Assign Employee Role";
        public const string SystemConfiguration = "SystemConfiguration";
    }
    #endregion

    #region :: POS ::

    #endregion
}
