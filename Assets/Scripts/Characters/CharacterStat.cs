using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    // UI에서 접근하기 위한 인스턴스 (원래는 유일하다면 게임매니저에서 인스턴스로 관리할 듯)
    public static CharacterStat instance;

    public CharacterData characterData;

    private void Awake()
    {
        instance = this;
    }
}
