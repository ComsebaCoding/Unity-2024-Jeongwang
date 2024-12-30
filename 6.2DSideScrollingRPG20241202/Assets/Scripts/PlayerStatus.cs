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
        Archer,
        MAXCOUNT
    }

    enum AttackAnimationType
    {
        SwingAttack = 0,
        StingAttack,
        ShotAttack,
        AttackTypeCount
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
        Stat.Regenerate();
        // Gauge Manager
        LifeGauge.localScale = new Vector3(Stat.curHP / Stat.MAX_HP, 1.0f, 1.0f);
        ManaGauge.localScale = new Vector3(Stat.curMP / Stat.MAX_MP, 1.0f, 1.0f);
        StaminaGauge.localScale = new Vector3(Stat.curSTAMINA / Stat.MAX_STAMINA, 1.0f, 1.0f);
    }

    public void Damaged(float damage)
    {
        Stat.Damaged(damage);
    }

    public float GetPhysicalAttack()
    {
        return Stat.PhysicalAttack;
    }

    public float GetMagicalAttack()
    {
        return Stat.MagicalAttack;
    }

    public float GetPhysicalDefense()
    {
        return Stat.PhysicalDefense;
    }

    public float GetMagicalDefense()
    {
        return Stat.MagicalDefense;
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
