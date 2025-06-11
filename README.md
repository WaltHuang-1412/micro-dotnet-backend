# micro-dotnet-backend

這是一個使用 **.NET 8 Web API** 架構的後端登入驗證範例，包含：
- 使用者登入（含假資料驗證）
- JWT Token 產生與回傳
- 支援設定檔與依賴注入
- 可配合 Docker、CI/CD 使用

---

## 🧰 CLI 指令速查

### 📦 建立專案
```bash
dotnet new webapi -n micro-dotnet-backend
```

### 📂 建立 Controller / Model / Service
```bash
# 建立 Controller
dotnet new controller -n AuthController --output Controllers

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