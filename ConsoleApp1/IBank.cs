namespace App_Ngan_hang 
{
    interface IBank
    {
        void DangKy();
        Account DangNhap();
        void NapTien();
        void ChuyenTien();
        void RutTien();
        void DoiMatKhau(string makhaumoi);
        void HienThiLichSuGiaoDich();
        void HienThiThongTin();

    }
}
