using System;
using System.Threading;
using System.Collections;

namespace hafta3_odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Kişiler için binen kişiler her çalıştırıldığında random oluşması için bir veri alanı

            string[] mensNames = { "Sadi", "Enis", "Emirhan", "Faruk", "Mustafa", "Kemal", "John", "Arthur", "Hedio", "Cafer", "Kerim", "Bahri" };
            string[] womensNames = { "Ceren", "Tuğba", "Canan", "Hatice", "Murat", "Mehmet", "Aliye", "Sude", "Gayret" };
            string[] surnames = {"Güçlüer", "Marston", "Morgan", "Kojima", "Kodyazanlar", "Fullstackoğlu", "Sişarpçıoğlu", "Yılmaz", "Zamansızhata", "Kadir", "Taşyürek" };
            // 21 tane isim 11 soyisim var. Toplamda random olarak 231 farklı kişi elde edebiliriz.
            // Bunu yapmamın nedeni her seferinde farklı insanlar görmek istiyor olmam. Tamamen benim her seferinde farlı kişiler görme istememle alakalı.
            
            #endregion

            Bus bus = new Bus();

            Menu(false);
            Console.WriteLine("Yolcular biniyor...");
            Thread.Sleep(3000);
            Random _name = new Random(), _surname = new Random();
            Random _age = new Random(), _gender = new Random();
            Random _ticket = new Random();

            for (int firstGate = 0;  firstGate < 15; firstGate++) // Önce ön kapıdan binecek kişiler olmalı
            {
                int index = _gender.Next(0, 2);
                if (index == 0) // erkek
                {
                    Person newPerson = new Person(mensNames[_name.Next(0, 12)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 0/*erkek*/, 1/*ön*/, true);
                    bus.AddTraveller(newPerson);
                }
                else if (index == 1) // kadın
                {
                    Person newPerson = new Person(womensNames[_name.Next(0, 9)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 1/*kadın*/, 1/*ön*/, true);
                    bus.AddTraveller(newPerson);
                }
            }
            int midTempFalse = 1, midTempTrue = 1;
            for (int midGate = 0; midGate < 10; midGate++)
            {
                bool if1 = false; // Daima biri false iken diğeri true olacak şekilde ayarlandı. (30 dk debug ettim. Çalışıyor döngüyü 3-4 kez döndüm illaki bir bloğa giriyor ve kişi oluşuyor.
                bool if2 = false;
                int a1 = _ticket.Next(0, 2);

                if1 = (a1 == 0 && midTempFalse < 6) || midTempTrue > 5;
                if2 = (a1 == 1 && midTempTrue < 6) || midTempFalse > 5;

                if (if1) // 5 kişi basmadığı zaman geriye kalan kişiler basıyor olarak algılar.
                { // basmayanlar
                    int index = _gender.Next(0, 2);
                    if (index == 0) // erkek
                    {
                        Person newPerson = new Person(mensNames[_name.Next(0, 12)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 0/*erkek*/, 2/*orta*/, false);
                        bus.AddTraveller(newPerson);
                    }
                    else if (index == 1) // kadın
                    {
                        Person newPerson = new Person(womensNames[_name.Next(0, 9)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 1/*kadın*/, 2/*orta*/, false);
                        bus.AddTraveller(newPerson);
                    }
                    midTempFalse++;
                }
                else if (if2) // 5 bastığı zaman geri kalanları basmadı olarak algılar
                { // basanlar
                    int index = _gender.Next(0, 2);
                    if (index == 0) // erkek
                    {
                        Person newPerson = new Person(mensNames[_name.Next(0, 12)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 0/*erkek*/, 2/*orta*/, true);
                        bus.AddTraveller(newPerson);
                    }
                    else if (index == 1) // kadın
                    {
                        Person newPerson = new Person(womensNames[_name.Next(0, 9)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 1/*kadın*/, 2/*orta*/, true);
                        bus.AddTraveller(newPerson);
                    }
                    midTempTrue++;
                }
            }
            int lastTempFalse = 1, lastTempTrue = 1;
            for (int lastGate = 0; lastGate < 13; lastGate++)
            {
                bool if1 = false;
                bool if2 = false;
                int a2 = _ticket.Next(0, 2);

                if1 = (a2 == 0 && lastTempFalse < 10) || lastTempTrue > 4;
                if2 = (a2 == 1 && lastTempTrue < 10) || lastTempFalse > 4;

                if (if1) // 9 kişi basmadığı zaman geriye kalan kişiler basıyor olarak algılar.
                { // basmayanlar
                    int index = _gender.Next(0, 2);
                    if (index == 0) // erkek
                    {
                        Person newPerson = new Person(mensNames[_name.Next(0, 12)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 0/*erkek*/, 3/*arka*/, false);
                        bus.AddTraveller(newPerson);
                    }
                    else if (index == 1) // kadın
                    {
                        Person newPerson = new Person(womensNames[_name.Next(0, 9)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 1/*kadın*/, 3/*arka*/, false);
                        bus.AddTraveller(newPerson);
                    }
                    lastTempFalse++;
                }
                else if (if2) // 4 bastığı zaman geri kalanları basmadı olarak algılar
                { // basanlar
                    int index = _gender.Next(0, 2);
                    if (index == 0) // erkek
                    {
                        Person newPerson = new Person(mensNames[_name.Next(0, 12)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 0/*erkek*/, 3/*arka*/, true);
                        bus.AddTraveller(newPerson);
                    }
                    else if (index == 1) // kadın
                    {
                        Person newPerson = new Person(womensNames[_name.Next(0, 9)], surnames[_surname.Next(0, 11)], _age.Next(6, 90), 1/*kadın*/, 3/*arka*/, true);
                        bus.AddTraveller(newPerson);
                    }
                    lastTempTrue++;
                }
            }

            Console.WriteLine("\nYolcular bindi.\nBinen yolcu sayısı: 38\n");

            Menu(true);

            Console.WriteLine("Bilet kontrolü yapılıyor...");
            Thread.Sleep(1500);
            Bus.ShowTravellers(bus.chairsList);

            Console.ReadLine();
        }
        public static void Menu(bool bl)
        {
            if (bl)
            {
                Console.Clear();
                Console.WriteLine("-------------------------");
                Console.WriteLine("| Bilet Kontrol Sistemi |");
                Console.WriteLine("-------------------------");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------");
                Console.WriteLine("|oooo|oooo|o \\");
                Console.WriteLine("|----------------");
                Console.WriteLine("|    |    |      |");
                Console.WriteLine("|--O--O-------O---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.WriteLine("Otobüs dolu.");
                Console.WriteLine("Biletleri kontrol etmek için bir tuşa tıklayınız.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("| Bilet Kontrol Sistemi |");
                Console.WriteLine("-------------------------");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------");
                Console.WriteLine("|    |    |  \\");
                Console.WriteLine("|----------------");
                Console.WriteLine("|    |    |      |");
                Console.WriteLine("|--O--O-------O---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.Write("Otobüs şuan boş. Servise başlamak için herhangi bir tuşa tıklayınız.");
                Console.ReadKey();
                Console.WriteLine();
            }
            
        }
    }
}
