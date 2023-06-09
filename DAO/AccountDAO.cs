﻿using Microsoft.SqlServer.Server;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {

            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {userName , passWord });

            //ExecuteQuery sẽ trả ra các dòng kết quả 


            return result.Rows.Count > 0; // Số dòng trả ra lớn hơn 0
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
           DataTable data =  DataProvider.Instance.ExecuteQuery("select * from Account where userName = '" + userName + "'");

            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
    }
}
