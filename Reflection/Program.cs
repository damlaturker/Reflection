using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {

        //Reflection sayesinde çalıştığımız objelere ait verileri run-time'da okuyup düzenleyebiliriz.
        //Run-time da dinamik olarak mevcut sınıflarımızdan yeni objeler türetebiliriz.
        //app domain içindeki yüklü olan tipleri yönetmemizi ve metadataları alabilmemizi sağlar.
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Projede içindeki bütün classları döndürür. 

            //foreach (var item in assembly.GetTypes())
            //{
            //    Console.WriteLine($"{item.Namespace}.{item.Name}");
            //    foreach (var property in item.GetProperties())
            //    {
            //    Console.WriteLine($"{property.PropertyType}/ {property.Name}");
            //    }

            //}

            //gettype taki adda objeyi alir.
            var userType = Type.GetType("Reflection.User");

            //bütün propertylerini Getirir.
            var userProperties = userType.GetProperties();

            //ismini yazdığımız propertyi getirir.
            var userName = userType.GetProperty("Name");
            var userLastName = userType.GetProperty("LastName");

            //Instance oluşturur.
            var user = (User)Activator.CreateInstance(userType);


            //Methodu alır.
            var welcome = userType.GetMethod("Welcome");
            var getFullName = userType.GetMethod("GetFullName");
            //Methodu Çalıştırır.
            welcome.Invoke(user, null);

            //Value set Eder.
            userName.SetValue(user, "Damla");
            userLastName.SetValue(user, "Türker");

            var returnFullName = getFullName.Invoke(user, null).ToString();
            Console.WriteLine(returnFullName);
            Console.ReadLine();

        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void Welcome()
        {
            Console.WriteLine("Hoşgeldiniz");
        }
        public string GetFullName()
        {
            return $"Adınız : {Name} - Soyadınız: {LastName}";
        }
    }

}
