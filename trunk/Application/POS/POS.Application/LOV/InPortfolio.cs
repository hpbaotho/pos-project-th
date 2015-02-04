using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL.DTO.SO;
using POS.Control;
using POS.BL;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using POS.Popup;
using POS.BL.DTO;

namespace POS.LOV
{
    public partial class InPortfolio : PopupBase
    {
        string DataKeyID = "ID";
        public InPortfolio()
        {
            InitializeComponent();
        }
        private void grdBase_onLoadDataGrid(object sender, Control.GridView.DataBindArgs e)
        {
            PortfolioHead entity = new PortfolioHead();
            entity.portfolio_head_name = txtName.Text; 
            entity.portfolio_head_code = txtCode.Text;
            entity.portfolio_head_desc = txtDesc.Text;

            grdBaseHead.DataSourceDataSet = ServiceProvider.PortfolioHeadService.GetGridPortfolioHead(entity); 

            grdBaseHead.DataKeyName = new string[] { DataKeyID };
            grdBaseHead.HiddenColumnName = new List<string>() { "ID" };
        }
        private void InMaterial_Load(object sender, EventArgs e)
        {
            //try to set its visibility 
            this.grdBaseHead.btnAddVisible = false;
            this.grdBaseHead.btnDeleteVisible = false;
            this.grdBaseHead.btnAddEnable = false;
            this.grdBaseHead.btnDeleteEnable = false;
            this.grdBaseHead.RearrangeButton();   
        }
        private void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            object result = base.OpenPopup<InPopupSelectWarehouse>();
            if (result != null)
            {
                Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
                PortfolioHead entity = new PortfolioHead();
                entity.portfolio_head_id = dataKey[DataKeyID].ToLong();                
                DataSet dsPortfolioDetail = ServiceProvider.PortfolioDetailService.GetGridPortfolioDetail(entity);
                ComboBoxDTO dto = (ComboBoxDTO)result;
                if(dsPortfolioDetail.Tables.Count > 0){
                    foreach (DataRow dr in dsPortfolioDetail.Tables[0].Rows) { 
                        dr["warehouse_id"] = dto.Value.ToLong();
                        dr["warehouse_name"] = dto.Display;
                    }
                }
                this.ClosePopup(dsPortfolioDetail);
            }
        }
    }
}
