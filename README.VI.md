# OmniPos - Hệ Thống Quản Lý F&B vừa và nhỏ [[EN](./README.md)]

![Status](https://img.shields.io/badge/Status-In%20Development-yellow?style=flat-square)
![License](https://img.shields.io/badge/License-Apache%202.0-blue?style=flat-square)
![Backend](https://img.shields.io/badge/Backend-.NET%209-purple?style=flat-square)
![Frontend](https://img.shields.io/badge/Frontend-Vue.js%203-green?style=flat-square)

> **Lưu ý:** Đây là dự án cá nhân phục vụ mục đích học tập. Các tính năng được xây dựng dựa trên trải nghiệm vận hành thực tế.

---

## 🎯 Tầm nhìn sản phẩm

* **Dành cho:** Các chủ quán Cafe, Trà chanh và chuỗi F&B quy mô vừa và nhỏ.
* **Những người:** Tìm kiếm một giải pháp **đồng bộ hóa toàn diện**: Đảm bảo hiệu suất vận hành tại điểm bán (POS) luôn ở mức tối đa, đồng thời cung cấp **hệ thống quản trị chuyên sâu** về dòng tiền, giá vốn (COGS) và năng suất nhân sự theo thời gian thực.
* **OmniPos là:** Nền tảng quản lý F&B hợp nhất.
* **Giúp:** Tối ưu hóa quy trình bán hàng (Order/Thanh toán) và tự động hóa các nghiệp vụ kế toán quản trị phức tạp.
* **Khác với:** Các hệ thống POS truyền thống rời rạc, thiếu sự liên kết chặt chẽ giữa doanh thu bán hàng và chi phí vận hành.

---

## 🚀 Tính năng nổi bật

### 1. Vận hành POS Thông minh
* **Tốc độ phục vụ tối ưu:** Giao diện cảm ứng được tinh giản đặc biệt để xử lý **lưu lượng khách giờ cao điểm**, cho phép thu ngân hoàn tất đơn hàng chỉ trong vài giây với số lần chạm màn hình tối thiểu.
* **Quản lý sàn thời gian thực:** Bảng điều khiển động cung cấp cái nhìn tức thì về trạng thái lấp đầy của bàn và tiến độ trả món (Đang chờ/Đã xong), đảm bảo nhân viên phối hợp nhịp nhàng mà không cần kiểm tra thủ công.

### 2. Kho & Công thức
* **Kiểm soát chi phí chính xác:** Hệ thống quản lý **Định mức nguyên vật liệu (BOM)** nâng cao cho phép thiết lập các công thức phức tạp (Ví dụ: *1 Cafe = 20g Hạt + 30ml Sữa*), giúp theo dõi chính xác **Giá vốn hàng bán (COGS)**.
* **Tự động trừ kho:** Tồn kho được tự động tính toán và khấu trừ ngay lập tức khi giao dịch hoàn tất, duy trì sự **nhất quán** chặt chẽ giữa Dòng tiền bán ra và Hàng hóa trong kho.

### 3. Bảo mật & Hiệu suất Nhân sự
* **Truy cập liền mạch:** Đăng nhập nhanh **không cần mật khẩu** thông qua quét mã QR trên thiết bị POS, tích hợp sẵn tính năng tự động chấm công.
* **Kiểm soát phân quyền chặt chẽ:** Cơ chế **Phân quyền dựa trên vai trò** toàn diện đảm bảo các dữ liệu nhạy cảm (như Giá vốn nhập hàng) chỉ hiển thị với nhân sự cấp cao (Admin), ngăn chặn rò rỉ thông tin nội bộ.

---

## 🛠️ Công nghệ & Kiến trúc

Áp dụng kiến trúc **Clean Architecture (Layered)** để đảm bảo khả năng mở rộng và bảo trì dễ dàng.

| Phân lớp | Công nghệ | Chi tiết |
| :--- | :--- | :--- |
| **Backend** | .NET 9 | ASP.NET Core Web API, Entity Framework Core. |
| **Frontend** | Vue.js 3 | Composition API, Vite, Tailwind CSS. |
| **Database** | SQL Server | Sử dụng Transaction để đảm bảo tính toàn vẹn dữ liệu. |

---

## 🗺️ Lộ trình phát triển

Dự án được quản lý theo quy trình **Agile/Kanban** trên GitHub Projects.

👉 **[XEM BẢNG TIẾN ĐỘ DỰ ÁN TẠI ĐÂY]()**

- [ ] **Sprint 1: Máy POS cơ bản** [Chi tiết](/docs/BACKLOG.VI.md#sprint-1-sprint-1-máy-pos-cơ-bản)
    - **Mục tiêu:** Thay thế sổ ghi chép thủ công bằng hệ thống order kỹ thuật số.
    - **Sản phẩm đầu ra:**
        - Menu điện tử (Xem danh sách món).
        - Chức năng bán hàng cơ bản (Thêm giỏ hàng, Thanh toán).
        - Lưu trữ lịch sử đơn hàng và doanh thu tổng.
    - *Lưu ý:* Chưa có đăng nhập (Mặc định Admin).
- [ ] **Sprint 2: Quản lý Nhân sự & Phân quyền** [Chi tiết](/docs/BACKLOG.VI.md#sprint-2-nhân-sự--phân-quyền)
    - **Mục tiêu:** Kiểm soát "Ai là người bán hàng?" và bảo mật dữ liệu nhạy cảm.
    - **Sản phẩm đầu ra:**
        - Tính năng Đăng nhập (QR Code / PIN).
        - Phân quyền (RBAC): Thu ngân chỉ được bán, Admin mới được sửa giá, xem báo cáo.
        - Báo cáo doanh số.
- [ ] **Sprint 3: Kho hàng & Định lượng** [Chi tiết](/docs/BACKLOG.VI.md#sprint-3-kho--công-thức)
    - **Mục tiêu:** Kiểm soát "Bán đi cái gì và Lợi nhuận bao nhiêu?".
    - **Sản phẩm đầu ra:**
        - Quản lý Nguyên liệu & Nhập kho.
        - Thiết lập Công thức.
        - Tự động trừ kho khi bán hàng.
        - Báo cáo Lợi nhuận gộp.
- [ ] **Sprint 4: Vận hành nâng cao** [Chi tiết](/docs/BACKLOG.VI.md#sprint-4-vận-hành-nâng-cao)
    - **Mục tiêu:** Tối ưu trải nghiệm khách hàng.
    - **Sản phẩm đầu ra:**
        - Sơ đồ bàn Real-time (Trạng thái bàn).
        - In hóa đơn nhiệt.
        - Tách/Gộp bàn.