using _20._07_HW.CardGame.Enums;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace _20._07_HW.CardGame
{
    public class CardGame
    {
        public List<Card> Cards { get; set; } = new List<Card>()
        {
            new Card(CardSuit.Spades,CardValue.Six),
            new Card(CardSuit.Spades,CardValue.Seven),
            new Card(CardSuit.Spades,CardValue.Eight),
            new Card(CardSuit.Spades,CardValue.Nine),
            new Card(CardSuit.Spades,CardValue.Ten),
            new Card(CardSuit.Spades,CardValue.Jack),
            new Card(CardSuit.Spades,CardValue.Queen),
            new Card(CardSuit.Spades,CardValue.King),
            new Card(CardSuit.Spades,CardValue.Ace),

            new Card(CardSuit.Hearts,CardValue.Six),
            new Card(CardSuit.Hearts,CardValue.Seven),
            new Card(CardSuit.Hearts,CardValue.Eight),
            new Card(CardSuit.Hearts,CardValue.Nine),
            new Card(CardSuit.Hearts,CardValue.Ten),
            new Card(CardSuit.Hearts,CardValue.Jack),
            new Card(CardSuit.Hearts,CardValue.Queen),
            new Card(CardSuit.Hearts,CardValue.King),
            new Card(CardSuit.Hearts,CardValue.Ace),

            new Card(CardSuit.Diamonds,CardValue.Six),
            new Card(CardSuit.Diamonds,CardValue.Seven),
            new Card(CardSuit.Diamonds,CardValue.Eight),
            new Card(CardSuit.Diamonds,CardValue.Nine),
            new Card(CardSuit.Diamonds,CardValue.Ten),
            new Card(CardSuit.Diamonds,CardValue.Jack),
            new Card(CardSuit.Diamonds,CardValue.Queen),
            new Card(CardSuit.Diamonds,CardValue.King),
            new Card(CardSuit.Diamonds,CardValue.Ace),

            new Card(CardSuit.Clubs,CardValue.Six),
            new Card(CardSuit.Clubs,CardValue.Seven),
            new Card(CardSuit.Clubs,CardValue.Eight),
            new Card(CardSuit.Clubs,CardValue.Nine),
            new Card(CardSuit.Clubs,CardValue.Ten),
            new Card(CardSuit.Clubs,CardValue.Jack),
            new Card(CardSuit.Clubs,CardValue.Queen),
            new Card(CardSuit.Clubs,CardValue.King),
            new Card(CardSuit.Clubs,CardValue.Ace),
        };

        public List<Player> PlayerList = new();
        public bool IsEnd { get; private set; } = false;

        public CardGame(List<Player> playerList)
        {
            PlayerList = playerList;
        }

        public void Start()
        {
            Cards.Shuffle();
            int index = 0;
            foreach (var player in PlayerList)
            {
                for (int i = index; i < Cards.Count / PlayerList.Count + index; i++)
                {
                    player.Hand.Add(Cards[i]);
                }
                index += Cards.Count / PlayerList.Count;
            }
        }

        public void ShowPlayers()
        {
            foreach (var player in PlayerList)
            {
                Console.WriteLine(player);
            }
        }
        
        public void NextTurn()
        {
            if (PlayerList.Count == 1)
            {
                Win(PlayerList[0]);
                return;
            }
            Dictionary<Player,Card> cardsOnTable = new();
            foreach (var player in PlayerList)
            {
                Card? card = player.AskCard();
                if (card is not null)
                    cardsOnTable.Add(player,card);
                else
                {
                    Console.WriteLine($"У {player.Name} закончились карты и он выбывает из игры!");
                    PlayerList.Remove(player);
                    break;
                }
            }
            Console.WriteLine("\tКарты на столе");
            foreach (var (player, card) in cardsOnTable)
            {
                Console.WriteLine($"{player.Name}: {card}");
            }
            Card? maxCard = cardsOnTable.Values.Max();
            var winner = cardsOnTable.Where(player => player.Value == maxCard).First().Key;

            Console.WriteLine($"Игрок {winner.Name} забирает все карты!");
            foreach (var (player, card) in cardsOnTable)
            {
                if (player == winner)
                    continue;
                winner.Hand.Add(card);
                player.Hand.Remove(card);
            }
        }

        public void Win(Player winner)
        {
            Console.WriteLine($"{winner.Name} побеждает!");
            IsEnd = true;
        }
    }

    public static class ListExtensions
    {
        // https://ru.wikipedia.org/wiki/Тасование_Фишера_—_Йетса
        public static void Shuffle<T>(this List<T> list)
        {
            Random random = new();
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
