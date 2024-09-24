namespace DnD_Companion.Models;

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
    public bool SaveProficiency { get; set; } = false;

    public Stat()
    {
        Value = 10; // This will set the default value and calculate the modifier
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