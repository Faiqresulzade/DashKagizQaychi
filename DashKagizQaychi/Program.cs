using System;
using System.Threading;

namespace DashKagizQaychi
{
    class Program
    {
        static void Main(string[] args)
        {
            KQDGame myGame=new KQDGame();
            myGame.Play();
        }
    }

    abstract class Game
    {
        public void Play()
        {
           Start();
            Initializer();

            while(!HasWinner())
            {
                Start();
            }
        }
        public abstract void Start();
        public abstract void Initializer();
        public abstract bool HasWinner();
        public abstract void TakeTurn(string result1, string result2);
    }
    class KQDGame : Game
    {
        private int _countOne;
        private int _countTwo;
        public override bool HasWinner()
        {
            if (_countOne == 3 && _countOne > _countTwo)
            {
                Console.WriteLine("Birinci oyunchu qalib geldi");
                return true;
            }
            if (_countTwo == 3 && _countTwo > _countOne)
            {
                Console.WriteLine("Ikinci oyunchu qalib geldi");
                return true;
            }
            return false ;
        }
        public override void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Oyun Bashlayir!");
            Thread.Sleep(2000);
            Console.ResetColor();
            Initializer();
        }
        public override void Initializer()
        {
            Console.WriteLine("Birinci oyunchu oynayir");
            Console.WriteLine("1.Kagiz \n" +
                "2.Dash \n" +
                "3.Qaychi");
            string result = Console.ReadLine();
            Console.WriteLine("Ikinci oyunchu oynayir");
            Console.WriteLine("1.Kagiz \n" +
                "2.Dash \n" +
                "3.Qaychi");
            string resultPlayer2 = Console.ReadLine()
            ;
            TakeTurn(result, resultPlayer2);
        }
        public override void TakeTurn(string result, string resultPlayer2)
        {
            if (resultPlayer2 == result)
            {
                Initializer();
            }
            if(resultPlayer2=="1" && result == "2")
            {
                _countTwo++;
               // Console.WriteLine("2");
            }
            if (resultPlayer2 == "1" && result == "3")
            {
                _countOne++;
            }
            if (resultPlayer2 == "2" && result == "1")
            {
                _countOne++;
            }
            if (resultPlayer2 == "2" && result == "3")
            {
                _countTwo++;
            }
            if (resultPlayer2 == "3" && result == "1")
            {
                _countTwo++;
            }
            if (resultPlayer2 == "3" && result == "2")
            {
                _countOne++;
            }
        }
    }

}
