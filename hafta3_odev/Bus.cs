using System;
using System.Collections.Generic;

namespace hafta3_odev
{
    internal class Bus
    {
        private int capacity = 41;
        public List<Person> chairsList = new List<Person>();
        // LinkedList yapmak geldi aklıma ama normal bir liste olarak da bağlayabilirim diye düşündüm..
        // ..LinkedList generic normal list'e göre daha kısıtlı geldi. Tam olarak kafamdaki koda uymadı.
        // Sonuç olarak veri modeline uygun şekilde çalışıyor.

        Person driver = new Person("Sadi Enis", "Güçlüer", 20, 0);
        public Bus()
        {
            chairsList.Capacity = capacity;
            for (int i = 0; i <= 40; i++)
            {
                Person person = new Person();
                chairsList.Add(person); // Boş kişi nesnelerinden ekliyorum ki count dolsun
                                        // Dizi baştan boş olduğu için ArgumentOutOfRangeException hatası aldım.
                                        // Böylece [] kulllarak kişi ekleyemedim listeye. Benim de aklıma bu çözüm geldi.
            }
            chairsList[0] = driver;
        }
        public void AddTraveller(Person traveller)
        { // Kişinin ruh halini Random nesnesi belirleyecek.
            Random rand = new Random();
            again:
            int indx = rand.Next(1, capacity);
            if (chairsList[indx].name == null)
                chairsList[indx] = traveller;
            else // Eğer random dönen index daha önce oturulduysa yeniden random değer oluştursun.
                goto again;
        }
        public static void ShowTravellers(List<Person> _chairsList) // static yapmamın tek nedeni Önceki hafta konusu olmasıdır.
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("| Bilet Kontrol Sistemi |");
            Console.WriteLine("-------------------------\n");

            Console.WriteLine(" Yolcular ");
            Console.WriteLine("----------");
            Console.WriteLine();

            int first = 0, mid = 0, last = 0;
            int tckt = 0;
            for (int i = 1; i < _chairsList.Count; i++)
            {
                if (_chairsList[i].name != null)
                {
                    Console.WriteLine("Koltuk No: " + i);
                    Console.WriteLine("Koltukta oturan kişi: " + _chairsList[i].name + " " + _chairsList[i].surname);
                    Console.WriteLine("Koltukta oturan kişinin yaşı: " + _chairsList[i].age);
                    switch (_chairsList[i].gender)
                    {
                        case 0:
                            Console.WriteLine("Koltukta oturan kişinin cinsiyeti: Erkek");
                            break;
                        case 1:
                            Console.WriteLine("Koltukta oturan kişinin cinsiyeti: Kadın");
                            break;
                    }
                    switch (_chairsList[i].gate)
                    {
                        case 1:
                            Console.WriteLine("Koltukta oturan kişinin girdiği kapı: Ön");
                            first++;
                            break;
                        case 2:
                            Console.WriteLine("Koltukta oturan kişinin girdiği kapı: Orta");
                            mid++;
                            break;
                        case 3:
                            Console.WriteLine("Koltukta oturan kişinin girdiği kapı: Arka");
                            last++;
                            break;
                    }
                    switch (_chairsList[i].ticket)
                    {
                        case true:
                            Console.WriteLine("Koltukta oturan kişi bilet bastı.");
                            tckt++;
                            break;
                        case false:
                            Console.WriteLine("Koltukta oturan kişi bilet basmadı.");
                            break;
                    }

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Koltuk No: " + i);
                    Console.WriteLine("Koltuk Boş");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|         Bilet Sistemi Özeti         |");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("| Ön Kapıdan Giren Kişi Sayısı: "  + first + "    |");
            Console.WriteLine("| Orta Kapıdan Giren Kişi Sayısı: " + mid + "  |");
            Console.WriteLine("| Arka Kapıdan Giren Kişi Sayısı: " + last + "  |");
            Console.WriteLine("| Bilet Basan Kişi Sayısı: " + tckt + "         |");
            Console.WriteLine("| Bilet Basmayan Kişi Sayısı: " + (38 - tckt) + "      |");
            Console.WriteLine("---------------------------------------");

        }
    }
}
