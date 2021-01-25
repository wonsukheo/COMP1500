namespace Lab4
{
    public static class Calendar
    {
        public static bool IsLeapYear(uint year)
        {
            if (year % 4 == 0 && year % 100 != 0)
            {
                return true;
            }
            else if (year % 400 == 0)
            {
                return true;
            }

            return false;
        }

        public static int GetDaysInMonth(uint year, uint month)
        {
            if (month < 0 || month > 12 || year > 9999)
            {
                return -1;
            }

            if (month == 2)
            {
                if (IsLeapYear(year))
                {
                    return 29;
                }
                return 28;
            }
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                return 30;
            }
            else
            {
                return 31;
            }

            return -1;
        }
    }
}
