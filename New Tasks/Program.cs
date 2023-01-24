using System;

namespace New_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "P231";
            Console.WriteLine(IsDigit(word));

            string fullname = "Harry potter";
            Console.WriteLine(IsFullname(fullname));

            int[] numbers = { 1, 2, 3, 4, 4, 6, 6 };
            var newNumbers = MakeUniqueNumbers(numbers);
            for (int i = 0; i < newNumbers.Length; i++)
            {
                Console.WriteLine(newNumbers[i]);
            }

            string[] emails = { "salviai@code.edu.az", "salvi.ismayilzada@gmail.com"};
            MakeDomains(ref emails);
            for (int i = 0; i < emails.Length; i++)
            {
                Console.WriteLine(emails[i]);
            }

            string sentences = "Hello world. How are you. Everything is ok.";
            var count = CountOfSentences(sentences);
            Console.WriteLine(count);
        }

        //- Verilmiş yazıda rəqəm olub olmadığını tapan metod
        static bool IsDigit(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                    return true;
            }
            return false;
        }

        //- Verilmiş yazının fullname olub olmadığını tapan metod
        //(fullname olması üçün iki sozdən ibarət olmalıdır
        //və hər bir söz böyük hərflə başlayıb kiçik hərflərlə davam etməlidir)
        static bool IsName(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
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
        static bool IsFullname(string str)
        {
            string[] newStr = str.Split(' ');

            var name = newStr[0];
            var surname = newStr[1];

            if(IsName(name) && IsName(surname))
                return true;
            return false;
        }

        //- Verilmiş ədədlər siyahısından yeni bir array düzəldib qaytaran metod.
        //Yeni arrayə elementlər təkrarlanmamaq şərti ilə yerləşdirilsin.
        static int[] MakeUniqueNumbers(int[] arr)
        {
            int[] newArr = new int[0];

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

        // - Verilmiş email-lər siyahısından domainlər siyahısı düzəldən metod.
        static void MakeDomains(ref string[] str)
        {
            string[] domains = new string[0];

            for (int i = 0; i < str.Length; i++)
            {
                Array.Resize(ref domains, domains.Length + 1);
                domains[domains.Length - 1] = str[i].Substring(str[i].IndexOf('@') + 1);
            }

            str = domains;
        }

        //- Verilmiş yazının içindəki cümlələrin sayını tapan metod.
        static int CountOfSentences(string str)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.ToString(str[i]).Contains('.'))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
