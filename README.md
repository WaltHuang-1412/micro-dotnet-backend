# micro-dotnet-backend

## 專案簡介

這是一個基於 .NET 9 的 Web API 範例，支援 JWT 驗證、Swagger 文件、Entity Framework Core ORM 及 Migration。

---

## 目錄結構

```
├── Controllers/         # API 控制器
├── Models/              # 資料模型
├── Services/            # 業務邏輯服務
├── Data/                # 資料存取層（DbContext、Migration）
├── Program.cs           # 應用程式入口
├── appsettings.json     # 設定檔
├── micro-dotnet-backend.csproj # 專案檔案
```

---

## 開發環境需求
- .NET 9 SDK
- SQL Server（或其他支援的資料庫）
- Docker（可選）

---

## EF Core 安裝與 Migration 操作

### 1. 安裝 EF Core 套件

```bash
# 安裝核心與 SQL Server 支援
 dotnet add package Microsoft.EntityFrameworkCore
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer
 dotnet add package Microsoft.EntityFrameworkCore.Tools
 dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 2. 安裝 EF Core CLI 工具（如尚未安裝）
```bash
dotnet tool install --global dotnet-ef
```

### 3. 建立 Migration
```bash
dotnet ef migrations add InitialCreate
```

### 4. 更新資料庫
```bash
dotnet ef database update
```

---

## 啟動專案

```bash
dotnet run
```

- API 會預設監聽 `http://localhost:5000` 及 `https://localhost:5001`
- Swagger UI: `https://localhost:5001/swagger`

---

## Docker 運行

```bash
docker-compose up --build
```

---

## 其他說明
- 若需修改資料庫結構，請修改 Model 並重新建立 migration。
- migration 相關檔案會自動產生於 `Data/Migrations/` 目錄。
- 如需更多 migration 指令，請參考 [官方文件](https://learn.microsoft.com/ef/core/cli/dotnet)

---

## 🧰 CLI 指令速查（.NET 9）

### 📦 建立專案

```bash
dotnet new webapi -n micro-dotnet-backend
```

### 📂 建立 Controller / Model / Service

```bash
# 建立 API Controller（適用 .NET 9）
dotnet new apicontroller -n AuthController --output Controllers

# 建立類別（如 JwtSettings）
dotnet new class -n JwtSettings --output Models

# 建立介面（IAuthService）
dotnet new interface -n IAuthService --output Services

# 建立實作類別
dotnet new class -n AuthService --output Services
```

### 🧪 啟動開發伺服器

```bash
cd micro-dotnet-backend

dotnet watch run
```

訪問 Swagger UI：`http://localhost:5000/swagger`

---

## 🔧 專案結構建議

```plaintext
micro-dotnet-backend/
├── Controllers/
│   └── AuthController.cs
├── Models/
│   ├── LoginRequest.cs
│   └── JwtSettings.cs
├── Services/
│   ├── IAuthService.cs
│   └── AuthService.cs
├── appsettings.json
├── Program.cs
├── micro-dotnet-backend.csproj
└── .gitignore
```

---

## 🔐 JWT 設定範例（appsettings.json）

```json
"Jwt": {
  "Key": "super-secret-key",
  "Issuer": "micro-dotnet-backend",
  "Audience": "frontend-app",
  "ExpiryInMinutes": 60
}
```

---

## 🧾 License

MIT
