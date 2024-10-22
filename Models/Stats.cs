namespace DnD_Companion_blazor.Models;

[JsonSerializable(typeof(Stats))]
public class Stats
{
    public Stats()
    {
    }

    // Add this indexer to access properties by name
    [JsonIgnore]
    public Stat this[string name]
    {
        get
        {
            return name.ToLower() switch
            {
                "strength" => Strength,
                "dexterity" => Dexterity,
                "constitution" => Constitution,
                "intelligence" => Intelligence,
                "wisdom" => Wisdom,
                "charisma" => Charisma,
                _ => throw new ArgumentException($"Invalid stat name: {name}", nameof(name)),
            };
        }
        set
        {
            switch (name.ToLower())
            {
                case "strength":
                    Strength = value;
                    break;
                case "dexterity":
                    Dexterity = value;
                    break;
                case "constitution":
                    Constitution = value;
                    break;
                case "intelligence":
                    Intelligence = value;
                    break;
                case "wisdom":
                    Wisdom = value;
                    break;
                case "charisma":
                    Charisma = value;
                    break;
                default:
                    throw new ArgumentException($"Invalid stat name: {name}", nameof(name));
            }
        }
    }

    [JsonPropertyName("strength")] public Stat Strength { get; set; } = new Stat();

    [JsonPropertyName("dexterity")] public Stat Dexterity { get; set; } = new Stat();

    [JsonPropertyName("constitution")] public Stat Constitution { get; set; } = new Stat();

    [JsonPropertyName("intelligence")] public Stat Intelligence { get; set; } = new Stat();

    [JsonPropertyName("wisdom")] public Stat Wisdom { get; set; } = new Stat();

    [JsonPropertyName("charisma")] public Stat Charisma { get; set; } = new Stat();

    [JsonPropertyName("proficiency_bonus")]
    public int ProficiencyBonus { get; set; } = 2; // Default proficiency bonus

    [JsonPropertyName("passive_wisdom")] public int PassiveWisdom => 10 + Wisdom.Modifier;
}

public static class StatsHelper
{
    public static IEnumerable<StatIdentifier> GetStatProperties(this Stats stats)
    {
        return stats.GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(Stat) && p.GetIndexParameters().Length == 0 && !p.IsSpecialName)
            .Select(p => new StatIdentifier() { Name = p.Name, Stat = (Stat)p.GetValue(stats)! });
    }
}

public class StatIdentifier
{
    public string Name { get; set; } = null!;
    public Stat Stat { get; set; } = new Stat();
}

[JsonSerializable(typeof(Stat))]
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