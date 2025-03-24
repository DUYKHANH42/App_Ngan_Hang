using System;

namespace App_Ngan_hang
{
    public class GiaoDich
    {
        public enum LoaiGiaoDich
        {
            ChuyenTien,
            NapTien,
            RutTien
        };
        private string maGiaoDich;
        private DateTime ngayGiaoDich;
        private LoaiGiaoDich loaiGiaoDich;
        private decimal soTien;
        private int soTaiKhoangui;
        private int? soTaikhoannhan;
        public GiaoDich()
        {
        }
        public GiaoDich(string maGiaoDich, DateTime ngayGiaoDich, LoaiGiaoDich loaiGiaoDich, decimal soTien, int soTaiKhoangui, int? soTaikhoannhan)
        {
            this.maGiaoDich = maGiaoDich;
            this.ngayGiaoDich = ngayGiaoDich;
            this.loaiGiaoDich = loaiGiaoDich;
            this.soTien = soTien;
            this.soTaiKhoangui = soTaiKhoangui;
            this.soTaikhoannhan = soTaikhoannhan;
        }
        public string Ma_Giao_Dich
        {
            get { return maGiaoDich; }
            set { maGiaoDich = value; }
        }
        public DateTime NgayGiaoDich
        {
            get { return ngayGiaoDich; }
            set { ngayGiaoDich = value; }
        }
        public LoaiGiaoDich Loai_Giao_Dich
        {
            get { return loaiGiaoDich; }
            set { loaiGiaoDich = value; }
        }
        public decimal SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }
        public int SoTaiKhoangui
        {
            get { return soTaiKhoangui; }
            set { soTaiKhoangui = value; }
        }
        public int? SoTaikhoannhan
        {
            get { return soTaikhoannhan; }
            set { soTaikhoannhan = value; }
        }


    }
}
