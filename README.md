![](docs/evo.png)
# EV Service Center Maintenance Management System

**Phần mềm quản lý bảo dưỡng xe điện cho trung tâm dịch vụ**

## 📋 Mục Đích Dự Án

Xây dựng một hệ thống quản lý bảo dưỡng toàn diện cho các trung tâm dịch vụ xe điện (EV), giúp tối ưu hóa quy trình dịch vụ, nâng cao trải nghiệm khách hàng và quản lý hiệu quả các hoạt động kinh doanh.

---

## 👥 Đối Tượng Người Dùng

- 👤 **Khách hàng (Customer)**
- 👷 **Nhân viên dịch vụ (Staff)**
- 🔧 **Kỹ thuật viên (Technician)**
- ⚙️ **Quản trị viên (Admin)**

---

## ✨ Tính Năng Chính

### 1️⃣ Chức Năng Cho Khách Hàng (Customer)

#### a. Theo Dõi Xe & Nhắc Nhở
- 🔔 Nhắc nhở bảo dưỡng định kỳ theo km hoặc thời gian
- 💳 Nhắc thanh toán gói bảo dưỡng định kỳ hoặc gia hạn gói dịch vụ

#### b. Đặt Lịch Dịch Vụ
- 📅 Đặt lịch bảo dưỡng/sửa chữa trực tuyến
- 🏢 Chọn trung tâm dịch vụ & loại dịch vụ
- ✅ Nhận xác nhận & thông báo trạng thái (chờ – đang bảo dưỡng – hoàn tất)

#### c. Quản Lý Hồ Sơ & Chi Phí
- 📄 Lưu lịch sử bảo dưỡng xe điện
- 💰 Quản lý chi phí bảo dưỡng & sửa chữa theo từng lần
- 💳 Thanh toán online (e-wallet, banking, ...)

---

### 2️⃣ Chức Năng Cho Trung Tâm Dịch Vụ (Staff, Technician, Admin)

#### a. Quản Lý Khách Hàng & Xe
- 👥 Hồ sơ khách hàng & xe (model, VIN, lịch sử dịch vụ)
- 💬 Chat trực tuyến với khách hàng

#### b. Quản Lý Lịch Hẹn & Dịch Vụ
- 📍 Tiếp nhận yêu cầu đặt lịch của khách hàng
- 🗓️ Lập lịch cho kỹ thuật viên, quản lý hàng chờ
- 📋 Quản lý phiếu tiếp nhận dịch vụ & checklist EV

#### c. Quản Lý Quy Trình Bảo Dưỡng
- 📊 Theo dõi tiến độ từng xe: chờ – đang làm – hoàn tất
- 📝 Ghi nhận tình trạng xe

#### d. Quản Lý Phụ Tùng
- 📦 Theo dõi số lượng phụ tùng EV tại trung tâm
- ⚠️ Kiểm soát lượng tồn phụ tùng tối thiểu
- 🤖 AI gợi ý nhu cầu phụ tùng thay thế để đề xuất lượng tồn phụ tùng tối thiểu cho trung tâm

#### e. Quản Lý Nhân Sự
- 👷 Phân công kỹ thuật viên theo ca/lịch
- 📈 Theo dõi hiệu suất, thời gian làm việc
- 🎓 Quản lý chứng chỉ chuyên môn EV

#### f. Quản Lý Tài Chính & Báo Cáo
- 🧾 Báo giá dịch vụ → hóa đơn → thanh toán (online/offline)
- 💹 Quản lý doanh thu, chi phí, lợi nhuận
- 📊 Thống kê loại dịch vụ phổ biến, xu hướng hỏng hóc EV

---

## 🏗️ Kiến Trúc Dự Án

Dự án được xây dựng theo kiến trúc **Layered Architecture** với các lớp:

```
├── EVOpsPro.BlazorWebApp.KhiemNVD/       # Ứng dụng Blazor WebAssembly (Frontend)
├── EVOpsPro.GraphQLWebAPI.KhiemNVD/      # GraphQL API Backend
├── EVOpsPro.Servcie.KhiemNVD/            # Lớp Service (Business Logic)
└── EVOpsPro.Repositories.KhiemNVD/       # Lớp Repository (Data Access)
```

### Các Thành Phần:

1. **EVOpsPro.MVCWebApp.KhiemNVD** - Ứng dụng Web MVC
   - Controllers: Xử lý yêu cầu từ client
   - Views: Giao diện người dùng (Razor/HTML)
   - Models: Định nghĩa dữ liệu

2. **EVOpsPro.WebAPI.KhiemNVD** - API Backend
   - Cung cấp các endpoint RESTful
   - Xử lý logic nghiệp vụ

