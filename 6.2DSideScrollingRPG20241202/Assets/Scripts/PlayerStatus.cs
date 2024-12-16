using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public string Name = "";

    public ushort Level = 1;       // unsigned short int

    public float curHP = 100;
    public float MAX_HP = 100;
    public float HpRegen = 10;    // ü�� ȸ�� ���
    public float curMP = 100;
    public float MAX_MP = 100;
    public float MpRegen = 5;    // ���� ȸ�� ���
    public float curSTAMINA = 100;
    public float MAX_STAMINA = 100;
    public float StaminaRegen = 15;   // ���¹̳� ȸ�� ���

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

    public void Damaged(float damage)
    {
        curHP = (curHP > damage) ? curHP - damage : 0.0f;
    }
    public void ConsumeMana(float consume_mp)
    {
        curMP = (curMP > consume_mp) ? curMP - consume_mp : 0.0f;
    }

    public void ConsumeStamina(float consume_stamina)
    {
        curSTAMINA = (curSTAMINA > consume_stamina) ? curSTAMINA - consume_stamina : 0.0f;
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

    RectTransform LifeGauge;
    RectTransform ManaGauge;
    RectTransform StaminaGauge;

    // Start is called before the first frame update
    void Start() 
    {
        Stat = new Status();
        LifeGauge = 
            GameObject.Find("PlayerLifeGauge")
            .transform.Find("RealGauge").gameObject.GetComponent<RectTransform>();
        ManaGauge = 
            GameObject.Find("PlayerManaGauge")
            .transform.Find("RealGauge").gameObject.GetComponent<RectTransform>();
        StaminaGauge = 
            GameObject.Find("PlayerStaminaGauge")
            .transform.Find("RealGauge").gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stat.curHP < Stat.MAX_HP)
            Stat.curHP += (Stat.HpRegen * Time.deltaTime);
        if (Stat.curMP < Stat.MAX_MP)
            Stat.curMP += (Stat.MpRegen * Time.deltaTime);
        if (Stat.curSTAMINA < Stat.MAX_STAMINA)
            Stat.curSTAMINA += (Stat.StaminaRegen * Time.deltaTime);
        
        
        
        LifeGauge.localScale = new Vector3(Stat.curHP / Stat.MAX_HP, 1.0f, 1.0f);
        ManaGauge.localScale = new Vector3(Stat.curMP / Stat.MAX_MP, 1.0f, 1.0f);
        StaminaGauge.localScale = new Vector3(Stat.curSTAMINA / Stat.MAX_STAMINA, 1.0f, 1.0f);
    }

    public void ConsumStamina(float consumption)
    {
        Stat.ConsumeStamina(consumption);
    }

    public float GetStamina()
    {
        return Stat.curSTAMINA;
    }
}
