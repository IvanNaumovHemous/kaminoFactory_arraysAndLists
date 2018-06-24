using System;
using System.Collections.Generic;
using System.Linq;

namespace kaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();         

            List<int> clones = GetClonings(input);
            PrintClones(clones);
            
        }

        static List<int> GetClonings(string input)
        {
            int count = 1, maxCount = 1, sum = 0, index = 0, DNASample = 0, maxDNASample = 0;
            List<int> maxList = new List<int>();

            while (input != "Clone them!")
            {
                DNASample++;
                var clonesData = input.Split('!').Select(int.Parse).ToList();                

                for (int i = 0; i < clonesData.Count - 1; i++)
                {
                    if (clonesData[i] == clonesData[i + 1] && clonesData[i] == 1)
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }

                    if (count > maxCount)
                    {
                        sum = clonesData.Sum();
                        index = i;
                        maxCount = count;
                        maxList = clonesData;
                        maxDNASample = DNASample;
                    }
                    else if (count == maxCount)
                    {
                        if (i < index)
                        {
                            sum = clonesData.Sum();
                            maxList = clonesData;
                            maxDNASample = DNASample;
                        }
                        else if (i == index)
                        {
                            if (clonesData.Sum() > sum)
                            {
                                maxList = clonesData;
                                sum = clonesData.Sum();
                                maxDNASample = DNASample;
                            }
                        }
                    }                                   
                }
              
                input = Console.ReadLine();
            }

            Console.WriteLine("Best DNA sample {0} with sum: {1}.", maxDNASample, sum);
            return maxList;
        }

        static void PrintClones(List<int> clones)
        {          
            foreach (var item in clones)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
