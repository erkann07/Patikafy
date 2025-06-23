

using System.Text.RegularExpressions;

public class Sanatci
{
    public string TamAd { get; set; }
    public string MuzikTuru { get; set; }
    public int CikisYili { get; set; }
    public int Satis { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Sanatci> sanatcis = new List<Sanatci>
        {
            new Sanatci { TamAd = "Ajda Pekkan", MuzikTuru = "Pop", CikisYili = 1968, Satis = 20 },
            new Sanatci { TamAd = "Sezen Aksu", MuzikTuru = "Pop", CikisYili = 1971, Satis = 10 },
            new Sanatci { TamAd = "Funda Arar", MuzikTuru = "Pop", CikisYili = 1999, Satis = 3 },
            new Sanatci { TamAd = "Sertab Erener", MuzikTuru = "Rap", CikisYili = 1994, Satis = 5 },
            new Sanatci { TamAd = "Sıla", MuzikTuru = "Pop", CikisYili = 2009, Satis = 3 },
            new Sanatci { TamAd = "Serdar Ortaç", MuzikTuru = "Pop", CikisYili = 1994, Satis = 10 },
            new Sanatci { TamAd = "Tarkan", MuzikTuru = "Rock", CikisYili = 1992, Satis = 40 },
            new Sanatci { TamAd = "Hande Yener", MuzikTuru = "Rock", CikisYili = 1999, Satis = 7 },
            new Sanatci { TamAd = "Hadise", MuzikTuru = "Pop", CikisYili = 2005, Satis = 5 },
            new Sanatci { TamAd = "Gülben Ergen", MuzikTuru = "Pop", CikisYili = 1997, Satis = 10 },
            new Sanatci { TamAd = "Neşet Ertaş", MuzikTuru = "Türk Halk Müziği", CikisYili = 1960, Satis = 2 },
        };
        var startS = sanatcis.Where(sanatcis => sanatcis.TamAd.StartsWith("S"));

        Console.WriteLine("----- ADI 'S' İLE BAŞLAYANLAR -----");
        foreach (var s in startS)
        {
            Console.WriteLine(s.TamAd);
        }
        Console.WriteLine("----- ALBÜM SATIŞI 10 MİLYONUN ÜZERİNDE OLANLAR -----");
        var satis10 = sanatcis.Where(sanatcis => sanatcis.Satis > 10);
        foreach (var x in satis10)
        {
            Console.WriteLine(x.TamAd);
        }
        Console.WriteLine("----- 2000 YILI ÖNCESİ POP ŞARKICILARI -----");
        var pop2000 = sanatcis
            .Where(sanatcis => sanatcis.MuzikTuru == "Pop" && sanatcis.CikisYili < 2000)
            .GroupBy(sanatcis => sanatcis.CikisYili)
            .OrderBy(sanatcis => sanatcis.Key);


        foreach (var p in pop2000)
        {
            Console.WriteLine($"\nÇıkış Yılı : {p.Key}");
            foreach (var x in p.OrderBy(x => x.TamAd))
            {
                Console.WriteLine($"{x.TamAd}");
            }

        }
        Console.WriteLine("----- EN ÇOK ALBÜM SATAN ŞARKICI -----");
        var enCokSatan = sanatcis.OrderByDescending(x => x.Satis).First();
        Console.WriteLine(enCokSatan.TamAd);
        Console.WriteLine("----- EN YENİ ŞARKICI -----");
        var enYeni = sanatcis.OrderByDescending(x => x.CikisYili).First();
        Console.WriteLine(enYeni.TamAd);
        Console.WriteLine("----- EN ESKİ ŞARKICI -----");
        var enEski = sanatcis.OrderBy(x => x.CikisYili).First();
        Console.WriteLine(enEski.TamAd);

    }

}
