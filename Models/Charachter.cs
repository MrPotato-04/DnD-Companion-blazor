using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DnD_Companion.Models;

public class Character : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }

    private string _name = null!;

    public string Race
    {
        get => _race;
        set
        {
            if (_race != value)
            {
                _race = value;
                OnPropertyChanged();
            }
        }
    }

    private string _race = null!;

    public string Class
    {
        get => _class;
        set
        {
            if (_class != value)
            {
                _class = value;
                OnPropertyChanged();
            }
        }
    }

    private string _class = null!;

    public int Level
    {
        get => _level;
        set
        {
            if (_level != value)
            {
                _level = value;
                OnPropertyChanged();
            }
        }
    }

    private int _level = 1;

    public string Background
    {
        get => _background;
        set
        {
            if (_background != value)
            {
                _background = value;
                OnPropertyChanged();
            }
        }
    }

    private string _background = null!;

    public string Alignment
    {
        get => _alignment;
        set
        {
            if (_alignment != value)
            {
                _alignment = value;
                OnPropertyChanged();
            }
        }
    }

    private string _alignment = null!;

    public int ExperiencePoints
    {
        get => _experiencePoints;
        set
        {
            if (_experiencePoints != value)
            {
                _experiencePoints = value;
                OnPropertyChanged();
            }
        }
    }

    private int _experiencePoints = 0;

    public Stats Stats
    {
        get => _stats;
        set
        {
            if (_stats != value)
            {
                _stats = value;
                OnPropertyChanged();
            }
        }
    }

    private Stats _stats = new Stats();


    public int ArmorClass
    {
        get => _armorClass;
        set
        {
            if (_armorClass != value)
            {
                _armorClass = value;
                OnPropertyChanged();
            }
        }
    }

    private int _armorClass = 0;

    public int Initiative => Stats.Dexterity.Modifier;

    public int Speed
    {
        get => _speed;
        set
        {
            if (_speed != value)
            {
                _speed = value;
                OnPropertyChanged();
            }
        }
    }

    private int _speed = 0;

    public int MaxHitPoints
    {
        get => _maxHitPoints;
        set
        {
            if (_maxHitPoints != value)
            {
                _maxHitPoints = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HitPointPercentage));
            }
        }
    }

    private int _maxHitPoints = 0;

    private int _currentHitPoints;

    public int CurrentHitPoints
    {
        get => _currentHitPoints;
        set
        {
            if (_currentHitPoints != value)
            {
                _currentHitPoints = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HitPointPercentage));
            }
        }
    }

    public int TemporaryHitPoints
    {
        get => _temporaryHitPoints;
        set
        {
            if (_temporaryHitPoints != value)
            {
                _temporaryHitPoints = value;
                OnPropertyChanged();
            }
        }
    }

    private int _temporaryHitPoints;

    public double HitPointPercentage => (double)CurrentHitPoints / MaxHitPoints;

    public List<string> HitDice
    {
        get => _hitDice;
        set
        {
            if (_hitDice != value)
            {
                _hitDice = value;
                OnPropertyChanged();
            }
        }
    }

    private List<string> _hitDice = new List<string>();

    public List<Skill> Skills
    {
        get => _skills;
        set
        {
            if (_skills != value)
            {
                _skills = value;
                OnPropertyChanged();
            }
        }
    }

    private List<Skill> _skills = new List<Skill>();

    public List<string> Proficiencies
    {
        get => _proficiencies;
        set
        {
            if (_proficiencies != value)
            {
                _proficiencies = value;
                OnPropertyChanged();
            }
        }
    }

    private List<string> _proficiencies = new List<string>();

    public List<string> Languages
    {
        get => _languages;
        set
        {
            if (_languages != value)
            {
                _languages = value;
                OnPropertyChanged();
            }
        }
    }

    private List<string> _languages = new List<string>();

    public List<Item> Equipment
    {
        get => _equipment;
        set
        {
            if (_equipment != value)
            {
                _equipment = value;
                OnPropertyChanged();
            }
        }
    }

    private List<Item> _equipment = new List<Item>();

    public Dictionary<string, int> Currency
    {
        get => _currency;
        set
        {
            if (_currency != value)
            {
                _currency = value;
                OnPropertyChanged();
            }
        }
    }

    private Dictionary<string, int> _currency = new Dictionary<string, int>
    {
        { "CP", 0 }, { "SP", 0 }, { "EP", 0 }, { "GP", 0 }, { "PP", 0 }
    };

    public List<Feature> Features
    {
        get => _features;
        set
        {
            if (_features != value)
            {
                _features = value;
                OnPropertyChanged();
            }
        }
    }

    private List<Feature> _features = new List<Feature>();

    public List<Spell> Spells
    {
        get => _spells;
        set
        {
            if (_spells != value)
            {
                _spells = value;
                OnPropertyChanged();
            }
        }
    }

    private List<Spell> _spells = new List<Spell>();

    public Character()
    {
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