
using System;

namespace Assignment
{
    public class LifeCounter
    {

        //public string GetProductInformation(string productName, string country, DateTime productionDate) { }

        public int DaysPassedSinceProduction(DateTime productionDate)
        {
            DateTime CurrentDate = DateTime.Now;
            return (int)(CurrentDate - productionDate).TotalDays;
        }

        public Double HoursPassedSinceProduction(DateTime productionDate)
        {
            DateTime CurrentDate = DateTime.Now;
            return (CurrentDate - productionDate).TotalHours;
        }

        public Double MinutesPassedSinceProduction(DateTime productionDate)
        {
            DateTime CurrentDate = DateTime.Now;
            return (CurrentDate - productionDate).TotalMinutes;
        }
        public Double SecondsPassedSinceProduction(DateTime productionDate)
        {
            DateTime CurrentDate = DateTime.Now;
            return (CurrentDate - productionDate).TotalSeconds;
        }

        public string GetProductInformation(string productName, string country, DateTime productionDate)
        {

            LifeCounter myCounter = new LifeCounter();

            int Days_since_prod = myCounter.DaysPassedSinceProduction(productionDate);
            double Hours_since_prod = myCounter.HoursPassedSinceProduction(productionDate);
            double Minutes_since_prod = myCounter.MinutesPassedSinceProduction(productionDate);
            double Seconds_since_prod = myCounter.SecondsPassedSinceProduction(productionDate);

            string output_prompt = "******** Here is the Product Life Output ********\n";
            output_prompt += $"Your product named {productName} which is produced in {country} is:\n";
            output_prompt += $"{Days_since_prod} Days Old\n";
            output_prompt += $"{Hours_since_prod.ToString("#.##")} Hours Old\n";
            output_prompt += $"{Minutes_since_prod.ToString("#.##")} Minutes Old\n";
            output_prompt += $"{Seconds_since_prod.ToString("#.##")} Seconds Old\n";

            return output_prompt;
        }


        static void Main(string[] args)
        {

            LifeCounter mainCounter = new LifeCounter();
            Console.WriteLine("*****Welcome to Product Life Calculator*****");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("Please provide details about product:");

            System.Threading.Thread.Sleep(1000);

            Console.Write("Product name: ");
            string prod_name = Console.ReadLine();
            Console.Write("Produced in country: ");
            string prod_country = Console.ReadLine();
            Console.Write("Production Date (dd-MM-yyyy): ");
            DateTime prod_date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

            System.Threading.Thread.Sleep(1000);

            Console.Write("\n\n\n");

            Console.WriteLine(mainCounter.GetProductInformation(prod_name, prod_country, prod_date));

            Console.ReadLine();
        }
    }
}

