using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    Status Stat;
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

    private void OnCollisionEnter(Collision collision)
    {
        // ���Ͱ� ���ظ� ���� �� HP ������ ����
        LifeGauge.localScale = new Vector3(Stat.curHP / Stat.MAX_HP, 1.0f, 1.0f);
    }

    private void OnDead()
    {
        Destroy(this.gameObject);
    }


    public float MonsterCollideAttack()
    {
        return Stat.PhysicalAttack;
    }
}
