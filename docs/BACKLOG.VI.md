# Backlog & Roadmap [[EN](/docs/BACKLOG.md)]

> Tài liệu này chứa danh sách các User Stories của dự án **OmniPos**, được chia nhỏ theo các Sprint và Epic.

## 📌 Quy ước quản lý trên GitHub
* **EPIC** $\rightarrow$ Tạo **Milestone**.
* **USER STORY** $\rightarrow$ Tạo **Issue**.
* **SPRINT** $\rightarrow$ Sử dụng **Project Board** (Cột Todo/In Progress).

---

## 🗺️ Lộ trình phát triển
### Sprint 1: Sprint 1: Máy POS cơ bản
**Mục tiêu:** Xây dựng luồng bán hàng cơ bản nhất. Chưa cần đăng nhập, chưa cần kho. Mục đích là để **bán được hàng và lưu tiền**.

| ID | User Story | Độ ưu tiên | Epic |
| :--- | :--- | :--- | :--- |
| **US-1.1** | **Là** Thu ngân (Mặc định), **tôi muốn** xem danh sách món ăn (có Tên, Giá, Ảnh), **để** chọn món cho khách. | **Critical** | POS |
| **US-1.2** | **Là** Thu ngân, **tôi muốn** thêm món vào giỏ hàng và tăng/giảm số lượng, **để** chốt đơn order. | **Critical** | POS |
| **US-1.3** | **Là** Thu ngân, **tôi muốn** nhìn thấy Tổng tiền tạm tính thay đổi ngay lập tức, **để** báo giá cho khách. | High | POS |
| **US-1.4** | **Là** Thu ngân, **tôi muốn** bấm nút "Thanh toán", **để** lưu đơn hàng vào Database và reset màn hình bán mới. | **Critical** | POS |
| **US-1.5** | **Là** Chủ quán, **tôi muốn** xem danh sách lịch sử các đơn đã bán trong ngày, **để** biết hôm nay bán được bao nhiêu. | **Critical** | Report |
| **US-1.6** | **Là** Thu ngân, **tôi muốn** in Hóa đơn thanh toán ra máy in nhiệt (khổ 80mm), **để** đưa cho khách. | Medium | Hardware |

---

### Sprint 2: Nhân sự & Phân quyền
**Mục tiêu:** Kiểm soát truy cập. Xác định rõ "Ai là người bán?", "Ai là người quản lý?".

| ID | User Story | Độ ưu tiên | Epic |
| :--- | :--- | :--- | :--- |
| **US-2.1** | **Là** Admin, **tôi muốn** tạo tài khoản cho nhân viên (Tên, Mã PIN, Vai trò), **để** cấp quyền truy cập. | High | System |
| **US-2.2** | **Là** Thu ngân, **tôi muốn** đăng nhập bằng **Mã PIN 4 số**, **để** vào ca làm việc nhanh chóng. | High | System |
| **US-2.3** | **Là** Thu ngân, **tôi muốn** đăng nhập bằng **Quét QR Code** (trên máy POS), **để** điểm danh tiện lợi. | Medium | System |
| **US-2.4** | **Là** Hệ thống, **tôi muốn** chặn nhân viên (Role: Staff) truy cập vào trang Cấu hình/Giá vốn, **để** bảo mật dữ liệu nhạy cảm. | **Critical** | Security |
| **US-2.5** | **Là** Admin, **tôi muốn** báo cáo doanh thu hiển thị rõ ai là người bán đơn hàng đó, **để** tính thưởng/phạt. | Medium | Report |

---

### Sprint 3: Kho & Công thức
**Mục tiêu:** Kiểm soát định lượng. Giải quyết bài toán "Bán 1 ly cafe thì mất bao nhiêu hạt?".

| ID | User Story | Độ ưu tiên | Epic |
| :--- | :--- | :--- | :--- |
| **US-3.1** | **Là** Admin, **tôi muốn** quản lý danh sách Nguyên liệu (Tên, Đơn vị tính: g, ml), **để** theo dõi tồn kho. | High | Inventory |
| **US-3.2** | **Là** Admin, **tôi muốn** thiết lập **Công thức (Recipe)** cho món (vd: 1 Bạc xỉu = 20g Cafe + 30ml Sữa đặc), **để** định nghĩa giá vốn. | **Critical** | Recipe |
| **US-3.3** | **Là** Admin, **tôi muốn** nhập kho (Inbound) khi hàng về, **để** tăng số lượng tồn trong hệ thống. | High | Inventory |
| **US-3.4** | **Là** Hệ thống, **tôi muốn** tự động trừ kho nguyên liệu tương ứng ngay khi đơn hàng được thanh toán (ở POS), **để** kho khớp với thực tế. | **Critical** | Inventory |
| **US-3.5** | **Là** Admin, **tôi muốn** xem báo cáo **Lợi nhuận gộp** (Doanh thu - Giá vốn) theo thời gian thực. | Medium | Report |

---

### Sprint 4: Vận hành nâng cao
**Mục tiêu:** Tối ưu trải nghiệm khách hàng và vận hành chuyên nghiệp.

| ID | User Story | Độ ưu tiên | Epic |
| :--- | :--- | :--- | :--- |
| **US-4.1** | **Là** Thu ngân, **tôi muốn** xem **Sơ đồ bàn** trực quan (Xanh/Đỏ/Vàng), **để** biết bàn nào trống hoặc đang chờ món. | High | POS |
| **US-4.2** | **Là** Thu ngân, **tôi muốn** thêm Ghi chú (Note) cho món (ít đá, không đường), **để** in vào phiếu bếp. | Medium | POS |
| **US-4.4** | **Là** Hệ thống, **tôi muốn** gửi thông báo Real-time khi bếp làm xong món, **để** nhân viên phục vụ biết và trả đồ. | Low | System |