using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;
using POS.BL;

namespace POS.KC.KitchenOrderList
{
    public partial class KitchenOrderDetail : BaseUserControl
    {
        private string globalMaterialID = string.Empty;
        private string globalBomHeaderID = string.Empty;
        private TabControl TabOwner;
        private TabPage CurrentTab;
        private string DataKeyName = "BOM Code";
        public KitchenOrderDetail()
        {
            InitializeComponent();
        }
        public KitchenOrderDetail(string MaterialID, TabControl Owner )//, TabPage NewTab )
        {
            InitializeComponent();

            //CurrentTab = NewTab;
            TabOwner = Owner;
            baseAddEditMasterDetail.btnResetEnable = false;
            baseAddEditMasterDetail.btnSaveEnable = false;

            globalMaterialID = MaterialID;
            DataSet dsAnswer = ServiceProvider.KCSaleOrderDetailService.FindOrderByCriteria(MaterialID);
            if (dsAnswer.Tables.Count > 0 && dsAnswer.Tables[0].Rows.Count > 0)
            {
                DataRow DrAmswer = dsAnswer.Tables[0].Rows[0];
                txtTableName.Text = DrAmswer.Field<string>("Table Name");
                txtMenu.Text = DrAmswer.Field<string>("Menu");
                txtQuantity.Text = DrAmswer.Field<int>("Quantity").ToString();
            }

            //DataSet  dsAnswer = ServiceProvider.KCSaleOrderDetailService.
            grdBomHead.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(grdBase_onLoadDataGrid);
            grdBomHead.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(grdBase_onSelectedDataRow);
            grdBomHead.LoadData();

            grdBomDetail.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(grdBomDetail_onLoadDataGrid);

        }

        public void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            globalBomHeaderID = dataKey[DataKeyName].ToString();

            grdBomDetail.LoadData();
            //string  dataKey[DataKeyName].ToString()
            //addEditReceiveMaterial = new KitchenOrderDetail(dataKey[DataKeyName].ToString());
            //this.AddEditTab(string.Format(TabName.Edit, programName), addEditReceiveMaterial);
        }

        public void grdBase_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            //hide the damn column
            grdBomHead.HiddenColumnName = new List<string>() { "ID" };

            grdBomHead.DataSourceDataSet =
            ServiceProvider.KCSaleOrderDetailService.FindBOMHeaderByOrderDetailId(globalMaterialID);

            grdBomHead.DataKeyName = new string[] { DataKeyName };

            //try to set its visibility 
            grdBomHead.btnDeleteEnable = false;
            grdBomHead.btnAddEnable = false;
            grdBomHead.btnSearchEnable = false;
            // grdBomHead.RearrangeButton();

        }

        public void grdBomDetail_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            //hide the damn column
            //grdBomHead.HiddenColumnName = new List<string>() { "ID" };//, "Supplier", "Warehouse" };
            //grdBase.SetColumnFit();

            grdBomDetail.DataSourceDataSet =
                ServiceProvider.KCSaleOrderDetailService.FindBOMDetailByOrderDetailId(globalMaterialID);

            //try to set its visibility 
            grdBomDetail.btnDeleteEnable = false;
            grdBomDetail.btnAddEnable = false;
            grdBomDetail.btnSearchEnable = false;
            // grdBomHead.RearrangeButton();
        }

        private void baseAddEditMasterDetail_backHandler()
        {
            //TabOwner.TabPages.Remove(CurrentTab);
            TabOwner.TabPages.RemoveAt(1);
        }
    }
}
