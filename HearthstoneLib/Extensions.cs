using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static PlayerTurn Opossite(this PlayerTurn player)
        {
            return (player == PlayerTurn.Player1 ? PlayerTurn.Player2 : PlayerTurn.Player1);
        }

        public static T GetRandomItem<T>(this IList<T> list)
        {
            Random rng = new Random();
            return list[rng.Next(list.Count)];
        }

        public static string ToCoolString(this IList<Card> cards)
        {
            string text = "[";
            foreach (Card c in cards)
            {
                text = text + c.ToString() + ", ";
            }
            if (text.Length > 1)
            {
                text = text.Remove(text.Length - 2, 2);
            }
            return text + "]";
        }

        public static string ToCoolString(this PlayerTurn player)
        {
            return (player == PlayerTurn.Player1 ? "Player 1" : "Player 2");
        }
    }
}
