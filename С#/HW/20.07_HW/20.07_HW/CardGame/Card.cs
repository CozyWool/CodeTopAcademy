using _20._07_HW.CardGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._07_HW.CardGame
{
    public class Card : IComparable<Card>
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString() 
        { 
            StringBuilder sb = new StringBuilder();
            switch (Value)
            {
                case CardValue.Six:
                    sb.Append('6');
                    break;
                case CardValue.Seven:
                    sb.Append('7');
                    break;
                case CardValue.Eight:
                    sb.Append('8');
                    break;
                case CardValue.Nine:
                    sb.Append('9');
                    break;
                case CardValue.Ten:
                    sb.Append("10");
                    break;
                case CardValue.Jack:
                    sb.Append("Валет");
                    break;
                case CardValue.Queen:
                    sb.Append("Королева");
                    break;
                case CardValue.King:
                    sb.Append("Король");
                    break;
                case CardValue.Ace:
                    sb.Append("Туз");
                    break;
                default:
                    break;
            }
            switch (Suit)
            {
                case CardSuit.Hearts:
                    sb.Append('♥');
                    break;
                case CardSuit.Clubs:
                    sb.Append('♣');
                    break;
                case CardSuit.Spades:
                    sb.Append('♠');
                    break;
                case CardSuit.Diamonds:
                    sb.Append('♦');
                    break;
                default:
                    break;
            }
            return sb.ToString();
        }
        public int CompareTo(Card? card)
        {
            if (Value == CardValue.Six && card.Value == CardValue.Ace) return 1;
            if (card.Value == CardValue.Six && Value == CardValue.Ace) return -1;
            return Value.CompareTo(card.Value);
        }

        public static bool operator >(Card? operand1, Card? operand2) => operand1.CompareTo(operand2) > 0;
        public static bool operator <(Card? operand1, Card? operand2) => operand1.CompareTo(operand2) < 0;
        public static bool operator >=(Card? operand1, Card? operand2) => operand1.CompareTo(operand2) >= 0;
        public static bool operator <=(Card? operand1, Card? operand2) => operand1.CompareTo(operand2) <= 0;
        public static bool operator ==(Card? operand1, Card? operand2) => operand1.CompareTo(operand2) == 0;
        public static bool operator !=(Card? operand1, Card? operand2) => operand1.CompareTo(operand2) != 0;
    }
}
