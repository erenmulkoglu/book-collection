# Kitap Koleksiyonum

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square&logo=dotnet)
![Angular](https://img.shields.io/badge/Angular-20-DD0031?style=flat-square&logo=angular)
![MSSQL](https://img.shields.io/badge/MSSQL-Server-CC2927?style=flat-square&logo=microsoft-sql-server)


## Özellikler

-  Kitap ekleme, düzenleme ve silme (CRUD)
-  Kategorilere göre kitap yönetimi
-  Okuma durumu takibi (Okunacak, Okunuyor, Okundu)
-  5 yıldızlı değerlendirme sistemi
-  Okuma durumuna göre filtreleme
-  Responsive tasarım
-  Modern ve kullanıcı dostu arayüz



## Teknolojiler


### Backend
- **.NET 10** - Web API
- **Entity Framework Core 10** - ORM
- **MSSQL Server** - Veritabanı
- **Swagger** - API Dokümantasyonu

### Frontend
- **Angular 20** - Standalone Components
- **TypeScript** - Tip güvenli JavaScript
- **RxJS** - Reactive Programming
- **CSS3** - Modern styling

### Mimari & Pattern'ler
- RESTful API
- DTO (Data Transfer Object) Pattern
- Repository Pattern
- Dependency Injection
- CORS yapılandırması



##  Kullanım

### Kitap Ekleme
1. Ana sayfada **"+ Yeni Kitap Ekle"** butonuna tıklayın
2. Formu doldurun (Kitap Adı, Yazar, Kategori zorunludur)
3. **"Kaydet"** butonuna tıklayın

### Kitap Düzenleme
1. Kitap kartındaki **"Düzenle"** butonuna tıklayın
2. İstediğiniz alanları güncelleyin
3. **"Güncelle"** butonuna tıklayın

### Kitap Silme
1. Kitap kartındaki **"Sil"** butonuna tıklayın
2. Onay dialogunda **"Tamam"** seçin

### Filtreleme
- **Tümü**: Tüm kitapları gösterir
- **Okunacak**: Henüz okunmamış kitaplar
- **Okunuyor**: Şu anda okunan kitaplar
- **Okundu**: Tamamlanan kitaplar


##  Kurulum

### Gereksinimler

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js 18+](https://nodejs.org/)
- [Angular CLI 20](https://angular.io/cli)
- [SQL Server](https://www.microsoft.com/sql-server)

### Backend Kurulumu

1. **Projeyi klonlayın:**
```bash
cd KitapKoleksiyonum.API
```

2. **Bağımlılıkları yükleyin:**
```bash
dotnet restore
```

3. **Connection String'i düzenleyin:**

`appsettings.json` dosyasında SQL Server bağlantı ayarlarını yapın:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=KitapKoleksiyonumDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

4. **Veritabanını oluşturun:**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. **Uygulamayı çalıştırın:**
```bash
dotnet run
```

Backend: `http://localhost:5116`  
Swagger: `http://localhost:5116/swagger`

---

### Frontend Kurulumu

1. **Projeye gidin:**
```bash
cd KitapKoleksiyonum.UI
```

2. **Bağımlılıkları yükleyin:**
```bash
npm install
```

3. **Uygulamayı çalıştırın:**
```bash
ng serve
```

Frontend: `http://localhost:4200`



## Proje Yapısı
```
KitapKoleksiyonum/
├── KitapKoleksiyonum.API/          # Backend (.NET 10)
│   ├── Controllers/                # API Controllers
│   │   ├── BooksController.cs
│   │   └── CategoriesController.cs
│   ├── Data/                       # Database Context
│   │   ├── AppDbContext.cs
│   │   └── AppDbContextFactory.cs
│   ├── DTOs/                       # Data Transfer Objects
│   │   └── BookDto.cs
│   ├── Models/                     # Entity Models
│   │   ├── Book.cs
│   │   └── Category.cs
│   ├── Migrations/                 # EF Core Migrations
│   ├── Program.cs                  # Entry Point
│   └── appsettings.json           # Configuration
│
└── KitapKoleksiyonum.UI/           # Frontend (Angular 20)
    ├── src/
    │   ├── app/
    │   │   ├── components/         # Angular Components
    │   │   │   ├── book-list/
    │   │   │   ├── book-form/
    │   │   │   └── category-list/
    │   │   ├── models/             # TypeScript Interfaces
    │   │   │   ├── book.model.ts
    │   │   │   └── category.model.ts
    │   │   ├── services/           # API Services
    │   │   │   ├── book.service.ts
    │   │   │   └── category.service.ts
    │   │   ├── app.component.ts
    │   │   ├── app.routes.ts
    │   │   └── app.config.ts
    │   ├── styles.css              # Global Styles
    │   └── index.html
    └── package.json
```





##  Ekran Görüntüleri

### Ana Sayfa
![Ana Sayfa](screenshots/home.png)

### Kitap Ekleme/Düzenleme Formu
![Form](screenshots/form.png)

### Swagger API Dokümantasyonu
![Swagger](screenshots/swagger.png)
