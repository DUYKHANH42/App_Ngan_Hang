﻿using System;

namespace App_Ngan_hang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.DuLieu();
            int choice;
            do
            {
                Console.WriteLine("Ngân Hàng VietComBank");
                Console.WriteLine("1. Đăng Ký Tài Khoản");
                Console.WriteLine("2. Đăng Nhập");
                Console.WriteLine("3. Nạp Tiền");
                Console.WriteLine("4. Rút Tiền");
                Console.WriteLine("5. Chuyển Tiền");
                Console.WriteLine("6. Hiển Thị Tài Khoản Của Bạn");
                Console.WriteLine("7. Hiển Thị Lịch Sử Giao Dịch");
                Console.WriteLine("8. Đăng Xuất");
                Console.WriteLine("9. Đổi Mật Khẩu");
                Console.WriteLine("10. Thoát");
                Console.Write("Vui Lòng Chọn: ");
                choice=int.TryParse(Console.ReadLine(), out choice) ? choice : 0;
                switch (choice)
                {
                    case 1:
                        bank.DangKy();
                        break;
                    case 2:
                        bank.DangNhap();
                        break;
                    case 3:
                        bank.NapTien();
                        break;
                    case 4:
                        bank.RutTien();
                        break;
                    case 5:
                        bank.ChuyenTien();
                        break;
                    case 6:
                        bank.HienThiThongTinTaiKhoanDangDangNhap();
                        break;
                    case 7:
                        bank.HienThiLichSuGiaoDich();
                        break;
                    case 8:
                        bank.DangXuat();
                        break;
                    case 9:
                        bank.DoiMatKhau("");
                        break;
                    case 10:
                        Console.WriteLine("Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi");
                        break;
                    default:
                        Console.WriteLine("Chọn sai, vui lòng chọn lại");
                        break;
                }
            } while (choice != 10);

            Console.ReadLine();
        }
    }
}
