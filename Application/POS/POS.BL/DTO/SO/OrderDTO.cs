﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.BL.DTO.SO
{
    public class OrderHeadDTO
    {
        public OrderHeadDTO()
        {
            Person = 1;
            OrderList = new List<OrderDTO>();
        }
        private bool isStartTime = false;
        public bool IsStartTime
        {
            get
            {
                return isStartTime;
            }
            set
            {
                isStartTime = value;
                if (isStartTime)
                {
                    this.startTimeEating = DateTime.Now;
                }
            }
        }
        public string TableCode { get; set; }
        public int Person { get; set; }
        //public int Childen { get; set; }
        public bool IsCancle { get; set; }
        public long? sales_order_head_id { get; set; }
        private DateTime? startTimeEating;
        public DateTime? StartTimeEating { get { return this.startTimeEating; } }
        public DateTime? startTimeINDB { set { this.startTimeEating = value; } }
      
        public List<OrderDTO> OrderList { get; set; }
    }
    public class OrderDTO
    {
        public OrderDTO()
        {
            this.OrderState = ObjectState.Add;
        }

        public long? condiment_of_order_detail_id { get; set; }
        public long? sales_order_detail_id { get; set; }
        public long? sales_order_head_id { get; set; }
        public int order_amount { get; set; }
        public bool is_print { get; set; }
        public bool is_cancel { get; set; }
        public bool isInventoryItem { get; set; }

        public long? menu_id { get; set; }
       // public bool IsActiveMenu { get; set; }
        //public bool? isCombo { get; set; }
        //public int maxComboFreeItemQTY { get; set; }
        public long? ref_menu_dining_type_id { get; set; }
        public string menu_name { get; set; }
        public decimal order_unit_price { get; set; }
        public decimal TotalAmount { get { return this.order_amount * this.order_unit_price; } }
        public ObjectState OrderState { get; set; }

        public long? menu_dining_type_id { get; set; }
        public long? menu_group_id { get; set; }
        public long? menu_category_id { get; set; }
        public long? dining_type_id { get; set; }
        public bool IsCondiment { get; set; }
        public bool Selected { get; set; }
        public int ChkNo { get; set; }
    }
}
