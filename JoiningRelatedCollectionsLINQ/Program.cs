using System;
using System.Collections.Generic;
using System.Linq;


namespace JoiningRelatedCollectionsLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bank> banks = new List<Bank>()
            {
                new Bank() { Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            List<Customer> customers = new List<Customer>()
            {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            //identify & print millionaires in the customers list
            var millionaireReport =
                from cust in customers
                where cust.Balance >= 1000000
                select cust;

            Console.WriteLine("Rich MoFo List...");
            foreach (var peep in millionaireReport)
            {
                Console.WriteLine($"{peep.Name} at {peep.Bank}");
                Console.WriteLine();

            }

            //Sort rich peeps in ascending order by last name. 
            var sortByLastName = millionaireReport.OrderBy(cust => cust.Name.Split(' ')[1]);
            Console.WriteLine("...and now sorted in ascending order by last name. Because why not?");
            foreach (var peep in sortByLastName)
            {
                Console.WriteLine($"{peep.Name} at {peep.Bank}");
            }




            Console.Read();
        }
    }
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
}
