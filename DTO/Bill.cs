using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public Bill(int id ,DateTime? dateCheckin , DateTime? dateCheckout , int status, int discount = 0)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckin;
            this.DateCheckOut = dateCheckout;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.ID = (int) row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckin"] ; //DataTime?: cho phep null

            var dataCheckOutTemp = row["dateCheckout"];
            if(dataCheckOutTemp.ToString() != "") //Neu tra ra la ki hieu rong can toString 
            this.DateCheckOut = (DateTime?)dataCheckOutTemp;

            this.Status = (int)row["status"];

            if (row["discount"].ToString() != "") 
            this.Status = (int)row["discount"];
        }
        private int ID;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;
        private int discount;


        public int ID1 { get => ID; set => ID = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
