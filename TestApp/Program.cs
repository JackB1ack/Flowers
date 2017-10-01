using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int flowers = 0;
            int people = 0;
            bool check = true;
            bool flag = true;

            Console.WriteLine("Enter the number of flowers and people (please mention the order) \n" +
                              "Use space, comma or dot as delimiters");
            while (check)
            {
                try
                {
                    check = false;
                    string[] flowersAndPeopleStrings = Console.ReadLine().Trim().Split(',', '.', '\t', ' ');
                    if (flowersAndPeopleStrings.Length == 2)
                    {
                        flowers = Convert.ToInt32(flowersAndPeopleStrings[0]);
                        people = Convert.ToInt32(flowersAndPeopleStrings[1]);
                        if (flowers < 1 || (people > 100 || people == 0))
                            throw new Exception();
                    }
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Looks like you've entered something wrong. Please try again!");
                    check = true;
                }
            }
            int[] prices = new int[flowers];
            Console.WriteLine("Please enter flowers prices in one line\n" +
                              "Use space, comma or dot as delimiters");
            while (flag)
            {
                try
                {
                    flag = false;
                    string[] costsStrings = Console.ReadLine().Trim().Split(',', '.', '\t', ' ');
                    int i = 0;
                    if (costsStrings.Length == flowers)
                    {
                        foreach (var cost in costsStrings)
                        {
                            if (cost.Trim() != "" && Convert.ToInt32(cost) < 1000)
                            {
                                prices[i++] = Convert.ToInt32(cost);
                            }
                            else
                                throw new Exception();
                        }
                    }
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Looks like you've entered something wrong. Please try again!");
                    flag = true;
                }
            }
            Console.WriteLine(CalculateMinPrice(prices, flowers, people));
            Console.ReadKey();
        }
        public static long CalculateMinPrice(int[] prices, int flowers, int people)
        {
            Array.Sort(prices);
            Array.Reverse(prices);
            int x = 0;
            long summ = 0;
            for (int i = 0; i < flowers;)
            {
                for (int j = 0; j < people; j++)
                {
                    summ += (x + 1)*prices[i++];
                    if (i >= flowers)
                    {
                        break;
                    }
                }
                x++;
            }
            return summ;
        }
    }
}
