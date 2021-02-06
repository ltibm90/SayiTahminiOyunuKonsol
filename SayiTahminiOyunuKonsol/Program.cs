using System;

namespace OdevDeneme
{
    class Program
    {
        static string hafizadakisayi = "";
        static void Main(string[] args)
        {

            Console.WriteLine("Sayı Tahmini Oyunu");
            int ibasamak = 4;

            Console.Write("Kaç basamklı olsun (1 ila 9 arası): ");
            try
            {
                ibasamak = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Adam gibi bir sayı girilmediği için 4 olarak baz alınacak.");
            }   
           
            Console.WriteLine();
            if (ibasamak <= 0)
            {
                Console.WriteLine("0 veya negatif basamak girildiği için 4 olarak baz alınacak.");
                ibasamak = 4;
            }
            if (ibasamak > 9)
            {
                Console.WriteLine("Basamak gir dedim, sayı tahmin et demedim. 9 olarak baz alınacak. ");
                ibasamak = 9;
            }
            hafizadakisayi = NumaraOlustur(ibasamak);
            //hafizadakisayi = "987654321";
            Console.Write("{0} basamaklı bir sayı girin: ", hafizadakisayi.Length);
            string inumara = Console.ReadLine();
            int cevap = int.Parse(inumara);
            Console.WriteLine(Karsilastir(hafizadakisayi, cevap.ToString()));
            Console.ReadKey();
        }
        static string Karsilastir(string sol, string sag)
        {
            if (sol.Length != sag.Length)
            {
                return string.Format("Hata! {0} Basamaklı sayı girilmedi.", sol.Length);
            }
            int pozitif = 0;
            int negatif = 0;
            byte[] itarandi = new byte[sol.Length];
            Console.WriteLine("\nSONUÇ");
            Console.Write("Girilen    : ");
            for (int i = 0; i < sag.Length; i++)
            {
                if (sol[i] == sag[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(sol[i]);
                    pozitif++;
                    itarandi[i] = 2;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                bool isfnd = false;
                for (int j = 0; j < sol.Length; j++)
                {
                    if (itarandi[j] > 0) continue;
                    if (sol[j] == sag[i])
                    {
                        if (i != j && sag[j] != sol[j])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            negatif++;
                            itarandi[j] = 1;
                            Console.Write(sag[i]);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            isfnd = true;
                            break;
                        }

                    }
                }
                if (!isfnd)
                {
                    Console.Write(sag[i]);
                }

            }
            Console.WriteLine();
            Console.Write("Hafızadaki : ");
            for (int i = 0; i < hafizadakisayi.Length; i++)
            {
                if (itarandi[i] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (itarandi[i] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(hafizadakisayi[i]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("");
            if (pozitif == hafizadakisayi.Length)
            {
                return string.Format("Puan: +{0}, Tebrikler! Tümünü tutturdunuz.", pozitif);
            }
            if (negatif == hafizadakisayi.Length)
            {
                return string.Format("Puan: -{0}, Yani bu sayıyı nasıl tutturdun merak ediyorum doğrusu.", negatif);
            }
            if (pozitif == 0 && negatif == 0)
            {
                return string.Format("Puan: +0, -0, İnsan bir tanesini doğru sallar enazından.", pozitif, negatif);
            }
            return string.Format("Puan: +{0}, -{1}", pozitif, negatif);
        }
        static string NumaraOlustur(int basamak, bool basamakfarkli = false)
        {
            //En az 1 basamak
            //En fazla 9 basamak
            if (basamak == 0) basamak = 1;
            if (basamak > 9) basamak = 9;
            Random Rnd = new Random();
            string gecici = "";
            for (int i = 0; i < basamak; i++)
            {
                if (i == 0)
                {
                    gecici += Rnd.Next(1, 9);
                }
                else
                {
                    int inum = Rnd.Next(0, 9);
                    if(basamakfarkli)
                    {
                        while (gecici.Contains(inum.ToString()))
                        {
                            inum = Rnd.Next(0, 9);
                        }
                    }
                    gecici += inum;
                }
            }
            return gecici;
        }
    }
}
