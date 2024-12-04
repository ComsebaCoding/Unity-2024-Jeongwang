using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    enum CharacterType
    {
        Novice,
        Warrior,
        Magician,
        Archer
    }

    CharacterType playerType = CharacterType.Novice;  // 내 캐릭터
    ushort Level = 1;       // unsigned short int
    int Exp = 0;            // Experience
    int curHP = 100;
    int MAX_HP = 100;
    int curMP = 100;
    int MAX_MP = 100;
    int curSTAMINA = 100;
    int MAX_STAMINA = 100;
    public int StaminaRegen = 10;   // 스태미나 회복 계수
    int PhysicalAttack = 5;     // 물리 공격력
    int MagicalAttack = 5;      // 마법 공격력
    int PhysicalDefense = 3;    // 물리 방어력
    int MagicalDefense = 3;     // 마법 방어력
    int Agility = 5;            // 민첩성
    int Speed = 5;              // 스탯 속도

    int Gold = 0;   // 소지금

    // Start is called before the first frame update
    void Start() 
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (curSTAMINA < MAX_STAMINA)
            curSTAMINA += (int)(StaminaRegen * Time.deltaTime);
        if (playerType == CharacterType.Warrior)
        {
            int HpRegen = 100;
            if (curHP < MAX_HP)
                curHP += (int)(HpRegen * Time.deltaTime);
        }
    }

    public void ConsumStamina(int consumption)
    {
        curSTAMINA -= consumption;
    }

    public int GetStamina()
    {
        return curSTAMINA;
    }
}
