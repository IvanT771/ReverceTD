using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsAI : MonoBehaviour
{
    [SerializeField]protected int myHp = 100;
    [SerializeField]protected float rangeAttack = 3f;
    [SerializeField]protected int forceDamage = 1;
    [SerializeField]protected string enemyTag = "Enemy";


    protected Transform target = null;

    private void SetTarget()
    {
        
        var enemy = GameObject.FindGameObjectsWithTag(enemyTag);

        float dist = Mathf.Infinity;
        foreach (var en in enemy)
        {
            float buf = Vector3.Distance(transform.position, en.transform.position);
            if (dist > buf)
            {
                if (en != null)
                {
                    dist = buf;
                    target = en.transform;
                }
            }
        }
    }

    public void Damage(int forceDamage)
    {
        myHp -= forceDamage;
        if (myHp <= 0)
        {
            Destroy(gameObject);
        }
    }



    


}
