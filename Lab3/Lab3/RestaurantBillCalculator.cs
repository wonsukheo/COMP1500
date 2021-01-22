using System.IO;

namespace Lab3
{
    public static class RestaurantBillCalculator
    {
        public static double CalculateTotalCost(StreamReader input)
        {
            string orderPrice = input.ReadLine();
            double order0 = double.Parse(orderPrice);

            orderPrice = input.ReadLine();
            double order1 = double.Parse(orderPrice);

            orderPrice = input.ReadLine();
            double order2 = double.Parse(orderPrice);

            orderPrice = input.ReadLine();
            double order3 = double.Parse(orderPrice);

            orderPrice = input.ReadLine();
            double order4 = double.Parse(orderPrice);

            string tipPercentage = input.ReadLine();
            double tip = double.Parse(tipPercentage);

            double orderTotal = order0 + order1 + order2 + order3 + order4;
            double orderTax = orderTotal * 0.05;
            double orderTip = (orderTotal + orderTax) * tip / 100;
            double totalCost = orderTotal + orderTax + orderTip;
            
            return (int)(totalCost * 100 + 0.5) / 100.00;
        }

        public static double CalculateIndividualCost(StreamReader input, double totalCost)
        {
            string number = input.ReadLine();
            uint numOfIndividuals = uint.Parse(number);
            double individualCost = (totalCost / numOfIndividuals);

            return (int)(individualCost * 100 + 0.5) / 100.00;
        }

        public static uint CalculatePayerCount(StreamReader input, double totalCost)
        {
            string number = input.ReadLine();
            double individualBill = double.Parse(number);
            uint payerCount = (uint)(totalCost / individualBill)
            return payerCount;
        }
    }
}
