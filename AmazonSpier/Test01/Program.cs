using System;
using System.Collections.Generic;
using System.Text;

namespace Test01
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "http://www.amazon.com/s/ref=sr_pg_2?rh=i%3Aaps%2Ck%3Acars&page=2&keywords=cars&ie=UTF8&qid=1425887281";
            string[] arr = str.Split(new string[2] { "sr_pg_", "?" }, StringSplitOptions.RemoveEmptyEntries);
            string page = arr[1];
            int next_page = Convert.ToInt32(page, 10) + 1;

            System.Console.WriteLine(next_page+"");

            DateTime dt = DateTime.Now;
            System.Console.WriteLine(dt.ToLocalTime().ToString());
            System.Console.ReadLine();
        }
    }
}
