using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDefault", menuName = "CreateCharacterData", order = 0)]
public class CharacterData : ScriptableObject
{
    [Header("Character Info")]
    public string displayName;
    public string level;
    public string exp;
    public string description;

    [Header("Character Default Stat")]
    public float attack;
    public float defense;
    public float health;
    public float critical;
}
