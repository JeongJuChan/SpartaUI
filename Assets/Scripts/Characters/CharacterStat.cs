using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    // UI���� �����ϱ� ���� �ν��Ͻ� (������ �����ϴٸ� ���ӸŴ������� �ν��Ͻ��� ������ ��)
    public static CharacterStat instance;

    public CharacterData characterData;

    private void Awake()
    {
        instance = this;
    }
}
