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

    CharacterType playerType = CharacterType.Novice;  // �� ĳ����
    ushort Level = 1;       // unsigned short int
    int Exp = 0;            // Experience
    int curHP = 100;
    int MAX_HP = 100;
    int curMP = 100;
    int MAX_MP = 100;
    int curSTAMINA = 100;
    int MAX_STAMINA = 100;
    public int StaminaRegen = 10;   // ���¹̳� ȸ�� ���
    int PhysicalAttack = 5;     // ���� ���ݷ�
    int MagicalAttack = 5;      // ���� ���ݷ�
    int PhysicalDefense = 3;    // ���� ����
    int MagicalDefense = 3;     // ���� ����
    int Agility = 5;            // ��ø��
    int Speed = 5;              // ���� �ӵ�

    int Gold = 0;   // ������

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
