using System.IO;
using System;
namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            Console.WriteLine("Please Enter price of your first order: ");
            double order0 = double.Parse(input.ReadLine());
            Console.WriteLine("Please Enter price of your second order: ");
            double order1 = double.Parse(input.ReadLine());
            Console.WriteLine("Please Enter price of your third order: ");
            double order2 = double.Parse(input.ReadLine());
            Console.WriteLine("Please Enter price of your fourth order: ");
            double order3 = double.Parse(input.ReadLine());
            Console.WriteLine("Please Enter price of your fifth order: ");
            double order4 = double.Parse(input.ReadLine());
            Console.WriteLine("Please Enter Gratuity in percentage: ");
            double gratuity = double.Parse(input.ReadLine());

            double orderTotal = order0 + order1 + order2 + order3 + order4;
            double orderTax = orderTotal * 0.05;
            double orderGratuity = (orderTotal + orderTax) * (gratuity / 100);
            double totalCost = orderTotal + orderTax + orderGratuity;
            return (int)(totalCost * 100 + 0.5) / 100;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            Console.WriteLine("Number of Individual: ");
            int numOfIndividual = int.Parse(input.ReadLine());
            double individualCost = (totalCost / numOfIndividual);

            return (int)(individualCost * 100 + 0.5) / 100;
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            Console.WriteLine("Individual bill cost: ");
            double individualBill = double.Parse(input.ReadLine());
            uint payerCount = (uint)(totalCost / individualBill * 100 + 0.5) / 100;
            return payerCount;
        }
    }
}
