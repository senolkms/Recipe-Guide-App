# 🍽 Recipe Guide App (Tarif Rehberi Uygulaması)

Bu proje, kullanıcının yemek tariflerini saklayabileceği ve **eldeki mevcut malzemelerle hangi yemeklerin yapılabileceğini gösteren** bir masaüstü uygulamasıdır.

---

## 📌 Özellikler

- 📝 **Tarif Ekleme:** Kullanıcı, tarifin adını, kategorisini, hazırlama süresini ve talimatlarını ekleyebilir. Tarif için malzemeler seçilebilir veya yeni malzeme eklenebilir.
- 🔍 **Tarif Arama:** Kullanıcı tarif adına veya malzemeye göre arama yapabilir.
- ✅ **Tarif Önerisi:** Eksik veya yetersiz malzemeli tarifler kırmızı, yapılabilir tarifler yeşil renkte gösterilir. Eksik malzemelerin maliyeti hesaplanır.
- 📊 **Filtreleme & Sıralama:** Kullanıcı tarifleri **hazırlama süresi, maliyet, malzeme sayısı ve kategoriye** göre filtreleyebilir ve sıralayabilir.
- 🖊 **Tarif Güncelleme & Silme:** Kullanıcı tarifleri düzenleyebilir veya silebilir. Değişiklikler anında veritabanına yansır.
- 🛑 **Duplicate Kontrolü:** Aynı tarifin tekrar eklenmesi engellenir.

---

## 🖥️ Kullanıcı Arayüzü (GUI)

- 📌 **Ana Sayfa:** Tüm tariflerin listelendiği bir alan
- 📋 **Menü:** Tarif ekleme, güncelleme ve silme işlemleri
- 🔍 **Arama & Filtreleme Alanı:** Tarif arama ve filtreleme seçenekleri
- ✅ **Sonuç Ekranı:** Kullanıcının mevcut malzemelerine uygun yemekleri listeler

---

## 🏗️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|-----------|---------|
| **C# (WinForms)** | Kullanıcı arayüzü |
| **MSSQL** | Veritabanı yönetimi |
| **Entity Framework** | ORM Kullanımı |
| **Git/GitHub** | Versiyon kontrolü |

---

## 📂 Veritabanı Yapısı

**1️⃣ Tarifler Tablosu**
- Tarif bilgilerini (isim, kategori, süre, talimatlar) içerir.

**2️⃣ Malzemeler Tablosu**
- Malzemelerin adını, miktarını ve birim fiyatını saklar.

**3️⃣ Tarif-Malzeme İlişkisi (Many-to-Many)**
- Tariflerde kullanılan malzemeleri ve miktarlarını ilişkilendirir.

---

## 📌 Kurulum & Kullanım

1. **Projeyi klonla**
   ```sh
   git clone https://github.com/senolkms/Recipe-Guide-App.git
   cd Recipe-Guide-App
