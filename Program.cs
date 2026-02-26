using System;
using System.Collections.Generic;

class Program
{
    // Otel bilgileri
    static int toplamOda = 80;
    static Dictionary<int, string> odaDurumlari = new Dictionary<int, string>();
    static Dictionary<int, string> odaMusterileri = new Dictionary<int, string>();
    static List<string> bildirimler = new List<string>();

    // Bar Menüsü
    static Dictionary<string, double> barMenu = new Dictionary<string, double>()
    {
        {"1. Kola", 50},
        {"2. Su", 20},
        {"3. Meyve Suyu", 60},
        {"4. Bira", 120},
        {"5. Şarap (Kadeh)", 150},
        {"6. Viski", 200},
        {"7. Kokteyl", 180},
        {"8. Çay", 30},
        {"9. Kahve", 40},
        {"10. Cappuccino", 70}
    };

    // Restaurant Menüsü
    static Dictionary<string, double> restaurantMenu = new Dictionary<string, double>()
    {
        {"1. Kahvaltı Tabağı", 250},
        {"2. Izgara Tavuk", 350},
        {"3. Izgara Balık", 400},
        {"4. Et Şiş", 450},
        {"5. Makarna", 280},
        {"6. Salata", 150},
        {"7. Çorba", 120},
        {"8. Pizza", 320},
        {"9. Burger", 290},
        {"10. Tatlı Tabağı", 180}
    };

    static void Main(string[] args)
    {
        // Odaları başlat
        for (int i = 1; i <= toplamOda; i++)
        {
            odaDurumlari[i] = "Boş";
            odaMusterileri[i] = "";
        }

        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║     OTEL ODA SERVİSİ SİSTEMİ       ║");
        Console.WriteLine("║         Hoş Geldiniz! 🏨            ║");
        Console.WriteLine("╚════════════════════════════════════╝");

        bool devam = true;
        while (devam)
        {
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║           ANA MENÜ                 ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine("║  1. Müşteri Girişi (Check-in)      ║");
            Console.WriteLine("║  2. Müşteri Çıkışı (Check-out)     ║");
            Console.WriteLine("║  3. Oda Servisi                    ║");
            Console.WriteLine("║  4. Bildirimler (Resepsiyon)       ║");
            Console.WriteLine("║  5. Oda Durumları                  ║");
            Console.WriteLine("║  0. Çıkış                          ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    CheckIn();
                    break;
                case "2":
                    CheckOut();
                    break;
                case "3":
                    OdaServisi();
                    break;
                case "4":
                    BildirimleriGoster();
                    break;
                case "5":
                    OdaDurumlariniGoster();
                    break;
                case "0":
                    devam = false;
                    Console.WriteLine("\nSistemi kapanıyor... Güle güle! 👋");
                    break;
                default:
                    Console.WriteLine("❌ Geçersiz seçim!");
                    break;
            }
        }
    }

    static void CheckIn()
    {
        Console.WriteLine("\n=== MÜŞTERİ GİRİŞİ ===");
        Console.Write("Oda numarası (1-80): ");
        int odaNo = Convert.ToInt32(Console.ReadLine());

        if (odaNo < 1 || odaNo > 80)
        {
            Console.WriteLine("❌ Geçersiz oda numarası!");
            return;
        }

        if (odaDurumlari[odaNo] == "Dolu")
        {
            Console.WriteLine($"❌ {odaNo} numaralı oda zaten dolu!");
            return;
        }

        Console.Write("Müşteri adı soyadı: ");
        string musteriAdi = Console.ReadLine();

        odaDurumlari[odaNo] = "Dolu";
        odaMusterileri[odaNo] = musteriAdi;

        Console.WriteLine($"✅ {musteriAdi} - {odaNo} numaralı odaya giriş yaptı.");
        bildirimler.Add($"[CHECK-IN] Oda {odaNo} - {musteriAdi} giriş yaptı.");
    }

    static void CheckOut()
    {
        Console.WriteLine("\n=== MÜŞTERİ ÇIKIŞI ===");
        Console.Write("Oda numarası (1-80): ");
        int odaNo = Convert.ToInt32(Console.ReadLine());

        if (odaNo < 1 || odaNo > 80)
        {
            Console.WriteLine("❌ Geçersiz oda numarası!");
            return;
        }

        if (odaDurumlari[odaNo] == "Boş")
        {
            Console.WriteLine($"❌ {odaNo} numaralı oda zaten boş!");
            return;
        }

        string musteriAdi = odaMusterileri[odaNo];
        odaDurumlari[odaNo] = "Boş";
        odaMusterileri[odaNo] = "";

        Console.WriteLine($"✅ {musteriAdi} - {odaNo} numaralı odadan çıkış yaptı.");
        bildirimler.Add($"[CHECK-OUT] Oda {odaNo} - {musteriAdi} çıkış yaptı.");
    }

