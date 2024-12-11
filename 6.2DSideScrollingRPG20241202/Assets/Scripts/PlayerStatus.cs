using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public string Name = "";

    public ushort Level = 1;       // unsigned short int

    public int curHP = 100;
    public int MAX_HP = 100;
    public int HpRegen = 10;    // ü�� ȸ�� ���
    public int curMP = 100;
    public int MAX_MP = 100;
    public int MPRegen = 10;    // ���� ȸ�� ���
    public int curSTAMINA = 100;
    public int MAX_STAMINA = 100;
    public int StaminaRegen = 10;   // ���¹̳� ȸ�� ���

    public int PhysicalAttack = 5;     // ���� ���ݷ�
    public int MagicalAttack = 5;      // ���� ���ݷ�
    public int PhysicalDefense = 3;    // ���� ����
    public int MagicalDefense = 3;     // ���� ����
    public int Agility = 5;            // ��ø��
    public int Speed = 5;              // ���� �ӵ�

    public Status()
    {
        // ������, �� Ŭ������ ������ �� ȣ��

        // Ŭ������ ��� �����鿡 ���� �ʱ�ȭ �ϴ� �뵵�� ���
    }

    ~Status()
    {
        // �Ҹ���, �� Ŭ������ �Ҹ��� �� ȣ��
        // ����ü�� �Ҹ��ڰ� �������� �ʴ´�

        // GC.Collect()�� ����� ���α׷� ���� ���߿� �Ҹ� �� �߻�

        // 1 Ŭ�������� 1 �Ҹ��ڸ��� ���� �� ����
        // ���� ���� ������(public, private...)�� �Ű� ���� ������ �Ұ���
        // �Ҹ��ڴ� �����ε��̳� ����� �Ұ���
        // ���ø����̼� ���� �� �Ҹ��ڰ� ȣ������� ����
    }

    public void Damaged(int damage)
    {
        curHP = (curHP > damage) ? curHP - damage : 0;
    }
    public void ConsumeMana(int consume_mp)
    {
        curMP = (curMP > consume_mp) ? curMP - consume_mp : 0;
    }

    public void ConsumeStamina(int consume_stamina)
    {
        curSTAMINA = (curSTAMINA > consume_stamina) ? curSTAMINA - consume_stamina : 0;
    }
}

public class PlayerStatus : MonoBehaviour
{
    enum CharacterType
    {
        Novice,
        Warrior,
        Magician,
        Archer,
        MAXCOUNT
    }

    CharacterType playerType = CharacterType.Novice;  // �� ĳ����
    Status Stat;
    int Exp = 0;            // Experience
    int MaxExp = 100;
    int Gold = 0;   // ������
    int Jewel = 0;  // ����

    // Start is called before the first frame update
    void Start() 
    {
        Stat = new Status();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stat.curSTAMINA < Stat.MAX_STAMINA)
            Stat.curSTAMINA += (int)(Stat.StaminaRegen * Time.deltaTime);
        if (playerType == CharacterType.Warrior)
        {
            if (Stat.curHP < Stat.MAX_HP)
                Stat.curHP += (int)(Stat.HpRegen * Time.deltaTime);
        }
    }

    public void ConsumStamina(int consumption)
    {
        Stat.ConsumeStamina(consumption);
    }

    public int GetStamina()
    {
        return Stat.curSTAMINA;
    }
}
