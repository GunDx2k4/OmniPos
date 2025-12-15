# OmniPos - SME F&B Management System [[VI](./README.VI.md)]

![Status](https://img.shields.io/badge/Status-In%20Development-yellow?style=flat-square)
![License](https://img.shields.io/badge/License-Apache%202.0-blue?style=flat-square)
![Backend](https://img.shields.io/badge/Backend-.NET%209-purple?style=flat-square)
![Frontend](https://img.shields.io/badge/Frontend-Vue.js%203-green?style=flat-square)

> **Note:** This is a personal project developed for educational purposes. The features are built based on real-world operational insights.

---

## 🎯 Product Vision

* **For:** Cafe owners, Tea shops, and small-to-medium F&B chains.
* **Who:** Are seeking a **comprehensive synchronized solution**: Ensuring maximum operational efficiency at the Point of Sale (POS), while providing an **in-depth management system** for cash flow, Cost of Goods Sold (COGS), and staff productivity in real-time.
* **OmniPos is:** A unified F&B management platform.
* **That:** Optimizes sales workflows (Ordering/Payment) and automates complex managerial accounting tasks.
* **Unlike:** Traditional fragmented POS systems that lack tight integration between sales revenue and operational costs.

---

## 🚀 Key Features

### 1. Smart POS Operations
* **Optimized Service Speed:** Streamlined touch interface designed to handle **peak hour traffic**, allowing cashiers to complete orders in seconds with minimal taps.
* **Real-time Floor Management:** A dynamic dashboard providing instant visibility of table occupancy and order fulfillment status (Waiting/Served), ensuring seamless staff coordination without manual checks.

### 2. Inventory & Recipe Engine
* **Precise Cost Control:** Advanced **Bill of Materials (BOM)** management allows defining complex recipes (e.g., *1 Coffee = 20g Beans + 30ml Milk*), enabling accurate **Cost of Goods Sold (COGS)** tracking.
* **Automated Stock Deduction:** Inventory is automatically calculated and deducted immediately upon transaction completion, maintaining strict **consistency** between Cash Flow and Physical Stock.

### 3. Security & Staff Efficiency
* **Seamless Access:** Rapid **passwordless login** via QR Code scanning on the POS device, integrated with automated time-attendance tracking.
* **Strict Access Control:** Comprehensive **Role-Based Access Control (RBAC)** ensures sensitive data (like Purchase Prices) is visible only to authorized personnel (Admin), preventing internal data leaks.

---

## 🛠️ Tech Stack & Architecture

I implemented **Clean Architecture (Layered)** to ensure scalability and maintainability.

| Layer | Technology | Details |
| :--- | :--- | :--- |
| **Backend** | .NET 9 | ASP.NET Core Web API, Entity Framework Core. |
| **Frontend** | Vue.js 3 | Composition API, Vite, Tailwind CSS. |
| **Database** | SQL Server | ACID Transactions used to ensure data integrity. |

---

## 🗺️ Development Roadmap

This project is managed via **Agile/Kanban** on GitHub Projects.

👉 **[VIEW PROJECT BOARD HERE]()**

- [ ] **Sprint 1: The Basic POS** [Details](/docs/BACKLOG.md#sprint-1-the-basic-pos)
    - **Goal:** Replace manual logbooks with a digital ordering system.
    - **Deliverables:**
        - Digital Menu (View item list).
        - Basic Sales Function (Add to cart, Checkout).
        - Order History & Total Revenue recording.
    - *Note:* No login required (Default Admin).
- [ ] **Sprint 2: Staff Management & RBAC** [Details](/docs/BACKLOG.md#sprint-2-staff--roles)
    - **Goal:** Control "Who is selling?" and secure sensitive data.
    - **Deliverables:**
        - Login Features (QR Code / PIN).
        - Role-Based Access Control (RBAC): Cashiers can only sell; Admins can edit prices/reports.
        - Sales Reports by Staff.
- [ ] **Sprint 3: Inventory & Quantitative Logic** [Details](/docs/BACKLOG.md#sprint-3-inventory--recipe)
    - **Goal:** Control "What is sold vs. Profit margin".
    - **Deliverables:**
        - Ingredient Management & Inbound.
        - Recipe Setup (BOM).
        - Auto-deduction upon sales.
        - Gross Profit Report.
- [ ] **Sprint 4: Advanced Operations** [Details](/docs/BACKLOG.md#sprint-4-advanced-operations)
    - **Goal:** Optimize customer experience.
    - **Deliverables:**
        - Real-time Table Map (Occupancy status).
        - Thermal Receipt Printing.
        - Split/Merge Tables.