using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Ngan_hang
{
    public class Account
    {
        private int stk;
        private string sdt;
        private string cmnd;
        private string ten;
        private decimal sodu;
        private string email;
        private string password;
        private int mapin;
        public Account()
        {
        }
        public Account(int stk,string sdt, string cmnd, string ten, decimal sodu, string email,string password, int mapin)
        {
            this.stk = stk;
            this.sdt = sdt;
            this.cmnd = cmnd;
            this.ten = ten;
            this.sodu = sodu;
            this.email = email;
            this.password = password;
            this.mapin = mapin;
        }
     
        public int Stk
        {
            get { return stk; }
            set { stk = value; }
        }
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }
        public string HoTen
        {
            get { return ten; }
            set { ten = value; }
        }
        public decimal Sodu
        {
            get { return sodu; }
            set { sodu = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int Mapin
        {
            get { return mapin; }
            set { mapin = value; }
        }

    }
}
