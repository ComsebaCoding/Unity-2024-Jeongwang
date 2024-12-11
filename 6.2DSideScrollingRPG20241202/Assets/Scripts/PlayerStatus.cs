using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public string Name = "";

    public ushort Level = 1;       // unsigned short int

    public int curHP = 100;
    public int MAX_HP = 100;
    public int HpRegen = 10;    // 체력 회복 계수
    public int curMP = 100;
    public int MAX_MP = 100;
    public int MPRegen = 10;    // 마나 회복 계수
    public int curSTAMINA = 100;
    public int MAX_STAMINA = 100;
    public int StaminaRegen = 10;   // 스태미나 회복 계수

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

    CharacterType playerType = CharacterType.Novice;  // 내 캐릭터
    Status Stat;
    int Exp = 0;            // Experience
    int MaxExp = 100;
    int Gold = 0;   // 소지금
    int Jewel = 0;  // 보석

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
