
using System;

namespace Mandatory_Assignment_2
{
    public class carStock
    {
        Random rnd = new Random();
        string TypeName;
        public int Price;
        // public int TotalInStockAlpha = rnd.Next(1, 13);
        public int TotalInStockAlpha = 10;
        public int TotalInStockBravo; 
        public int TotalInStockCharlie;

        public void showStockCount(carStock my_stock)
        {
            Console.WriteLine($"The stock count for Alpha is {my_stock.TotalInStockAlpha}");
            Console.WriteLine($"The stock count for Bravo is {my_stock.TotalInStockBravo}");
            Console.WriteLine($"The stock count for Charlie is {my_stock.TotalInStockCharlie}");
        }
        public void totalValue(carStock my_stock)
        {
            Console.WriteLine($"The total value for the Alpha cars is {45000 * my_stock.TotalInStockAlpha}");
            Console.WriteLine($"The total value for the Bravo cars is {67000 * my_stock.TotalInStockBravo}");
            Console.WriteLine($"The total value for the Charlie cars is {98000 * my_stock.TotalInStockCharlie}");
        }

        public int sellIfStock(int stock_number)
        {
            if (stock_number >= 0)
            {
                stock_number -= 1;
            }
            else
            {
                Console.WriteLine("Can't sell his branc of car since there is no stock");
            }
            return stock_number;
        }
        public void OneCarSold(carStock my_stock)
        {
            Console.WriteLine("Select the brand of the sold car (CarAlpha/CarBravo/CarCharlie)");
            Console.WriteLine("Please input A, B or C");
            string type = Console.ReadLine();
            if (type == "A")
            {
                my_stock.TotalInStockAlpha = my_stock.sellIfStock(my_stock.TotalInStockAlpha);
            }
            else if (type == "B")
            {
                my_stock.TotalInStockBravo = my_stock.sellIfStock(my_stock.TotalInStockBravo);
            }
            else if (type == "C")
            {
                my_stock.TotalInStockCharlie = my_stock.sellIfStock(my_stock.TotalInStockCharlie);
            }
 
        }
        public string GetStockStatus(carStock my_stock)
        {
            int total_stock = my_stock.TotalInStockAlpha +
                + my_stock.TotalInStockBravo +
                + my_stock.TotalInStockCharlie;

            string my_stock_status = "";

            if (total_stock < 5)
            {
                my_stock_status = "veryLow";
            }
            else if (total_stock >= 5 & total_stock <= 15)
            {
                my_stock_status = "Low";
            }
            else if (total_stock > 15 & total_stock <= 50)
            {
                my_stock_status = "Normal";
            }
            else if (total_stock > 50)
            {
                my_stock_status = "Over";
            }
            return my_stock_status;
        }
    }
    public class Processor
    {
        public int presentOptionsGetChoice()
        {
            Console.WriteLine("******Here are your options * *****");
            Console.WriteLine("“Please select the action.");
            Console.WriteLine("1.Show stock count for each type");
            Console.WriteLine("2.Show total value of each car type for all cars in stock");
            Console.WriteLine("3.Register one car sold");
            Console.WriteLine("4.Get stock status"); //veryLow, Low, Normal, Over
            Console.WriteLine("5. Quit program");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }


        public void Process()
        {
            Processor my_class = new Processor();
            carStock my_stock = new carStock();
            string allowed_user = "jdfl";
            string password = "pw";


            Console.WriteLine("Please provide username to access the BrandX system");
            string input_user = Console.ReadLine();
            Console.WriteLine("Please provide password");
            string input_password = Console.ReadLine();


            if (input_user == allowed_user & input_password == password) 
            {
                while (true)
                {
                    int user_choice = my_class.presentOptionsGetChoice();
                    if (user_choice == 1)
                    {
                        my_stock.showStockCount(my_stock);
                    }
                    else if (user_choice == 2)
                    {
                        my_stock.totalValue(my_stock);
                    }
                    else if (user_choice == 3)
                    {
                        my_stock.OneCarSold(my_stock);

                    }
                    else if (user_choice == 4)
                    {
                        Console.WriteLine($"The stock status is {my_stock.GetStockStatus(my_stock)}");
                    }
                    else if (user_choice == 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }

                }
            }
            else
            {
                Console.WriteLine("You are not authorized to access this service");
            }

            Console.ReadLine();

        }


    }
    public class carClass
    {
        static void Main(string[] args)
        {
            new Processor().Process();
        }
    }
}

