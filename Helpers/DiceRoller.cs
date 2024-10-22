namespace DnD_Companion_blazor.Helpers;

public static class DiceRoller
{
    internal class Dice(int sides)
    {
        private int Sides { get; init; } = sides;

        public int Roll(bool advantage = false, bool disadvantage = false)
        {
            if (advantage && disadvantage)
            {
                throw new ArgumentException("Cannot have advantage and disadvantage at the same time.");
            }

            int roll1 = Roll(Sides);
            int roll2 = Roll(Sides);

            return advantage ? Math.Max(roll1, roll2) : disadvantage ? Math.Min(roll1, roll2) : roll1;
        }

        public static int Roll(int sides)
        {
            return new Random().Next(1, sides + 1);
        }
    }

    public static int RollD4(bool advantage = false, bool disadvantage = false)
    {
        return new Dice(4).Roll(advantage, disadvantage);
    }

    public static int RollD6(bool advantage = false, bool disadvantage = false)
    {
        return new Dice(6).Roll(advantage, disadvantage);
    }

    public static int RollD8(bool advantage = false, bool disadvantage = false)
    {
        return new Dice(8).Roll(advantage, disadvantage);
    }

    public static int RollD10(bool advantage = false, bool disadvantage = false)
    {
        return new Dice(10).Roll(advantage, disadvantage);
    }

    public static int RollD12(bool advantage = false, bool disadvantage = false)
    {
        return new Dice(12).Roll(advantage, disadvantage);
    }

    public static int RollD20(bool advantage = false, bool disadvantage = false)
    {
        return new Dice(20).Roll(advantage, disadvantage);
    }
}