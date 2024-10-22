namespace DnD_Companion_blazor.Models;

[JsonSerializable(typeof(Skill))]
public class Skill
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("associated_stat")] public Stat AssociatedStat { get; set; }

    [JsonPropertyName("proficient")] public bool Proficient { get; set; }


    public Skill()
    {
        Name = string.Empty;
        AssociatedStat = new Stat();
        Proficient = false;
    }

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