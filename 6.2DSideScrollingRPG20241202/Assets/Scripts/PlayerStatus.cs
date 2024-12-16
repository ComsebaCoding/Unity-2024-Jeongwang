using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public string Name = "";

    public ushort Level = 1;       // unsigned short int

    public float curHP = 100;
    public float MAX_HP = 100;
    public float HpRegen = 10;    // 체력 회복 계수
    public float curMP = 100;
    public float MAX_MP = 100;
    public float MpRegen = 5;    // 마나 회복 계수
    public float curSTAMINA = 100;
    public float MAX_STAMINA = 100;
    public float StaminaRegen = 15;   // 스태미나 회복 계수

    public int PhysicalAttack = 5;     // 물리 공격력
    public int MagicalAttack = 5;      // 마법 공격력
    public int PhysicalDefense = 3;    // 물리 방어력
    public int MagicalDefense = 3;     // 마법 방어력
    public int Agility = 5;            // 민첩성
    public int Speed = 5;              // 스탯 속도

    public Status()
    {
        // 생성자, 이 클래스가 생성될 때 호출

        // 클래스의 멤버 변수들에 값을 초기화 하는 용도로 사용
    }

    ~Status()
    {
        // 소멸자, 이 클래스가 소멸할 때 호출
        // 구조체는 소멸자가 존재하지 않는다

        // GC.Collect()를 사용해 프로그램 실행 도중에 소멸 시 발생

        // 1 클래스에는 1 소멸자만을 만들 수 있음
        // 접근 제어 지시자(public, private...)와 매개 변수 설정이 불가능
        // 소멸자는 오버로딩이나 상속이 불가능
        // 어플리케이션 종료 시 소멸자가 호출되지는 않음
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

    CharacterType playerType = CharacterType.Novice;  // 내 캐릭터
    Status Stat;
    int Exp = 0;            // Experience
    int MaxExp = 100;
    int Gold = 0;   // 소지금
    int Jewel = 0;  // 보석

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
