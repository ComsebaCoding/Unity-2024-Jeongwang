using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public Status Stat;
    RectTransform LifeGauge;

    // Start is called before the first frame update
    void Start()
    {
        Stat = new Status();
        Stat.HpRegenRate = 0.0f;
        Stat.MpRegenRate = 0.0f;
        Stat.StaminaRegenRate = 0.0f;
        LifeGauge =
            GameObject.Find("MonsterHPGauge")
            .transform.Find("RealGauge").gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stat.curHP <= 0)
        {
            OnDead();
        }
    }

    private void OnDead()
    {
        Destroy(this.gameObject);
    }


    public float GetPhysicalAttack()
    {
        return Stat.PhysicalAttack;
    }

    public float MonsterCollideAttack()
    {
        return GetPhysicalAttack();
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

    public void Damaged(float damage)
    {
        Stat.Damaged(damage);
        // 몬스터가 피해를 입을 시 HP 게이지 갱신
        LifeGauge.localScale = new Vector3(Stat.curHP / Stat.MAX_HP, 1.0f, 1.0f);
    }
}
