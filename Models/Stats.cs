using System.Reflection;

namespace DnD_Companion_blazor.Models;

public class Stats
{
    public Stat Strength { get; set; } = new Stat();
    public Stat Dexterity { get; set; } = new Stat();
    public Stat Constitution { get; set; } = new Stat();
    public Stat Intelligence { get; set; } = new Stat();
    public Stat Wisdom { get; set; } = new Stat();
    public Stat Charisma { get; set; } = new Stat();

    public int ProficiencyBonus { get; set; } = 2; // Default proficiency bonus

    public int PassiveWisdom => 10 + Wisdom.Modifier;
}

public static class StatsHelper
{
    public static IEnumerable<StatIdentifier> GetStatProperties(this Stats stats)
    {
        return stats.GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(Stat))
            .Select(p => new StatIdentifier() { Name = p.Name, Stat = (Stat)p.GetValue(stats)! });
    }
}

public class StatIdentifier
{
    public string Name { get; set; } = null!;
    public Stat Stat { get; set; } = new Stat();
}

public class Stat
{
    private int _value = 10;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            Modifier = CalculateModifier(_value);
        }
    }

    public int Modifier { get; private set; } = 0;
    public string ModifierString => Modifier >= 0 ? $"+{Modifier}" : $"-{Modifier}";

    public bool SaveProficiency { get; set; } = false;

    public Stat()
    {
        Value = 10; // This will set the default value and calculate the modifier
    }

    public Stat(int value)
    {
        Value = value; // This will set the default value and calculate the modifier
    }


    private int CalculateModifier(int value)
    {
        return (int)Math.Floor((value - 10) / 2.0);
    }

    public int GetSavingThrow(int proficiencyBonus)
    {
        return Modifier + (SaveProficiency ? proficiencyBonus : 0);
    }
}