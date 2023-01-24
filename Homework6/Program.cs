using System;
using System.Xml;

namespace Homework6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "salvi";
            Capitalize(ref name);
            Console.WriteLine(name);

            string nameInput;
            do
            {
                Console.Write("Enter your name: ");
                nameInput = Console.ReadLine();

            } while (IsName(nameInput) == false);

            //console-da email deyeri istenilsin. Eger deyerde @ xarakteri yoxdursa yeniden istenilsin
            string email;
            do
            {
                Console.Write("Enter E-mail: ");
                email = Console.ReadLine();
            } while (!email.Contains('@'));

            Console.WriteLine(GetDomain(email));

            name = "Salvi";
            Console.WriteLine(IsName(name));

            string[] fullnames = { "   Salvi   Ismayilzada  ", "Bahar Behbudova"};
            var names = MakeNames(fullnames);
            
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            string[] array = { "hello", "world", "harry", "potter", "hello", "potter" };

            var newArray = MakeUniqueArray(array);

            for (int i = 0; i < newArray.Length; i++)
            {
                Console.WriteLine(newArray[i]);
            }

        }

        //Verilmis yazini bas herfi boyuk digerleri kicik halda qaytaran metod
        static void Capitalize(ref string str)
        {
            str = char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

       //Verilmis yazinin ad olub olmadigini tapan metod
        static bool IsName(string str)
        {
            if(string.IsNullOrWhiteSpace(str))
                return false;

            if (!char.IsUpper(str[0]))
                return false;

            for (int i = 1; i < str.Length; i++)
            {
                if (!char.IsLower(str[i]))
                    return false;
            }

            return true;
        }
      
        //Verilmis fullname siyahisindan names siyahisi duzeldib qaytaran metod
        static string[] MakeNames(string[] arr)
        {
            string[] newArr = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                var fullname = arr[i].TrimStart();
                var name = arr[i].TrimStart().Substring(0, fullname.IndexOf(' '));
                newArr[i] = name;
            }

            return newArr;
        }

        //Verilmis string arrayinin icerisindeki tekrarlanmayan deyerlerden ibaret
        //yeni bir array qaytaran metod
        static string[] MakeUniqueArray(string[] arr)
        {
            string[] newArr = new string[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (Array.IndexOf(newArr, arr[i]) == -1)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = arr[i];
                }
            }
            return newArr;
        }

        static string GetDomain(string str)
        {
           return str.Substring(str.IndexOf('@') + 1);
        }
    }
}
