using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    public class ReportItem
    {
        public string CustomerName { get; set; }
        public string BankName { get; set; }
    }
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = fruits.Where(fruit => fruit.StartsWith("L"));
            foreach (string lfruit in LFruits)
            {
                Console.WriteLine(lfruit);
            }


            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);
            foreach (int multiple in fourSixMultiples)
            {
                Console.WriteLine(multiple);
            }
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
{
    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
    "Francisco", "Trey"
};

            IEnumerable<string> descendingNames = names.OrderByDescending(name => name);
            descendingNames.ToList().ForEach(d => Console.WriteLine(d));

            // Build a collection of these numbers sorted in ascending order
            List<int> OrderingAscNumbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};
            var ascOrdered = OrderingAscNumbers.OrderBy(n => n).ToList();
            foreach (var aNumber in ascOrdered)
            {
                Console.WriteLine(aNumber);
            }

            // Output how many numbers are in this list
            List<int> howManyNumbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};
            int NumCounter = howManyNumbers.Count();

            // How much money have we made?
            List<double> purchases = new List<double>()
{
    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
};
            double total = purchases.Sum();

            // What is our most expensive product?
            List<double> prices = new List<double>()
{
    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
};
            double priciestItem = prices.Max();

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
{
    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
};
            wheresSquaredo.TakeWhile(n => (Math.Sqrt(n) % 1 != 0)).ToList().ForEach(n => Console.WriteLine(n));
            ;

            // millionaire list
            List<Customer> customers = new List<Customer>() {
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

            List<Customer> filteredList = customers.Where(m => m.Balance >= 1000000).ToList();


            /*
        Given the same customer set, display how many millionaires per bank.
        Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

        Example Output:
        WF 2
        BOA 1
        FTB 1
        CITI 1
    */
            var millionairesByBank = (from customer in filteredList
                                      group customer by customer.Bank into
                                      customerGroup
                                      select new Dictionary<string, int>(){
                {customerGroup.Key, customerGroup.Count()}
            }).ToList();

            foreach (var oneMillionaire in millionairesByBank)
            {
                foreach (var dictionary in oneMillionaire)
                {
                    Console.WriteLine(dictionary);
                }
            };//---------------------- joining collections practice---------------

            /*
                TASK:
                As in the previous exercise, you're going to output the millionaires,
                but you will also display the full name of the bank. You also need
                to sort the millionaires' names, ascending by their LAST name.

                Example output:
                    Tina Fey at Citibank
                    Joe Landy at Wells Fargo
                    Sarah Ng at First Tennessee
                    Les Paul at Wells Fargo
                    Peg Vale at Bank of America
            */



            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

            // Create some customers and store in a List
            List<Customer> NewBankCustomers = new List<Customer>() {
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

            var joint =
                from singleCustomer in NewBankCustomers
                join oneBank in banks on singleCustomer.Bank equals oneBank.Symbol into newTable
                select new { Customer = singleCustomer, Banks = newTable };

            foreach (var j in joint)
            {
                Console.Write(j.Customer.Name + ":");
                foreach (var oneBank in j.Banks)
                {
                    Console.WriteLine("   " + oneBank.Name);
                }
            };
        }
    }
}