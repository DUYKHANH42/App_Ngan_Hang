using System;
using System.Collections.Generic;
using System.Linq;
using static App_Ngan_hang.MaGiaoDich;

namespace App_Ngan_hang
{
    public class Bank : IBank
    {
        private List<MaGiaoDich> dsMaGiaoDich = new List<MaGiaoDich>();
        private Account accounthientai;
        private List<Account> listAccCount = new List<Account>();

        public Bank()
        {
            listAccCount = new List<Account>();
        }
        public void DuLieu()
        {

            listAccCount.Add(new Account
            {
                HoTen = "Đặng Nguyễn Duy Khanh",
                Cmnd = "123456667432",
                Sdt = "0949263705",
                Stk = 99233322,
                Email = "kxtduykhanh@gmail.com",
                Sodu = 1000000,
                Password = "123"
            });
            listAccCount.Add(new Account
            {
                HoTen = "Đặng Tiến Hoàng",
                Cmnd = "748392654738",
                Sdt = "0841378649",
                Stk = 993699248,
                Email = "dangtienhoang@gmail.com",
                Sodu = 10000000,
                Password = "456"
            });
        }
        string TaoSoTaiKhoanNgauNhien()
        {
            Random random = new Random();
            string soTaiKhoan;
            bool daTonTai;

            do
            {
                soTaiKhoan = "";
                for (int i = 0; i < 9; i++)
                {
                    soTaiKhoan += random.Next(0, 10).ToString(); // Nối từng số vào chuỗi
                }

                // Kiểm tra trùng số tài khoản bằng vòng lặp for
                daTonTai = false;
                for (int i = 0; i < listAccCount.Count; i++)
                {
                    if (listAccCount[i].Stk.ToString() == soTaiKhoan)
                    {
                        daTonTai = true;
                        break; // Dừng vòng lặp ngay khi tìm thấy số trùng
                    }
                }

            } while (daTonTai); // Nếu số tài khoản bị trùng, lặp lại

            return soTaiKhoan;
        }

        public bool KiemTraNeuNhapSai(Account account)
        {


            for (int i = 0; i < listAccCount.Count; i++)
            {
                if (listAccCount[i].Sdt == account.Sdt)
                {
                    Console.WriteLine("Số điện thoại đã được đăng kí");

                    return false;
                }

                if (listAccCount[i].Cmnd == account.Cmnd)
                {
                    Console.WriteLine("Chứng minh nhân dân đã được đăng kí");

                    return false;
                }
                if (listAccCount[i].Email.Trim() == account.Email.Trim())
                {
                    Console.WriteLine("Email đã được đăng kí");

                    return false;
                }
            }
            return true;

        }
        public void DangKy()
        {
            Console.WriteLine("Nhập tên: ");
            string ten = Console.ReadLine();

            Console.WriteLine("Nhập email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Nhập mật khẩu: ");
            string password = Console.ReadLine();

            Console.WriteLine("Nhập số điện thoại( 10 - 11 số ): ");
            string sdt = Console.ReadLine();

            Console.WriteLine("Nhập chứng minh nhân dân( 12 số ): ");
            string cmnd = Console.ReadLine();
            if (cmnd.Length != 12)
            {
                Console.WriteLine("Chứng minh nhân dân không hợp lệ");
                return;
            }

            // Tạo tài khoản mới
            Account taiKhoanMoi = new Account
            {
                HoTen = ten,
                Email = email,
                Sdt = sdt,
                Cmnd = cmnd,
                Password = password
            };

            // Kiểm tra thông tin trước khi thêm vào danh sách
            if (!KiemTraNeuNhapSai(taiKhoanMoi))
            {
                Console.WriteLine("❌ Không thể đăng ký. Vui lòng kiểm tra lại thông tin!");
                return;
            }

            // Tạo số tài khoản ngẫu nhiên
            string stkNgauNhien = TaoSoTaiKhoanNgauNhien();
            if (string.IsNullOrEmpty(stkNgauNhien) || !int.TryParse(stkNgauNhien, out int soTaiKhoan))
            {
                Console.WriteLine("❌ Lỗi: Không thể tạo số tài khoản!");
                return;
            }

            taiKhoanMoi.Stk = soTaiKhoan; // Gán số tài khoản hợp lệ

            // Thêm tài khoản vào danh sách
            listAccCount.Add(taiKhoanMoi);

            // Gán tài khoản hiện tại
            accounthientai = taiKhoanMoi;

            Console.WriteLine("✅ Tạo tài khoản thành công!");
            Console.WriteLine($"🔹 Số tài khoản của bạn là: {taiKhoanMoi.Stk}");
        }

