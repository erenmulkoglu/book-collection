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
