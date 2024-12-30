using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Status
{
    public string Name = "";

    public ushort Level = 1;       // unsigned short int

    public float curHP = 100.0f;
    public float MAX_HP = 100.0f;
    public float HpRegenRate = 1.0f;    // 체력 회복 계수

    public float curMP = 100.0f;
    public float MAX_MP = 100.0f;
    public float MpRegenRate = 2.0f;    // 마나 회복 계수

    public float curSTAMINA = 100.0f;
    public float MAX_STAMINA = 100.0f;
    public float StaminaRegenRate = 5.0f;   // 스태미나 회복 계수

    public float PhysicalAttack = 5;     // 물리 공격력
    public float MagicalAttack = 5;      // 마법 공격력

    public float PhysicalDefense = 3;    // 물리 방어력
    public float MagicalDefense = 3;     // 마법 방어력

    public float Agility = 5;            // 민첩성
    public float Speed = 5;              // 스탯 속도

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

    public void Regenerate()
    {
        // 매 프레임마다 (Update) 호출 시 HP, MP, 스태미나 회복하는 함수
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