        public Account KiemTraKhiDangNhap(string sdt, string password)
        {
            foreach (var acc in listAccCount)
            {
                if (acc.Sdt == sdt && acc.Password == password)
                {
                    return acc; // Trả về tài khoản nếu tìm thấy
                }
            }
            return null;
        }
        public bool KiemTraSoDienThoaiHopLe(string soDienThoai)
        {
            // Kiểm tra độ dài phải từ 10 đến 11 số
            if (soDienThoai.Length < 10 || soDienThoai.Length > 11)
            {
                return false;
            }

            // Kiểm tra từng ký tự có phải là số không
            foreach (var so in soDienThoai)
            {
                if (so < '0' || so > '9')  // Nếu không phải số (0-9) thì sai
                {
                    return false;
                }
            }

            return true; // Hợp lệ
        }

        public Account DangNhap()
        {
            Console.Write("Nhập số điện thoại: ");
            string sdt = Console.ReadLine();
            Console.Write("Nhập mật khẩu: ");
            string password = Console.ReadLine();

            accounthientai = KiemTraKhiDangNhap(sdt, password);

            if (accounthientai != null)
            {
                Console.WriteLine("✅ Đăng nhập thành công!");
            }
            else
            {
                Console.WriteLine("❌ Sai thông tin đăng nhập!");
            }
            return accounthientai;
        }

        public void DangXuat()
        {
            accounthientai = null;
            Console.WriteLine("✅ Đăng xuất thành công!");
            Console.WriteLine("🔹 Bạn đã đăng xuất khỏi hệ thống.");

        }
        public void KiemTraAccountHienTai()
        {
            if (accounthientai == null)
            {
                Console.WriteLine("❌ Bạn chưa đăng nhập!");
            }
            else
            {
                Console.WriteLine("✅ Bạn đã đăng nhập!");
            }
        }
        public void HienThiThongTin()
        {
            Console.WriteLine("=================================================================================================");
            Console.WriteLine("| STK        | Họ và Tên              | Số dư      | Email                   | SĐT         | Mật khẩu     |");
            Console.WriteLine("=================================================================================================");

            foreach (var acc in listAccCount)
            {
                Console.WriteLine($"| {acc.Stk,-10} | {acc.HoTen,-22} | {acc.Sodu,-10} | {acc.Email,-24} | {acc.Sdt,-10} | {acc.Password,-12} |");
            }

            Console.WriteLine("=================================================================================================");
        }
        public string TaoMaGiaoDich()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string maGiaoDich;
            bool trungLap;

            do
            {
                maGiaoDich = new string(Enumerable.Repeat(chars, 6)
                                .Select(s => s[random.Next(s.Length)]).ToArray());

                // Kiểm tra mã có trùng không
                trungLap = dsMaGiaoDich.Any(gd => gd.Ma_Giao_Dich == maGiaoDich);
            }
            while (trungLap); // Nếu trùng thì tạo lại

            return maGiaoDich;
        }

