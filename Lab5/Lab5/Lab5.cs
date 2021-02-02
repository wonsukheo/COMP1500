using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public static class Lab5
    { 
        public static bool TryFixData(uint[] usersPerDay, double[] revenuePerDay)
        {
            if (usersPerDay.Length != revenuePerDay.Length)
            {
                return false;
            }
            
            int errorfixed = 0;
            
            for (int i = 0; i < revenuePerDay.Length; ++i)
            {
                double expectedRevenue = 0.00;

                if (0 <= usersPerDay[i] && usersPerDay[i] <= 10)
                {
                    expectedRevenue = usersPerDay[i] / 2.00;
                    if (expectedRevenue != revenuePerDay[i])
                    {
                        revenuePerDay[i] = expectedRevenue;
                        errorfixed++;
                    }
                }

                if (10 < usersPerDay[i] && usersPerDay[i] <= 100)
                {
                    expectedRevenue = 16.00 * usersPerDay[i] / 5 - 27;
                    if (expectedRevenue != revenuePerDay[i])
                    {
                        revenuePerDay[i] = expectedRevenue;
                        errorfixed++;
                    }
                }

                if (100 < usersPerDay[i] && usersPerDay[i] <= 1000)
                {
                    expectedRevenue = usersPerDay[i] * usersPerDay[i] / 4.00 - 2 * usersPerDay[i] - 2007;
                    if (expectedRevenue != revenuePerDay[i])
                    {
                        revenuePerDay[i] = expectedRevenue;
                        errorfixed++;
                    }
                }

                if (usersPerDay[i] > 1000 )
                {
                    expectedRevenue = 245743 + usersPerDay[i] / 4.00;
                    if (expectedRevenue != revenuePerDay[i])
                    {
                        revenuePerDay[i] = expectedRevenue;
                        errorfixed++;
                    }
                }
            }

            return errorfixed == 0 ? false : true;
        }

        public static int GetInvalidEntryCount(uint[] usersPerDay, double[] revenuePerDay)
        {
            if (usersPerDay.Length != revenuePerDay.Length)
            {
                return -1;
            }

            int errorfixed = 0;

            for (int i = 0; i < usersPerDay.Length; ++i)
            {
                double expectedRevenue = 0.00;

                if (0 <= usersPerDay[i] && usersPerDay[i] <= 10)
                {
                    expectedRevenue = usersPerDay[i] / 2.00;
                    if (expectedRevenue != revenuePerDay[i])
                    {
                        errorfixed++;
                    }
                }

                if (10 < usersPerDay[i] && usersPerDay[i] <= 100)
                {
                    expectedRevenue = 16.00 * usersPerDay[i] / 5 - 27;
                    if (expectedRevenue != revenuePerDay[i])
                    {
                        errorfixed++;
                    }
                }

                if (100 < usersPerDay[i] && usersPerDay[i] <= 1000)
                {
                    expectedRevenue = usersPerDay[i] * usersPerDay[i] / 4.00 - 2 * usersPerDay[i] - 2007;
                    if (expectedRevenue != revenuePerDay[i])
                    {
                        errorfixed++;
                    }
                }

                if (usersPerDay[i] > 1000)
                {
                    expectedRevenue = 245743 + usersPerDay[i] / 4.00;
                    if (expectedRevenue != revenuePerDay[i])
                    {
                        errorfixed++;
                    }
                }
            }
            return errorfixed;
        }

        public static double CalculateTotalRevenue(double[] revenuePerDay, uint start, uint end)
        {
            if (revenuePerDay.Length == 0 || start < 0 || end < start || end > revenuePerDay.Length)
            {
                return -1;
            }
            
            double totalRevenue = 0.00;
            for (uint i = start; i < end + 1; ++i)
            {
                totalRevenue += revenuePerDay[i];
            }
            
            return totalRevenue;
        }
    }
}
