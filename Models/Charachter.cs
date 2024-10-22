using System.Text.Json;

namespace DnD_Companion_blazor.Models;

[JsonSerializable(typeof(Character))]
public class Character
{
    [JsonPropertyName("name")] public string Name { get; set; } = null!;

    [JsonPropertyName("race")] public string Race { get; set; } = null!;

    [JsonPropertyName("class")] public string Class { get; set; } = null!;

    [JsonPropertyName("level")] public int Level { get; set; } = 1;

    [JsonPropertyName("background")] public string Background { get; set; } = null!;

    [JsonPropertyName("alignment")] public string Alignment { get; set; } = null!;

    [JsonPropertyName("experience_points")]
    public int ExperiencePoints { get; set; } = 0;

    [JsonPropertyName("stats")] public Stats Stats { get; set; } = new Stats();

    [JsonPropertyName("armor_class")] public int ArmorClass { get; set; } = 0;

    // No need to serialize computed properties
    public int Initiative() => Stats.Dexterity.Modifier;

    [JsonPropertyName("speed")] public int Speed { get; set; } = 0;

    [JsonPropertyName("max_hit_points")] public int MaxHitPoints { get; set; } = 0;

    [JsonPropertyName("current_hit_points")]
    public int CurrentHitPoints { get; set; }

    [JsonPropertyName("temporary_hit_points")]
    public int TemporaryHitPoints { get; set; }

    [JsonIgnore] // Computed properties are typically not serialized
    public double HitPointPercentage => (double)CurrentHitPoints / MaxHitPoints;

    [JsonPropertyName("hit_dice")] public List<string> HitDice { get; set; } = new List<string>();

    [JsonPropertyName("skills")] public List<Skill> Skills { get; set; } = new List<Skill>();

    [JsonPropertyName("proficiencies")] public List<string> Proficiencies { get; set; } = new List<string>();

    [JsonPropertyName("languages")] public List<string> Languages { get; set; } = new List<string>();

    [JsonPropertyName("equipment")] public List<Item> Equipment { get; set; } = new List<Item>();

    public string Inventory { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the additional notes or comments for the character. This can include background information, story elements, or any other relevant details that the player or game master wishes to keep track of.,
    /// Perhaps even special story related items or events.
    /// </summary>
    public string Notes { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public Dictionary<string, int> Currency { get; set; } = new Dictionary<string, int>
    {
        { "CP", 0 }, { "SP", 0 }, { "EP", 0 }, { "GP", 0 }, { "PP", 0 }
    };

    [JsonPropertyName("features")] public List<Feature> Features { get; set; } = new List<Feature>();

    [JsonPropertyName("spells")] public List<Spell> Spells { get; set; } = new List<Spell>();

    public Character()
    {
        Stats = new Stats();
        InitializeSkills();
    }

    public Character(Stats stats)
    {
        Stats = stats;
        InitializeSkills();
    }

    private void InitializeSkills()
    {
        Skills = new List<Skill>
        {
            new Skill("Acrobatics", Stats.Dexterity),
            new Skill("Animal Handling", Stats.Wisdom),
            new Skill("Arcana", Stats.Intelligence),
            new Skill("Athletics", Stats.Strength),
            new Skill("Deception", Stats.Charisma),
            new Skill("History", Stats.Intelligence),
            new Skill("Insight", Stats.Wisdom),
            new Skill("Intimidation", Stats.Charisma),
            new Skill("Investigation", Stats.Intelligence),
            new Skill("Medicine", Stats.Wisdom),
            new Skill("Nature", Stats.Intelligence),
            new Skill("Perception", Stats.Wisdom),
            new Skill("Performance", Stats.Charisma),
            new Skill("Persuasion", Stats.Charisma),
            new Skill("Religion", Stats.Intelligence),
            new Skill("Sleight of Hand", Stats.Dexterity),
            new Skill("Stealth", Stats.Dexterity),
            new Skill("Survival", Stats.Wisdom)
        };
    }

    public int GetSkillModifier(string skillName)
    {
        var skill = Skills.Find(s => s.Name.Equals(skillName, StringComparison.OrdinalIgnoreCase));
        return skill?.GetModifier(Stats.ProficiencyBonus) ??
               throw new ArgumentException("Skill not found", nameof(skillName));
    }

    public void LevelUp()
    {
        Level++;
        // Additional logic for leveling up (e.g., increasing hit points, updating proficiency bonus)
    }

    public void TakeDamage(int damage)
    {
        if (TemporaryHitPoints > 0)
        {
            if (damage > TemporaryHitPoints)
            {
                damage -= TemporaryHitPoints;
                TemporaryHitPoints = 0;
                CurrentHitPoints -= damage;
            }
            else
            {
                TemporaryHitPoints -= damage;
            }
        }
        else
        {
            CurrentHitPoints -= damage;
        }

        if (CurrentHitPoints < 0)
            CurrentHitPoints = 0;
    }

    public void Heal(int amount)
    {
        CurrentHitPoints += amount;
        if (CurrentHitPoints > MaxHitPoints)
            CurrentHitPoints = MaxHitPoints;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (Character)obj;

        var thisJson = JsonSerializer.Serialize(this);

        var otherJson = JsonSerializer.Serialize(other);

        return thisJson == otherJson;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Race, Class, Level, Background, Alignment, ExperiencePoints, Stats);
    }
}