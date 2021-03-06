﻿using System;
using System.Collections.Generic;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            Console.WriteLine(dictionary.Count);                                  // Ekranda 0 çıktısını gördük. Demek ki dictionary new'lendiği zaman içerisindeki constructor blok 0 elemanlı bir dizi tanımlıyor.
            dictionary.Add(123, "Barış");
            dictionary.Add(456, "Ali"); 
            dictionary.Add(159, "Engin Demiroğ");
            */


            MyDictionary<int, string> dictionary1 = new MyDictionary<int, string>();
            string[] arrray = new string[2];

            dictionary1.Add(123, "Barış");
            dictionary1.Add(456, "Ali");
            dictionary1.Add(159, "Engin Demiroğ");

            Console.WriteLine(dictionary1.Count);
            dictionary1.ListAll();

        } 
    }
    class MyDictionary<K, V>
    {
        K[] _key, _tempKey;      //tempKey geçici olarak _key in referansını tutması için tanımlandı.
        V[] _value, _tempValue;


        //Constructor blok bulunduğu class newlendiğinde çalışam bir metottur.
        public MyDictionary()
        {
            _key = new K[0];        // constructor blokta 0 elemanlı array tanımı.
            _value = new V[0];
        }
        public void Add(K key, V value)
        {
            _tempKey = _key;      // _keyTemp _key'in referansını tutar.
            _tempValue = _value;  // aynı şekilde...

            _key = new K[_key.Length + 1];     // key arrayimizde +1 yer açıyoruz.
            _value = new V[_value.Length + 1];

            for (int i = 0; i < _tempKey.Length; i++)
            {
                _key[i] = _tempKey[i];    // tempKey deki değerler indeksine göre key arrayine aktarılır. Yani artık hem önceki elemanlar yine aynı yerlerine geçiyor hem de +1 boşluğumuz var.
                _value[i] = _tempValue[i];

                //_key[_key.Length - 1] = key;        // en sondaki boş indekse yeni eklenecek değeri yerleştiriyoruz.
                //_value[_value.Length - 1] = value;  // yeni değer için kontrol yapmamız gerekli önce kontrolü yapacağız burası iptal.

            }

            /**
             * Yeni eklenen parametremizde key kısmı boş olursa hata vermeli,
             * Keyler eşsiz olmalı o yüzden önceki keyler ile aynı verilirse hata vermeli,
             */
            for (int j = 0; j < _tempKey.Length; j++)
            {
                if(key == null)
                {
                    throw new ArgumentNullException("Key can not be null!");
                }
                else if (_tempKey[j].Equals(_key))
                {
                    throw new ArgumentException("Same key already exists in key array!");
                }

            }

            // Kontrollerden geçen key değeri ve değer ataması yapılır
            _key[_key.Length - 1] = key; // Açılan boşluğa key atanır.
            _value[_value.Length - 1] = value; // Açılan boşluğa value atanır.

        }
        public int Count
        {
            get { return _key.Length; }
        }

        public void ListAll()
        {
            for (int i = 0; i < _key.Length; i++)
            {
                Console.WriteLine("({0} , {1})", _key[i], _value[i]);
            }
        }
    }
}
