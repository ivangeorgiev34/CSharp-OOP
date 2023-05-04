using System;
using System.Collections.Generic;

namespace _03.Cards
{
   public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    string[] tokens = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Card card = new Card(tokens[0], tokens[1]);
                    cards.Add(card);
                }
                catch (ArgumentException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            for (int i = 0; i < cards.Count; i++)
            {
                Console.Write($"{cards[i].ToString()} ");
            }
        }
    }
    public class Card
    {
        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }
        private string face;

        public string Face
        {
            get { return face; }
            private set
            {
                if (value == "2")
                {
                    value = "2";
                    face = value;
                }
                else if (value == "3")
                {
                    value = "3";
                    face = value;
                }
                else if (value == "4")
                {
                    value = "4";
                    face = value;
                }
                else if (value == "5")
                {
                    value = "5";
                    face = value;
                }
                else if (value == "6")
                {
                    value = "6";
                    face = value;
                }
                else if (value == "7")
                {
                    value = "7";
                    face = value;
                }
                else if (value == "8")
                {
                    value = "8";
                    face = value;
                }
                else if (value == "9")
                {
                    value = "9";
                    face = value;
                }
                else if (value == "10")
                {
                    value = "10";
                    face = value;
                }
                else if (value == "J")
                {
                    value = "J";
                    face = value;
                }
                else if (value == "Q")
                {
                    value = "Q";
                    face = value;
                }
                else if (value == "K")
                {
                    value = "K";
                    face = value;
                }
                else if (value == "A")
                {
                    value = "A";
                    face = value;
                }
                else
                {
                    throw new ArgumentException("Invalid card!");
                }
            }
        }

        private string suit;

        public string Suit
        {
            get { return suit; }
            private set
            {
                if (value == "S")
                {
                    value = "♠";
                    suit = value;
                }
                else if (value == "H")
                {
                    value = "♥";
                    suit = value;
                }
                else if (value == "D")
                {
                    value = "♦";
                    suit = value;
                }
                else if (value == "C")
                {
                    value = "♣";
                    suit = value;
                }
                else
                {
                    throw new ArgumentException("Invalid card!");
                }
            }
        }
        public override string ToString()
        {
            return $"[{face}{suit}]";
        }
    }
}
