using System;
using System.Collections.Generic;

namespace hafta3_odev
{
    internal class Person
    {
        public string name;
        public string surname;
        public int age;
        public int gender; // 0- erkek 1- kadın
        public int gate; // 1-ön 2-orta 3-arka
        public bool ticket; // true- bastı false- basmadı

        public Person(string _name, string _surname, int _age, int _gender, int _gate, bool _ticket)
        {
            name = _name;
            surname = _surname;
            age = _age;
            gender = _gender;
            gate = _gate;
            ticket = _ticket;
        }
        public Person(string _name, string _surname, int _age, int _gender)
        { // Şoför eklerken kullanmak için
            name = _name;
            surname = _surname;
            age = _age;
            gender = _gender;
        }
        public Person()
        {
            
        }
    }
}
