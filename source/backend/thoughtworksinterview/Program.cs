using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoughtWorksInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] board = new char[] { 'E', 'E', 'J', 'H', 'E', 'T', 'J', 'T', 'E', 'E', 'H', 'J', 'T', 'H', 'E', 'E', 'J', 'H', 'E', 'T', 'J', 'T', 'E', 'E', 'H', 'J', 'T', 'H', 'J', 'E', 'E', 'J', 'H', 'E', 'T', 'J', 'T', 'E', 'E', 'H', 'J', 'T', 'E', 'H', 'E' };
            int[] dice = new int[] { 4, 4, 4, 6, 7, 8, 5, 11, 10, 12, 2, 3, 5, 6, 7, 8, 5, 11, 10, 12, 2, 3, 5, 6, 7, 8, 5, 11, 10, 12 };
            BusinessHouseGame game = new BusinessHouseGame();
            game.PlayBusinessHouseGame(3, board, dice);
            game.PrintResult();
            Console.ReadKey();
        }


    }

    public class BusinessHouseGame
    {
        Game game;

        public BusinessHouseGame()
        {
            game = new Game();
        }
        public void PlayBusinessHouseGame(int player, char[] cell, int[] dice)
        {
            game.InitiatePlaye(player);
            game.DesignBoard(cell);
            game.SetDice(dice);
            game.HotelRent = 50;
            game.HotelWorth = 200;
            game.JailFine = 150;
            game.TreasureValue = 200;
            game.StartGame();

        }

        public void PrintResult()
        {
            var result = game.GetPlayerList();
            int count = 1;
            foreach (var item in result)
            {
                Console.WriteLine("Player-{0} has totalworth {1}", count, item.BalanceAmount);
                count++;
            }
        }

    }

    public class Game
    {
        List<Player> PlayerList;
        Dictionary<int, Char> Board;
        Dictionary<int, char> OccupiedHotel;
        public int HotelWorth { get; set; }
        public int HotelRent { get; set; }
        public int JailFine { get; set; }
        public int TreasureValue { get; set; }

        int[] DiceValue;

        public Game()
        {
            PlayerList = new List<Player>();
            Board = new Dictionary<int, char>();
            OccupiedHotel = new Dictionary<int, char>();
        }

        public void DesignBoard(char[] cell)
        {
            for (int i = 0; i < cell.Length; i++)
            {
                Board.Add(i + 1, cell[i]);

            }
        }
        public void InitiatePlaye(int numberOfPlayer)
        {
            for (int i = 0; i < numberOfPlayer; i++)
            {
                PlayerList.Add(new Player());
            }
        }
        public void SetDice(int[] diceValue)
        {
            DiceValue = diceValue;
        }
        public void StartGame()
        {
            for (int i = 1; i <= this.DiceValue.Length;)
            {
                foreach (var player in this.PlayerList)
                {
                    //if (player.CurrentStats + this.DiceValue[i - 1] > this.Board.Count)
                    //    player.MaintainBalance(100);
                    var bordIndex = this.GetBoardIndex(player.CurrentStats, this.DiceValue[i - 1]);
                    player.CurrentStats = bordIndex;

                    this.ProceessCellResult(i, this.Board[bordIndex], player);
                    i++;
                }

                foreach (var item in this.PlayerList)
                {
                    Console.WriteLine("Player {0} - {1}", item.CurrentStats, item.BalanceAmount);
                }
            }

        }
        public List<Player> GetPlayerList()
        {
            return this.PlayerList.OrderByDescending(p => p.BalanceAmount).ToList();
        }
        private int GetBoardIndex(int currentIndex, int diceValue)
        {
            int boardLength = this.Board.Count;
            int currentStand;
            if ((currentIndex + diceValue) <= boardLength)
                currentStand = currentIndex + diceValue;
            else
            {
                currentStand = (currentIndex + diceValue) - boardLength;
            }
            return currentStand;
        }
        private void ProceessCellResult(int index, char cell, Player p)
        {
            switch (cell)
            {
                case 'H':
                    if (this.OccupiedHotel.ContainsKey(index))
                    {
                        if (p.IsOwnedHotel(index))
                            p.MaintainBalance(this.HotelRent);
                        else
                            p.MaintainBalance((-this.HotelRent));
                    }
                    else
                    {
                        if (p.BalanceAmount > this.HotelWorth)
                        {
                            this.OccupiedHotel.Add(index, 'H');
                            p.AddHotel(index);
                            p.MaintainBalance(-this.HotelWorth);
                        }
                    }
                    break;
                case 'J':
                    p.MaintainBalance((-this.JailFine));
                    break;
                case 'T':
                    p.MaintainBalance(this.TreasureValue);
                    break;
            }
        }
    }

    public class Player
    {
        public int BalanceAmount { get; set; }
        List<int> HotelList;

        public int CurrentStats { get; set; }
        public bool IsCompletedRound { get; set; }


        public Player()
        {
            this.BalanceAmount = 1000;
            this.IsCompletedRound = false;
            this.CurrentStats = 0;
            HotelList = new List<int>();
        }

        public void AddHotel(int index)
        {
            HotelList.Add(index);
        }

        public bool IsOwnedHotel(int index)
        {
            return this.HotelList.Contains(index);
        }

        public void MaintainBalance(int currentValue)
        {
            this.BalanceAmount = this.BalanceAmount + (currentValue);
        }
    }
}
