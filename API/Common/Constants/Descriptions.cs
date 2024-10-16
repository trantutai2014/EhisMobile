 public class Descriptions
 {
     public static readonly Dictionary<string, string> MaLoaiKCB = new Dictionary<string, string>
     {
         {"01", "Khám bệnh" },
         {"02", "Điều trị ngoại trú" },
         {"03", "Điều trị nội trú" },
         {"04","Điều trị nội trú ban ngày"},
         {"05","Điều trị ngoại trú các bệnh mạn tính dài ngày liên tục trong năm, áp dụng cho các bệnh theo danh mục ban hành kèm theo Thông tư số 46/2016/TT-BYT ngày 30/12/2016 của Bộ trưởng Bộ Y tế về ban hành danh mục bệnh cần chữa trị dài ngày, có khám bệnh và lĩnh thuốc"},
         {"06","Điều trị lưu tại Trạm Y tế tuyến xã, Phòng khám đa khoa khu vực"},
         {"07","Nhận thuốc theo hẹn (không khám bệnh)"},
         {"08","Điều trị ngoại trú các bệnh mạn tính dài ngày liên tục trong năm, áp dụng cho các bệnh theo danh mục ban hành kèm theo Thông tư số 46/2016/TT-BYT, có khám bệnh, có thực hiện các dịch vụ kỹ thuật và/hoặc được sử dụng thuốc"},
         {"09","Điều trị nội trú dưới 04 (bốn) giờ."},
         {"10","Các trường hợp khác"},
     };

     public static readonly Dictionary<int, string> KetQuaDieuTri = new Dictionary<int, string>
     {
         {1, "Khỏi" },
         {2, "Đỡ" },
         {3, "Không thay đổi" },
         {4, "Nặng hơn" },
         {5, "Tử vong" },
         {6, "Tiên lượng nặng xin về" },
         {7, "Chưa xác định (không thuộc một trong các mã kết quả điều trị nêu trên)" },
         {8, "Tử vong ngoại viện" }
     };

     public static readonly Dictionary<int, string> MaLoaiRaVien = new Dictionary<int, string>
     {
         {1, "Ra viện" },
         {2, "Chuyển tuyến theo yêu cầu chuyên môn" },
         {3, "Trốn viện" },
         {4, "Xin ra viện" },
         {5, "Chuyển tuyến theo yêu cầu người bệnh" }
     };
     /*
       public static readonly Dictionary<int, string> KetQuaDieuTri = new Dictionary<int, string>
     {
         {1, "" },
         {2, "" },
         {3, "" },
         {4, "" },
         {5, "" },
         {6, "" },
         {7, "" },
         {8, "" },

     };
      */
 }