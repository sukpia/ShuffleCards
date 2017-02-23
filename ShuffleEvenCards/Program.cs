// 2/23/2017
// Given one deck of cards with odd numbers of cards
// Split the cards into two stack of M+1 cards and M cards
// Shuffle the two stacks by interlacing them.
// How many shuffle is needed so the cards will go back to the original order.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleCard1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }      
        }

        private static void Play()
        {
            Console.Write("\nEnter an Even number to generate a deck of card: ");
            int n = int.Parse(Console.ReadLine());

            // if the total number of cards is odd       
            // split the deck of card into two stacks:
            // stack1 = m+1 and stack2 = m
            if (n % 2 == 0)
            {
                //const int TOTALCARDS = 18;
                int[] nCards = new int[n];
                int[] stackEven1 = new int[(n / 2)];
                int[] stackEven2 = new int[n / 2];
                int[] ShuffledCards = new int[n];
                int j = 0;
                int totalIterations = 0;

                // Generate new deck of cards
                for (int i = 0; i < n; i++)
                {
                    nCards[i] = i;
                }

                for (int i = 0; i < n; i++)
                {
                    if (i < n / 2)
                    {
                        stackEven1[i] = nCards[i];
                        //Console.Write("{0} ", stack1[i]);
                    }
                    else
                    {
                        j = i - (n / 2);
                        stackEven2[j] = nCards[i];
                        //Console.Write("{0} ", stack2[j]);
                    }
                }

                while (!ArrayMatch(nCards, ShuffledCards))
                {
                    ShuffledCards = Shuffle(stackEven1, stackEven2);
                    PrintShuffleResult(ShuffledCards);
                    for (int i = 0; i < n; i++)
                    {
                        if (i < n / 2)
                        {
                            stackEven1[i] = ShuffledCards[i];
                            //Console.Write("{0} ", stack1[i]);
                        }
                        else
                        {
                            j = i - (n / 2);
                            stackEven2[j] = ShuffledCards[i];
                            //Console.Write("{0} ", stack2[j]);
                        }
                    }
                    totalIterations++;
                }
                Console.WriteLine("\n\nTotal Iterations: {0}", totalIterations);
            }
            else
            {
                Console.WriteLine("Please enter an Even number!");
            }

            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Count number of times to shuffle cards back to original stack.");
            Console.WriteLine("2) Exit");
            string result = Console.ReadLine();

            if(result == "1")
            {
                Play();
                return true;
            }
            else if (result == "2")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private static int[] Shuffle(int[] s1, int[] s2)
        {
            int j;
            int total = s1.Length + s2.Length;
            int[] sCards = new int[total];
            // shuffle the card
            for (int i = 0; i < total; i++)
            {
                j = i % 2;
                if (j == 0) //even
                {
                    sCards[i] = s1[i / 2];
                }
                else //odd
                {
                    sCards[i] = s2[i / 2];
                }
            }
            return sCards;
        }
        private static void PrintShuffleResult(int[] s)
        {
            Console.Write("\nShuffle Result: ");
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write("{0} ", s[i]);
            }
        }

        private static bool ArrayMatch(int[] n, int[] m)
        {
            bool match = true;

            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] != m[i])
                {
                    match = false;
                    break;
                }
            }
            return match;
        }
    }
}