    static void OdaServisi()
    {
        Console.WriteLine("\n=== ODA SERVİSİ ===");
        Console.Write("Lütfen oda numaranızı giriniz (1-80): ");
        int odaNo = Convert.ToInt32(Console.ReadLine());

        if (odaNo < 1 || odaNo > 80)
        {
            Console.WriteLine("❌ Geçersiz oda numarası!");
            return;
        }

        if (odaDurumlari[odaNo] == "Boş")
        {
            Console.WriteLine($"❌ {odaNo} numaralı odada kayıtlı müşteri bulunmuyor!");
            return;
        }

        Console.WriteLine($"\nHoş geldiniz, {odaMusterileri[odaNo]}!");
        Console.WriteLine("\n╔════════════════════════════════════╗");
        Console.WriteLine("║         HİZMET MENÜSÜ              ║");
        Console.WriteLine("╠════════════════════════════════════╣");
        Console.WriteLine("║  1. 🍸 Otel Bar                    ║");
        Console.WriteLine("║  2. 🍽️  Otel Restaurant             ║");
        Console.WriteLine("║  3. 🧹 Oda Temizliği               ║");
        Console.WriteLine("║  4. 🛎️  Özel İstek                  ║");
        Console.WriteLine("║  0. Geri                           ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.Write("Seçiminiz: ");

        string secim = Console.ReadLine();

        switch (secim)
        {
            case "1":
                BarSiparis(odaNo);
                break;
            case "2":
                RestaurantSiparis(odaNo);
                break;
            case "3":
                OdaTemizligi(odaNo);
                break;
            case "4":
                OzelIstek(odaNo);
                break;
            case "0":
                break;
            default:
                Console.WriteLine("❌ Geçersiz seçim!");
                break;
        }
    }

    static void BarSiparis(int odaNo)
    {
        Console.WriteLine("\n=== 🍸 BAR MENÜSÜ ===");
        foreach (var item in barMenu)
        {
            Console.WriteLine($"{item.Key} - {item.Value} TL");
        }

        Console.Write("\nSiparişinizi yazın (ürün adı): ");
        string siparis = Console.ReadLine();
        double tutar = 0;

        foreach (var item in barMenu)
        {
            if (item.Key.ToLower().Contains(siparis.ToLower()))
            {
                tutar = item.Value;
                siparis = item.Key;
                break;
            }
        }

        if (tutar > 0)
        {
            string bildirim = $"[BAR SİPARİŞİ] Oda {odaNo} - {siparis} - {tutar} TL";
            bildirimler.Add(bildirim);
            Console.WriteLine($"✅ Siparişiniz alındı! {siparis} - {tutar} TL");
            Console.WriteLine("🚀 En kısa sürede odanıza teslim edilecektir.");
        }
        else
        {
            Console.WriteLine("❌ Ürün bulunamadı!");
        }
    }

    static void RestaurantSiparis(int odaNo)
    {
        Console.WriteLine("\n=== 🍽️ RESTAURANT MENÜSÜ ===");
        foreach (var item in restaurantMenu)
        {
            Console.WriteLine($"{item.Key} - {item.Value} TL");
        }

        Console.Write("\nSiparişinizi yazın (ürün adı): ");
        string siparis = Console.ReadLine();
        double tutar = 0;

        foreach (var item in restaurantMenu)
        {
            if (item.Key.ToLower().Contains(siparis.ToLower()))
            {
                tutar = item.Value;
                siparis = item.Key;
                break;
            }
        }

        if (tutar > 0)
        {
            string bildirim = $"[RESTAURANT SİPARİŞİ] Oda {odaNo} - {siparis} - {tutar} TL";
            bildirimler.Add(bildirim);
            Console.WriteLine($"✅ Siparişiniz alındı! {siparis} - {tutar} TL");
            Console.WriteLine("🚀 En kısa sürede odanıza teslim edilecektir.");
        }
        else
        {
            Console.WriteLine("❌ Ürün bulunamadı!");
        }
    }

    static void OdaTemizligi(int odaNo)
    {
        Console.WriteLine("\n=== 🧹 ODA TEMİZLİĞİ ===");
        Console.WriteLine("Temizlik talebiniz resepsiyona iletildi.");
        Console.Write("Tercih ettiğiniz saat (örn: 14:00): ");
        string saat = Console.ReadLine();

        string bildirim = $"[TEMİZLİK TALEBİ] Oda {odaNo} - Saat: {saat}";
        bildirimler.Add(bildirim);
        Console.WriteLine($"✅ Temizlik talebiniz {saat} için alındı. Teşekkürler!");
    }

    static void OzelIstek(int odaNo)
    {
        Console.WriteLine("\n=== 🛎️ ÖZEL İSTEK ===");
        Console.Write("İsteğinizi yazınız: ");
        string istek = Console.ReadLine();

        string bildirim = $"[ÖZEL İSTEK] Oda {odaNo} - {istek}";
        bildirimler.Add(bildirim);
        Console.WriteLine("✅ İsteğiniz resepsiyona iletildi. En kısa sürede yardımcı olunacaktır.");
    }

    static void BildirimleriGoster()
    {
        Console.WriteLine("\n=== 📋 BİLDİRİMLER (RESEPSİYON) ===");
        if (bildirimler.Count == 0)
        {
            Console.WriteLine("Henüz bildirim yok.");
            return;
        }

        for (int i = 0; i < bildirimler.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {bildirimler[i]}");
        }
    }

    static void OdaDurumlariniGoster()
    {
        Console.WriteLine("\n=== 🏨 ODA DURUMLARI ===");
        int dolu = 0, bos = 0;

        for (int i = 1; i <= toplamOda; i++)
        {
            string durum = odaDurumlari[i] == "Dolu" ? "🔴 Dolu" : "🟢 Boş";
            Console.WriteLine($"Oda {i,2}: {durum}" + (odaDurumlari[i] == "Dolu" ? $" - {odaMusterileri[i]}" : ""));
            if (odaDurumlari[i] == "Dolu") dolu++;
            else bos++;
        }

        Console.WriteLine($"\n📊 Toplam: {toplamOda} oda | 🔴 Dolu: {dolu} | 🟢 Boş: {bos}");
    }
}