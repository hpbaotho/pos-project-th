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
        public const string POS = "POS01";
        public const string OpenOrder = "SO01";
    }
    public struct ControlType
    {
        public const string Form = "Form";
        public const string Button = "Button";
        public const string Table = "Table";
        public const string Object = "Object";
    }
    public struct CommandGroup
    {
        public const string Event = "Event";
        public const string OpenNextScreen = "OpenNextScreen";
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
        public const string ConfirmNewTab = "Are you sure to new tab";
        public const string ConfirmComplete = "Are you sure to complete?";
        public const string ConfirmIncomplete = "Are you sure to Incomplete?";
        public const string ConfirmUpdate = "Are you sure to update data?";
        public const string ConfirmReject = "Are you sure to reject?";
        public const string ConfirmDelete = "Are you sure to delete?";
        public const string ConfirmProcess = "Are you sure to process?";
        public const string ConfirmOverWrite = "The data already existed in system, Are you sure to overwrite?";
        public const string ConfirmUpdateChanged = "The data has been changed, do you want to replace?";
        public const string ConfirmSaveDate = "Do you want to Save the data?";

    }
    public struct Format
    {
        public const string OneDecimalNumberFormat = "{0:#,##0.0}";
        public const string DecimalNumberFormat = "{0:#,##0.00}";
        public const string DecimalNumberFormat4DZero = "{0:#,##0.0000}";
        public const string DecimalNumberFormat2DZero = "{0:#,##0.00}";
        public const string DecimalNumberFormat4DNonZero = "{0:#,##0.####}";
        //public const string DecimalNumberFormatNoZero = "{0:#,###.####;}";
        public const string DecimalNumberFormat4D = "{0:#,##0.####;(#,##0.####);#}";
        public const string DecimalNumberFormat4DNoZero = "{0:#,##0.####;-#,##0.####;#}";
        public const string PercentFormat = "{0:P2}";
        public const string ServiceYear = "{0} Yr, {1} Mo, {2} Days";
        public const string NumberTwoFractionFormat = "#,##0.#0";
        public const string DecimalFormat = "#,###.##;(#,###.##);#";
        public const string NumberFormat = "{0:#,##0}";
        public const string FinanceNumberFormat = "{0:#,##0;(#,##0);-}";
        public const string IntegerNumberFormatComma = "{0:#,##0}";
        public const string IntegerFormat = "#,##0";
        public const string IntegerNumberFormat = "{0:##0}";
        public const string IntegerNumberFormatNoZero = "{0:#,###}";
        public const string CalendarFormat = "d-M-yy";
        public const string DateFormat = "d-MMM-yyyy";
        public const string DateFormatShowEmail = "{0:dd-Mon-yyyy }";
        public const string DateTimeFormat = "d-MMM-yyyy HH:mm:ss";
        public const string TimeFormat = "HH:mm:ss";

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
        public const string SetupSystemConfigGroup = "System Config Group";
        public const string SetupEmployee = "Setup Employee";
        public const string SetupRole = "Setup Role";
        public const string AssignEmployeeRole = "Assign Employee Role";
        public const string SystemConfiguration = "SystemConfiguration";

        public const string SetupINReceiveMaterial = "Receive Material";
        public const string SetupINSendMaterial = "Send Material";
        public const string SetupINCountStock = "Count Stock";

    }
    public struct FormatString
    {
        public const string TotalRowsGrid = "Total {0} Rows";
        public const string SelectedRowsGrid = "Selected {0} Rows";
        public const string FormatDate = "dd-MMM-yyyy";
    }
    public struct TabName
    {
        public const string Setup = "Setup {0}";
        public const string Add = "Add {0}";
        public const string Edit = "Edit {0}";
    }
    public struct DefaultFontControl
    {
        public const string FontName = "Arial";
        public const int FontSize = 14;
        public const int FontStyle = 0;
    }
    #endregion

    #region :: POS ::

    #endregion


}
public enum ObjectState
{
    Add = 1,
    Edit = 2,
    Delete = 3,
}
