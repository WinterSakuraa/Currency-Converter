using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Privat24_API
{
    class Currency
    {
        public String ccy { get; set; }
        public String base_ccy { get; set; }
        public String buy { get; set; }
        public String sale { get; set; }

        public override string ToString()
        {
            return $"Currency : {ccy}\nNational currency: {base_ccy}\nBuy price: {buy}\nSale price: {sale}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var request = new GetRequest("https://api.privatbank.ua/p24api/pubinfo?exchange&json&coursid=11");
            request.Run();

            var response = request.Response;

            var data = JsonConvert.DeserializeObject<List<Currency>>(response);

            double amount;
            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("\tConverter");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. UAH to USD");
                Console.WriteLine("2. UAH to EUR");
                Console.WriteLine("3. UAH to BTC");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");
                int key = Convert.ToInt32(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        Console.Write("Enter number in UAH: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Result: {Convert.ToDouble(data[0].sale) * amount}");
                        do
                        {
                            Console.WriteLine("Press enter...");
                        } while (Console.ReadKey().Key != ConsoleKey.Enter);
                        break;

                    case 2:
                        Console.Write("Enter number in UAH: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Result: {Convert.ToDouble(data[1].sale) * amount}");
                        break;
                        do
                        {
                            Console.WriteLine("Press enter...");
                        } while (Console.ReadKey().Key != ConsoleKey.Enter);

                    case 3:
                        Console.Write("Enter number in UAH: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Result: {Convert.ToDouble(data[3].sale) * amount}");
                        do
                        {
                            Console.WriteLine("Press enter...");
                        } while (Console.ReadKey().Key != ConsoleKey.Enter);
                        break;

                    case 4:
                        showMenu = false;
                        break;

                    default:
                        Console.WriteLine("Enter number (1-3)!!");
                        break;
                }
            }
        }
    }
}

