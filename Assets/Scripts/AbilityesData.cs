using UnityEngine;

public enum Rarity { Common, Uncommon, Rare}
public enum PowerKind { Life, FireRate,Speed,Damage}

[CreateAssetMenu(fileName = "AbilityesData", menuName = "Scriptable Objects/AbilityesData")]
public class AbilityesData : ScriptableObject
{
    public string abilityName;
    public Sprite icon;
    public Rarity rarity;
    public PowerKind powerKind;
    public float stat;
}