3. **EVOpsPro.Servcie.KhiemNVD** - Business Logic Layer
   - Các service: ReminderKhiemNvdService, ReminderTypeKhiemNvdService, SystemUserAccountService
   - Đảm bảo toàn bộ logic nhắc nhở tập trung một nơi

4. **EVOpsPro.Repositories.KhiemNVD** - Data Access Layer
   - GenericRepository: Repository chung cho tất cả entities
   - Các repository cụ thể: ReminderKhiemNvdRepository, ReminderTypeKhiemNvdRepository, SystemUserAccountRepository
   - Tương tác với cơ sở dữ liệu

---

## 🛠️ Công Nghệ Sử Dụng

- **Framework**: ASP.NET Core 6+
- **Language**: C#
- **Frontend**: ASP.NET MVC (Razor)
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **API**: RESTful Web API
- **Architecture Pattern**: Repository Pattern, Service Layer Pattern

---

## 📁 Cấu Trúc File Quan Trọng

```
EVOpsPro.Repositories.KhiemNVD/
├── Models/
│   ├── CustomerVehicleTriNc.cs          # Entity hỗ trợ dữ liệu nhắc nhở
│   ├── VehicleTypeTriNc.cs              # Entity hỗ trợ dữ liệu nhắc nhở
│   ├── SystemUserAccount.cs             # Model tài khoản người dùng
│   ├── ReminderKhiemNvd.cs              # Model nhắc nhở
│   ├── ReminderTypeKhiemNvd.cs          # Model loại nhắc nhở
│   └── ... (các model khác)
├── Basic/
│   └── GenericRepository.cs             # Generic repository base
├── ReminderKhiemNvdRepository.cs
├── ReminderTypeKhiemNvdRepository.cs
├── SystemUserAccountRepository.cs
└── DBContext/
    └── FA25_PRN232_SE1713_G2_EVOpsProContext.cs  # DbContext chính

EVOpsPro.Servcie.KhiemNVD/
├── IReminderKhiemNvdService.cs
├── IReminderTypeKhiemNvdService.cs
├── ReminderKhiemNvdService.cs
├── ReminderTypeKhiemNvdService.cs
├── SystemUserAccountService.cs
└── ServiceProviders.cs

EVOpsPro.GraphQLWebAPI.KhiemNVD/
├── Program.cs
├── GraphQLs/
│   ├── Queries.cs
│   ├── Mutations.cs
│   └── Inputs/
│       ├── ReminderKhiemNvdInput.cs
│       └── ReminderTypeKhiemNvdInput.cs

EVOpsPro.BlazorWebApp.KhiemNVD/
├── GraphQLClient/
│   ├── AuthService.cs
│   └── GraphQLConsumer.cs
├── Models/
│   ├── ReminderKhiemNvd.cs
│   ├── ReminderTypeKhiemNvd.cs
│   └── SystemUserAccount.cs
└── Pages/
    ├── ReminderKhiemNvds/
    └── ReminderTypes/
```

---

## 🚀 Hướng Dẫn Chạy Dự Án

### Yêu Cầu Hệ Thống
- .NET 6.0 SDK trở lên
- SQL Server 2019 trở lên
- Visual Studio 2022 hoặc Visual Studio Code

### Cách Cài Đặt

1. **Clone repository** (nếu sử dụng Git)
   ```bash
   git clone <repository-url>
   cd FA25_PRN232_SE1713_ASM1_SE181729_KhiemNVD
   ```

2. **Cập nhật cơ sở dữ liệu**
   ```bash
   dotnet ef database update
   ```

3. **Cài đặt dependencies**
   ```bash
   dotnet restore
   ```

4. **Chạy ứng dụng**
   - **MVC App**: Chạy `EVOpsPro.MVCWebApp.KhiemNVD`
   - **API**: Chạy `EVOpsPro.WebAPI.KhiemNVD`

---

## 📊 Mô Hình Dữ Liệu Chính

### Các Entities Quan Trọng:

- **SystemUserAccount** - Tài khoản người dùng
- **CustomerVehicleTriNc** - Dữ liệu xe khách hàng (được lưu giữ để phục vụ Reminder)
- **ReminderKhiemNvd** - Nhắc nhở cho khách hàng
- **ReminderTypeKhiemNvd** - Loại nhắc nhở
- **AppointmentTrungDn** - Lịch hẹn dịch vụ
- **AppointmentStatusTrungDn** - Trạng thái lịch hẹn
- **MaintenanceProcessVietHq** - Quy trình bảo dưỡng
- **MaintenanceStepVietHq** - Các bước bảo dưỡng
- **PartDuongNm** - Phụ tùng
- **PartCategoryDuongNm** - Phân loại phụ tùng
- **ShiftKhoaPa** - Ca làm việc

---

## 📚 Tài Liệu Tham Khảo

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [RESTful API Best Practices](https://restfulapi.net/)
