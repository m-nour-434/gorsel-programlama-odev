
# Kullanici Bilgi Uygulaması

Bu proje, bir kullanıcının bilgilerini alarak burcunu, vücut kitle indeksini (VKİ) hesaplayan ve SQL Server veritabanına kaydeden bir C# Windows Forms uygulamasıdır.

## 🔧 Özellikler

- Kullanıcıdan:
  - Ad, Soyad
  - Doğum günü (Gün, Ay, Yıl)
  - Boy ve Kilo bilgileri alınır.
- Doğum tarihine göre burç hesaplanır ve yorum yapılır.
- Boy ve kilo bilgilerine göre VKİ hesaplanır ve yorum yapılır.
- Sonuçlar ekranda gösterilir ve veritabanına kaydedilir.
- Burç görseli ekranda gösterilir (örnek: `burclar/yengeç.jpg`).

## 💾 Veritabanı

Veritabanı dosyası: `KullaniciDB.mdf`

**Tablo adı:** `KullaniciBilgileri`

**Alanlar:**
- Ad
- Soyad
- Gün
- Ay
- Yıl
- Burç
- BurçYorum
- VKI
- VKIYorum

## 🔌 Gereksinimler

- Visual Studio 2022 veya üzeri
- .NET Framework (örneğin: 4.7.2)
- SQL Server Express (LocalDB)
- `KullaniciDB.mdf` dosyasının `Copy to Output Directory` özelliği `Copy if newer` olarak ayarlanmalıdır.

## 🚀 Kullanım

1. Projeyi Visual Studio'da açın.
2. `KullaniciDB.mdf` dosyasını **proje dizinine** koyun ve özelliklerinden `Copy if newer` olarak ayarlayın.
3. `burclar` klasörünü oluşturun ve burç resimlerini içine ekleyin (`jpg` formatında).
4. `Form1.cs` içinde gerekli alanlara bilgileri girin ve "Kaydet" butonuna tıklayın.
5. Bilgiler ekranda ve veritabanında görüntülenecektir.

## 📁 Örnek Klasör Yapısı

```
ProjeKlasörü/
│
├── KullaniciDB.mdf
├── KullaniciDB_log.ldf
├── burclar/
│   ├── kova.jpg
│   ├── yengeç.jpg
│   ├── aslan.jpg
│   └── ...
├── Form1.cs
├── Form1.Designer.cs
├── Program.cs
└── README.md
```

## 📷 Not

Burç resimlerini `burclar` klasöründe `burc_adi.jpg` formatında kaydedin. Örneğin:
- `aslan.jpg`
- `kova.jpg`

> Görsellerin yolu: `burclar/{burc_adi}.jpg` şeklinde tanımlıdır.
