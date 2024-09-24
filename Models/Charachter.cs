namespace DnD_Companion_blazor.Models;

public class Character
{
    public string Name { get; set; } = null!;
    public string Race { get; set; } = null!;
    public string Class { get; set; } = null!;
    public int Level { get; set; } = 1;
    public string Background { get; set; } = null!;
    public string Alignment { get; set; } = null!;
    public int ExperiencePoints { get; set; } = 0;
    public Stats Stats { get; set; } = new Stats();
    public int ArmorClass { get; set; } = 0;
    public int Initiative => Stats.Dexterity.Modifier;
    public int Speed { get; set; } = 0;
    public int MaxHitPoints { get; set; } = 0;
    public int CurrentHitPoints { get; set; }
    public int TemporaryHitPoints { get; set; }
    public double HitPointPercentage => (double)CurrentHitPoints / MaxHitPoints;
    public List<string> HitDice { get; set; } = new List<string>();
    public List<Skill> Skills { get; set; } = new List<Skill>();
    public List<string> Proficiencies { get; set; } = new List<string>();
    public List<string> Languages { get; set; } = new List<string>();
    public List<Item> Equipment { get; set; } = new List<Item>();

    public Dictionary<string, int> Currency { get; set; } = new Dictionary<string, int>
    {
        { "CP", 0 }, { "SP", 0 }, { "EP", 0 }, { "GP", 0 }, { "PP", 0 }
    };

    public List<Feature> Features { get; set; } = new List<Feature>();
    public List<Spell> Spells { get; set; } = new List<Spell>();

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
}