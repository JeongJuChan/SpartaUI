using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDefault", menuName = "CreateCharacterData", order = 0)]
public class CharacterData : ScriptableObject
{
    [Header("Character Info")]
    public int level;
    public int exp;
    public string description;
    public int gold;

    [Header("Character Default Stat")]
    public float attack;
    public float defense;
    public float health;
    public float critical;
}
