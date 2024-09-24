namespace DnD_Companion.Models;

public class Skill
{
    public string Name { get; set; }
    public Stat AssociatedStat { get; set; }
    public bool Proficient { get; set; }

    public Skill(string name, Stat associatedStat)
    {
        Name = name;
        AssociatedStat = associatedStat;
    }

    public int GetModifier(int proficiencyBonus)
    {
        return AssociatedStat.Modifier + (Proficient ? proficiencyBonus : 0);
    }
}