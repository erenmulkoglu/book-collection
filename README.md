# Kitap Koleksiyonum

Kişisel kitap koleksiyonunuzu yönetmek için geliştirilmiş modern, full-stack web uygulaması.

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



## Kurulum

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



## API Endpoints

### Books

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/books` | Tüm kitapları listele |
| GET | `/api/books/{id}` | ID'ye göre kitap getir |
| POST | `/api/books` | Yeni kitap ekle |
| PUT | `/api/books/{id}` | Kitap güncelle |
| DELETE | `/api/books/{id}` | Kitap sil |

### Categories

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/categories` | Tüm kategorileri listele |
| GET | `/api/categories/{id}` | ID'ye göre kategori getir |
| POST | `/api/categories` | Yeni kategori ekle |
| PUT | `/api/categories/{id}` | Kategori güncelle |
| DELETE | `/api/categories/{id}` | Kategori sil |

### Örnek Request (POST /api/books)
```json
{
  "title": "1984",
  "author": "George Orwell",
  "isbn": "978-0451524935",
  "pageCount": 328,
  "publishDate": "1949-06-08T00:00:00.000Z",
  "status": 2,
  "rating": 5,
  "notes": "Distopik bir başyapıt",
  "categoryId": 1
}
```

### Örnek Response
```json
{
  "id": 1,
  "title": "1984",
  "author": "George Orwell",
  "isbn": "978-0451524935",
  "pageCount": 328,
  "publishDate": "1949-06-08T00:00:00",
  "status": 2,
  "rating": 5,
  "notes": "Distopik bir başyapıt",
  "categoryId": 1,
  "categoryName": "Roman",
  "createdAt": "2024-11-19T10:30:00"
}
```



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




## Ekran Görüntüleri

### Ana Sayfa
<img width="1905" height="1005" alt="image" src="https://github.com/user-attachments/assets/13c13b42-584d-49f8-92d4-22a0fa143cbd" />
<img width="1542" height="1001" alt="image" src="https://github.com/user-attachments/assets/de203e38-791b-48b4-8d12-3bf08332cfc0" />
<img width="1540" height="1002" alt="image" src="https://github.com/user-attachments/assets/fe740f67-32d8-4686-9d75-e8827330de4b" />
<img width="1538" height="1002" alt="image" src="https://github.com/user-attachments/assets/a7ef378b-8d56-476e-93cb-120fdf201896" />


### Kitap Ekleme/Düzenleme Formu
<img width="1915" height="999" alt="image" src="https://github.com/user-attachments/assets/293f1ccc-7348-43ff-a2f9-adf9b283d484" />

### Swagger API Dokümantasyonu
<img width="1540" height="1001" alt="image" src="https://github.com/user-attachments/assets/a10bb1be-ef29-4693-8a00-341c438671e5" />




## Veritabanı Şeması

### Books Tablosu
| Sütun | Tip | Açıklama |
|-------|-----|----------|
| Id | int | Primary Key |
| Title | nvarchar(200) | Kitap adı |
| Author | nvarchar(150) | Yazar |
| ISBN | nvarchar(20) | ISBN numarası |
| PageCount | int | Sayfa sayısı |
| PublishDate | datetime2 | Yayın tarihi |
| Status | int | Okuma durumu (0-2) |
| Rating | int | Değerlendirme (1-5) |
| Notes | nvarchar(1000) | Notlar |
| CategoryId | int | Foreign Key |
| CreatedAt | datetime2 | Oluşturma tarihi |

### Categories Tablosu
| Sütun | Tip | Açıklama |
|-------|-----|----------|
| Id | int | Primary Key |
| Name | nvarchar(100) | Kategori adı |
| Description | nvarchar(500) | Açıklama |




## CORS Yapılandırması

Backend, frontend'den gelen isteklere izin vermek için CORS yapılandırması içerir:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
```




## Sorun Giderme

### Backend çalışmıyor
- SQL Server'ın çalıştığından emin olun
- Connection string'i kontrol edin
- Migration'ları çalıştırın: `dotnet ef database update`

### Frontend çalışmıyor
- Node.js ve Angular CLI'ın yüklü olduğundan emin olun
- `npm install` komutunu çalıştırın
- Backend'in çalıştığından emin olun

### CORS hatası alıyorum
- Backend'de CORS policy'nin doğru yapılandırıldığından emin olun
- Frontend URL'inin `http://localhost:4200` olduğundan emin olun




## Geliştirme İçin Notlar

- Backend varsayılan olarak port **5116** üzerinde çalışır
- Frontend varsayılan olarak port **4200** üzerinde çalışır
- Swagger UI: `http://localhost:5116/swagger`
- Hot reload her iki tarafta da aktif




## Lisans

Bu proje eğitim amaçlı geliştirilmiştir.



## Geliştirici

**Eren Mülkoğlu** - Senior Software Engineer




## Teşekkürler


**Projeyi beğendiyseniz yıldız vermeyi unutmayın!**
