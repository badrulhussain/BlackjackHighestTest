using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackHighest
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackjackHighest(new string[] { "four", "ace", "ten" });

            // BlackjackHighest(new string[] { "ace", "queen" });
        }
        public static string BlackjackHighest(string[] strArr)
        {

            // code goes here  
            /* Note: In C# the return type of a function and the 
               parameter types being passed are defined, so this return 
               call must match the return type of the function.
               You are free to modify the return type. */

            var outPut = new StringBuilder();

            var deck = new Dictionary<string, int>();
            deck.Add("ace", 1);
            deck.Add("two", 2);
            deck.Add("three", 3);
            deck.Add("four", 4);
            deck.Add("five", 5);
            deck.Add("six", 6);
            deck.Add("seven", 7);
            deck.Add("eight", 8);
            deck.Add("nine", 9);
            deck.Add("ten", 10);
            deck.Add("jack", 11);
            deck.Add("queen", 12);
            deck.Add("king", 13);

            var count = 0;
            var topCard = 0;
            var isAce = false;

            foreach (var hand in strArr)
            {
                foreach (var card in deck)
                {
                    if (hand == card.Key)
                    {
                        if (card.Value >= 11)
                        {
                            count += 10;
                        }
                        else
                        {
                            count += card.Value;
                        }

                        if (card.Value >= topCard)
                        {
                            topCard = card.Value;
                        }

                        if (card.Value == 1)
                        {
                            isAce = true;
                        }
                    }
                }
            }

            var faceCard = GetTopCard(deck, topCard);

            if (isAce && count <= 20)
            {
                count += 10;
                if (count == 21)
                {
                    faceCard = "ace";
                }
                else if (count >= 22)
                {
                    count -= 10;
                }
            }


            if (count <= 20)
            {
                outPut.Append(string.Format("below {0}", faceCard));
            }
            else if (count >= 22)
            {
                outPut.Append(string.Format("above {0}", faceCard));
            }
            else
            {
                outPut.Append(string.Format("blackjack {0}", faceCard));
            }

            Console.WriteLine(outPut.ToString());

            return outPut.ToString();

        }

        public static string GetTopCard(Dictionary<string, int> deck, int topCard)
        {
            foreach (var card in deck)
            {
                if (card.Value == topCard)
                {
                    return card.Key.ToString();
                }
            }

            return null;
        }
    }
}
