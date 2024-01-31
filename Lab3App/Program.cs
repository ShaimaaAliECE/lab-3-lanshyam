using System;
using System.Collections.Generic;

namespace Lab3App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CollectionBoard board = new CollectionBoard();

            List<Collectable> possibleCollectiable = new List<Collectable>();

            possibleCollectiable.Add(new Coin("Nickel", score: 20, value: 5)); // values and scores
            possibleCollectiable.Add(new Coin("Dime", score: 40, value: 10));
            possibleCollectiable.Add(new Coin("Toony", score: 50, value: 100));


            for (int i = 1; i <= 5; i++)
            {
                possibleCollectiable.Add(new Diamond("Diamond" + i, score: 100));
            }


            possibleCollectiable.Add(new Axe("OnlyAxe"));

            possibleCollectiable.Add(new MagicWand("OnlyMagicWand"));

            foreach (Collectable collectable in possibleCollectiable)
            {
                collectable.Board = board;
            }

            List<Collectable> collected = new List<Collectable>();


            foreach (Collectable collectable in possibleCollectiable)
            {
                collectable.AddMe(collected);
            }

            Console.WriteLine("========================================");
            Console.WriteLine("==== All the Collected items ===========");
            Console.WriteLine("========================================");

            foreach (Collectable collectable in collected)
            {
                collectable.Display();
            }
        }
    }

    internal class CollectionBoard
    {
        public int TotalScore { get; set; }
        public int TotalValue { get; set; }

        public CollectionBoard()
        {
            TotalScore = 0;
            TotalValue = 0;
        }
    }


    internal abstract class Collectable
    {
        public string Description { get; protected set; }
        public int Score { get; protected set; }
        public int Value { get; protected set; }
        public CollectionBoard Board { get; set; }

        public Collectable(string description, int score, int value)
        {
            Description = description;
            Score = score;
            Value = value;
        }

        public abstract void AddMe(List<Collectable> collected);
        public abstract void Display();
    }

    internal class Coin : Collectable
    {
        public Coin(string description, int score, int value) : base(description, score, value)
        {
        }

        public override void AddMe(List<Collectable> collected)
        {
            collected.Add(this);
            Console.WriteLine($"{Description} Collected, Congrats!!!!");
            Console.WriteLine($"Total Score is updated to: {Board.TotalScore += Score}");
            Console.WriteLine($"Total Value is updated to: {Board.TotalValue += Value}");
        }

        public override void Display()
        {
            Console.WriteLine($"Coin {Description} is displayed");
        }
    }

    internal class Diamond : Collectable
    {
        public Diamond(string description, int score) : base(description, score, value: 0)
        {
        }

        public override void AddMe(List<Collectable> collected)
        {
            collected.Add(this);
            Console.WriteLine($"{Description} Collected, Congrats!!!!");
            Console.WriteLine($"Total Score is updated to: {Board.TotalScore += Score}");
        }

        public override void Display()
        {
            Console.WriteLine($"Diamond{Description} is displayed");
        }
    }

    internal class Axe : Collectable
    {
        public Axe(string description) : base(description, score: 0, value: 0)
        {
        }

        public override void AddMe(List<Collectable> collected)
        {
            collected.Add(this);
            Console.WriteLine($"{Description} Collected, Congrats!!!!");
            Console.WriteLine($"{Description} is Used");
        }

        public override void Display()
        {
            Console.WriteLine($"Axe {Description} is displayed");
        }
    }

    internal class MagicWand : Collectable
    {
        public MagicWand(string description) : base(description, score: 0, value: 0)
        {
        }

        public override void AddMe(List<Collectable> collected)
        {
            collected.Add(this);
            Console.WriteLine($"{Description} Collected, Congrats!!!!");
            Console.WriteLine($"{Description} is used");
        }

        public override void Display()
        {
            Console.WriteLine($"MagicWand {Description} is displayed");
            Console.WriteLine("Press any key to continue . . . ");
        }
    }
}
