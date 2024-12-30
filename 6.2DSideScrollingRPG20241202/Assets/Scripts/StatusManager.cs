using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Status
{
    public string Name = "";

    public ushort Level = 1;       // unsigned short int

    public float curHP = 100.0f;
    public float MAX_HP = 100.0f;
    public float HpRegenRate = 1.0f;    // ü�� ȸ�� ���

    public float curMP = 100.0f;
    public float MAX_MP = 100.0f;
    public float MpRegenRate = 2.0f;    // ���� ȸ�� ���

    public float curSTAMINA = 100.0f;
    public float MAX_STAMINA = 100.0f;
    public float StaminaRegenRate = 5.0f;   // ���¹̳� ȸ�� ���

    public float PhysicalAttack = 5;     // ���� ���ݷ�
    public float MagicalAttack = 5;      // ���� ���ݷ�

    public float PhysicalDefense = 3;    // ���� ����
    public float MagicalDefense = 3;     // ���� ����

    public float Agility = 5;            // ��ø��
    public float Speed = 5;              // ���� �ӵ�

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

    public void Regenerate()
    {
        // �� �����Ӹ��� (Update) ȣ�� �� HP, MP, ���¹̳� ȸ���ϴ� �Լ�
        if (curHP < MAX_HP)
            curHP += (HpRegenRate * Time.deltaTime);
        if (curMP < MAX_MP)
            curMP += (MpRegenRate * Time.deltaTime);
        if (curSTAMINA < MAX_STAMINA)
            curSTAMINA += (StaminaRegenRate * Time.deltaTime);
    }

    public void Damaged(float damage)
    {
        curHP = (curHP > damage) ? curHP - damage : 0.0f;
    }

    public void HealingLife(float HealingRate)
    {
        curHP = (curHP + HealingRate < MAX_HP) ? curHP + HealingRate : MAX_HP;
    }

    public void ConsumeMana(float consume_mp)
    {
        curMP = (curMP > consume_mp) ? curMP - consume_mp : 0.0f;
    }

    public void HealingMana(float HealingRate)
    {
        curMP = (curMP + HealingRate < MAX_MP) ? curMP + HealingRate : MAX_MP;
    }

    public void ConsumeStamina(float consume_stamina)
    {
        curSTAMINA = (curSTAMINA > consume_stamina) ? curSTAMINA - consume_stamina : 0.0f;
    }

    public void HealingStamina(float HealingRate)
    {
        curSTAMINA = (curSTAMINA + HealingRate < MAX_STAMINA) ? curSTAMINA + HealingRate : MAX_STAMINA;
    }
}

public class StatusManager : MonoBehaviour
{
}
