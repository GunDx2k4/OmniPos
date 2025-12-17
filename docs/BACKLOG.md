# Backlog & Roadmap [[VI](/docs/BACKLOG.VI.md)]

> This document contains the list of User Stories for the **OmniPos** project, broken down by Sprints and Epics.

## 📌 GitHub Management Conventions
* **EPIC** $\rightarrow$ Create **Milestone**.
* **USER STORY** $\rightarrow$ Create **Issue**.
* **SPRINT** $\rightarrow$ Use **Project Board** (Todo/In Progress columns).

---

## 🗺️ Development Roadmap

### Sprint 1: The Basic POS
**Goal:** Build the most fundamental sales flow. No login required, no inventory logic yet. The purpose is to **sell items and record revenue**.

| ID | User Story | Priority | Epic |
| :--- | :--- | :--- | :--- |
| **US-1.1** | **As a** Cashier (Default), **I want to** view the menu list (with Name, Price, Image), **so that** I can select items for customers. | **Critical** | POS |
| **US-1.2** | **As a** Cashier, **I want to** o manage the shopping cart (add, adjust quantity, remove) and see the total price calculated automatically, **so that** I can prepare the order for payment. | **Critical** | POS |
| **US-1.3** | **As a** Cashier, **I want to** click the "Checkout" button, **so that** I can save the order to the Database and reset the screen for a new sale. | **Critical** | POS |
| **US-1.4** | **As a** Store Owner, **I want to** view the history list of orders sold today, **so that** I know the daily sales volume. | **Critical** | Report |

---

### Sprint 2: Staff & Roles
**Goal:** Access control. Define clearly "Who is selling?" and "Who is managing?".

| ID | User Story | Priority | Epic |
| :--- | :--- | :--- | :--- |
| **US-2.1** | **As an** Admin, **I want to** create accounts for employees (Name, PIN, Role), **so that** I can grant access rights. | High | System |
| **US-2.2** | **As a** Cashier, **I want to** login using a **4-digit PIN**, **so that** I can start my shift quickly. | High | System |
| **US-2.3** | **As a** Cashier, **I want to** login by **Scanning a QR Code** (on the POS machine), **so that** attendance check-in is convenient. | Medium | System |
| **US-2.4** | **As the** System, **I want to** block employees (Role: Staff) from accessing Configuration/Cost pages, **so that** sensitive data is secured. | **Critical** | Security |
| **US-2.5** | **As an** Admin, **I want** the revenue report to clearly show who sold which order, **so that** I can calculate bonuses or penalties. | Medium | Report |

---

### Sprint 3: Inventory & Recipe
**Goal:** Quantitative control. Solve the problem: "Selling 1 cup of coffee consumes how many beans?".

| ID | User Story | Priority | Epic |
| :--- | :--- | :--- | :--- |
| **US-3.1** | **As an** Admin, **I want to** manage the Ingredient list (Name, Unit: g, ml), **so that** I can track inventory. | High | Inventory |
| **US-3.2** | **As an** Admin, **I want to** set up **Recipes** for items (e.g., 1 Latte = 20g Coffee + 30ml Condensed Milk), **so that** I can define the Cost of Goods Sold. | **Critical** | Recipe |
| **US-3.3** | **As an** Admin, **I want to** input inbound stock when goods arrive, **so that** I can increase the inventory count in the system. | High | Inventory |
| **US-3.4** | **As the** System, **I want to** automatically deduct corresponding ingredients immediately when an order is paid (at POS), **so that** the digital stock matches physical reality. | **Critical** | Inventory |
| **US-3.5** | **As an** Admin, **I want to** view the **Gross Profit** report (Revenue - COGS) in real-time. | Medium | Report |

---

### Sprint 4: Advanced Operations
**Goal:** Optimize customer experience and professional operations.

| ID | User Story | Priority | Epic |
| :--- | :--- | :--- | :--- |
| **US-4.1** | **As a** Cashier, **I want to** view a visual **Table Map** (Green/Red/Yellow), **so that** I know which tables are empty or waiting for food. | High | POS |
| **US-4.2** | **As a** Cashier, **I want to** add Notes to items (less ice, no sugar), **so that** they print on the Kitchen Ticket. | Medium | POS |
| **US-4.3** | **As a** Cashier, **I want to** print the Receipt on a thermal printer (80mm size), **so that** I can give it to the customer. | Medium | Hardware |
| **US-4.4** | **As the** System, **I want to** send Real-time notifications when the kitchen finishes a dish, **so that** servers know to deliver it. | Low | System |
