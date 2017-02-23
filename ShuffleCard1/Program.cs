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
            const int TOTALCARDS = 9;
            int[] nCards = new int[TOTALCARDS];
            int[] stack1 = new int[(TOTALCARDS / 2) + 1];
            int[] stack2 = new int[(TOTALCARDS / 2)];
            int[] ShuffledCards = new int[TOTALCARDS];            
            int j = 0;
            int totalIterations = 0;
                        
            Console.WriteLine("Total cards: {0}", TOTALCARDS);

            // Generate new deck of cards
            for (int i = 0; i < TOTALCARDS; i++)
            {
                nCards[i] = i;
            }
            
            // if the total number of cards is odd       
            // split the deck of card into two stacks:
            // stack1 = m+1 and stack2 = m
            if (TOTALCARDS % 2 != 0)
            {
                for (int i = 0; i < TOTALCARDS; i++)
                {
                    if (i <= TOTALCARDS / 2)
                    {
                        stack1[i] = nCards[i];
                        Console.Write("{0} ", stack1[i]);
                    }
                    else
                    {
                        j = i - (TOTALCARDS / 2) - 1;
                        stack2[j] = nCards[i];
                        Console.Write("{0} ", stack2[j]);
                    }
                }
            }
           
            while(!ArrayMatch(nCards, ShuffledCards))
            {
                ShuffledCards = Shuffle(stack1, stack2);
                PrintShuffleResult(ShuffledCards);
                // split the deck of card into two stacks:
                // stack1 and stack2
                for (int i = 0; i < TOTALCARDS; i++)
                {
                    if (i <= TOTALCARDS / 2)
                    {
                        stack1[i] = ShuffledCards[i];
                    }
                    else
                    {
                        j = i - (TOTALCARDS / 2) - 1;
                        stack2[j] = ShuffledCards[i];
                    }
                }
                totalIterations++;
            }

            Console.WriteLine("\n\nTotal Iterations: {0}", totalIterations);
            Console.ReadLine();
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
                if(n[i] != m[i])
                {
                    match = false;
                    break;
                }
            }
            return match;
        }
    }
}