        public void NapTien()
        {
            if (accounthientai == null)
            {
                Console.WriteLine("❌ Đăng nhập thất bại!");
                return;
            }

            Console.Write("Nhập số tiền cần nạp: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal tienNap) || tienNap <= 0)
            {
                Console.WriteLine("❌ Số tiền không hợp lệ! Vui lòng nhập lại.");
                return;
            }

            bool kiemTra = false;

            // Cập nhật số dư
            foreach (var acc in listAccCount)
            {
                if (acc.Sdt == accounthientai.Sdt)
                {
                    acc.Sodu += tienNap;


                    // ✅ Gọi hàm tạo mã giao dịch
                    string maGD = TaoMaGiaoDich();

                    // ✅ Tạo đối tượng giao dịch mới
                    MaGiaoDich giaoDichMoi = new MaGiaoDich(
                        maGD,
                        DateTime.Now,
                        LoaiGiaoDich.NapTien, // ✅ Sử dụng enum đúng cách
                        tienNap,
                        acc.Stk,
                        null

                    );

                    Console.WriteLine($"✅ Nạp tiền thành công! Số dư mới: {acc.Sodu}");
                    Console.WriteLine($"🔹 Mã giao dịch: {maGD}");

                    // ✅ Kiểm tra danh sách đã được khởi tạo chưa
                    if (dsMaGiaoDich == null)
                    {
                        dsMaGiaoDich = new List<MaGiaoDich>();
                    }

                    // ✅ Thêm giao dịch vào danh sách
                    dsMaGiaoDich.Add(giaoDichMoi);

                    kiemTra = true;
                    break;
                }
            }

            if (!kiemTra)
            {
                Console.WriteLine("❌ Nạp tiền thất bại!");
            }

            // Hiển thị thông tin cập nhật
            HienThiThongTin();
        }



        public void ChuyenTien()
        {
            if (accounthientai == null)
            {
                Console.WriteLine("❌ Bạn chưa đăng nhập!");
                return;
            }

            Console.Write("Nhập số tài khoản cần chuyển: ");
            if (!int.TryParse(Console.ReadLine(), out int stknhan))
            {
                Console.WriteLine("❌ Số tài khoản không hợp lệ!");
                return;
            }

            Console.Write("Nhập số tiền cần chuyển: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal tienchuyen) || tienchuyen <= 0)
            {
                Console.WriteLine("❌ Số tiền không hợp lệ!");
                return;
            }

            // Tìm tài khoản người nhận
            Account nguoinhan = listAccCount.FirstOrDefault(acc => acc.Stk == stknhan);

            if (nguoinhan == null)
            {
                Console.WriteLine("❌ Tài khoản nhận không tồn tại!");
                return;
            }

            if (tienchuyen > accounthientai.Sodu)
            {
                Console.WriteLine("❌ Số dư không đủ để chuyển!");
                return;
            }

            // Thực hiện giao dịch
            accounthientai.Sodu -= tienchuyen;
            nguoinhan.Sodu += tienchuyen;

            // ✅ Gọi hàm tạo mã giao dịch
            string maGD = TaoMaGiaoDich();

            // ✅ Tạo đối tượng giao dịch mới
            MaGiaoDich giaoDichMoi = new MaGiaoDich(
                maGD,
                DateTime.Now,
                LoaiGiaoDich.ChuyenTien, // ✅ Loại giao dịch là Chuyển Tiền
                tienchuyen,
                accounthientai.Stk,
                nguoinhan.Stk // Người nhận
            );

            // ✅ Đảm bảo danh sách giao dịch không bị null
            if (dsMaGiaoDich == null)
            {
                dsMaGiaoDich = new List<MaGiaoDich>();
            }

            // ✅ Lưu giao dịch vào danh sách
            dsMaGiaoDich.Add(giaoDichMoi);

            // Hiển thị thông tin giao dịch
            Console.WriteLine("✅ Chuyển tiền thành công!");
            Console.WriteLine($"📌 Người nhận: Số Tài Khoản: {nguoinhan.Stk} - {nguoinhan.HoTen}");
            Console.WriteLine($"💰 Số dư mới của bạn: {accounthientai.Sodu}");
            Console.WriteLine($"🔹 Mã giao dịch của bạn: {maGD}"); // ✅ Hiển thị mã giao dịch ngay lập tức

            // Hiển thị lại thông tin tài khoản
            HienThiThongTin();
        }

        public void HienThiLichSuGiaoDich()
        {
            if (accounthientai == null)
            {
                Console.WriteLine("❌ Bạn chưa đăng nhập!");
                return;
            }

            // Lọc danh sách giao dịch liên quan đến tài khoản đăng nhập
            List<MaGiaoDich> lichSuCuaToi = new List<MaGiaoDich>();

            foreach (var gd in dsMaGiaoDich)
            {
                if (gd.SoTaiKhoangui == accounthientai.Stk || gd.SoTaikhoannhan == accounthientai.Stk)
                {
                    lichSuCuaToi.Add(gd);
                }
            }

            if (lichSuCuaToi.Count == 0)
            {
                Console.WriteLine("📌 Bạn chưa có giao dịch nào.");
                return;
            }

            Console.WriteLine("📜 Lịch sử giao dịch của bạn:");
            foreach (MaGiaoDich gd in lichSuCuaToi)
            {
                string nguoiNhan = (gd.SoTaikhoannhan != null && gd.SoTaikhoannhan != 0)
                    ? $"→ STK: {gd.SoTaikhoannhan}"
                    : "Nạp tiền";

                Console.WriteLine($"🆔 {gd.Ma_Giao_Dich} | {gd.Loai_Giao_Dich} | {gd.SoTien} VND | {nguoiNhan} | Ngày: {gd.NgayGiaoDich}");
            }
        }

        public void RutTien()
        {
            if (accounthientai == null)
            {
                Console.WriteLine("❌ Bạn chưa đăng nhập!");
                return;
            }

            Console.Write("Nhập số tiền cần rút: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal tienRut) || tienRut <= 0)
            {
                Console.WriteLine("❌ Số tiền không hợp lệ! Vui lòng nhập lại.");
                return;
            }

            if (tienRut > accounthientai.Sodu)
            {
                Console.WriteLine("❌ Số dư không đủ để rút!");
                return;
            }

            // Cập nhật số dư
            accounthientai.Sodu -= tienRut;
            Console.WriteLine($"✅ Rút tiền thành công! Số dư mới: {accounthientai.Sodu}");

            // ✅ Gọi hàm tạo mã giao dịch
            string maGD = TaoMaGiaoDich();

            // ✅ Tạo đối tượng giao dịch mới
            MaGiaoDich giaoDichMoi = new MaGiaoDich(
                maGD,
                DateTime.Now,
                LoaiGiaoDich.RutTien, // ✅ Loại giao dịch là Rút Tiền
                tienRut,
                accounthientai.Stk,
                null // Rút tiền không có tài khoản nhận
            );

            // ✅ Đảm bảo danh sách giao dịch không bị null
            if (dsMaGiaoDich == null)
            {
                dsMaGiaoDich = new List<MaGiaoDich>();
            }

            // ✅ Lưu giao dịch vào danh sách
            dsMaGiaoDich.Add(giaoDichMoi);

            // Hiển thị thông tin giao dịch
            Console.WriteLine($"🔹 Mã giao dịch của bạn: {maGD}"); // ✅ Hiển thị mã giao dịch ngay lập tức

            // Hiển thị lại thông tin tài khoản
            HienThiThongTin();
        }

        public void DoiMatKhau()
        {
            if (accounthientai == null)
            {
                Console.WriteLine("❌ Bạn chưa đăng nhập!");
                return;
            }

            Console.Write("🔹 Nhập mật khẩu hiện tại: ");
            string matKhauCu = Console.ReadLine();

            if (matKhauCu != accounthientai.Password)
            {
                Console.WriteLine("❌ Mật khẩu hiện tại không đúng!");
                return;
            }

            Console.Write("🔹 Nhập mật khẩu mới: ");
            string matKhauMoi = Console.ReadLine();

            Console.Write("🔹 Xác nhận mật khẩu mới: ");
            string xacNhanMatKhau = Console.ReadLine();

            if (matKhauMoi != xacNhanMatKhau)
            {
                Console.WriteLine("❌ Mật khẩu xác nhận không khớp!");
                return;
            }

            // Cập nhật mật khẩu mới
            accounthientai.Password = matKhauMoi;

            // Cập nhật danh sách tài khoản
            for (int i = 0; i < listAccCount.Count; i++)
            {
                if (listAccCount[i].Sdt == accounthientai.Sdt)
                {
                    listAccCount[i].Password = matKhauMoi;
                    break;
                }
            }

            Console.WriteLine("✅ Đổi mật khẩu thành công!");
        }


    }

}
