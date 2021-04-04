using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsAI : MonoBehaviour
{
    [SerializeField]protected int myHp = 100;
    [SerializeField]protected float rangeAttack = 3f;
    [SerializeField]protected int forceDamage = 1;
    [SerializeField]protected string enemyTag = "Enemy";
    [SerializeField]protected int price = 100; 


    protected Transform target = null;

    private void Start()
    {

        InvokeRepeating("SetTarget", 0, 0.5f);
    }
    public virtual void Attack()
    {
        //Base
    }

    public int GetPrice()
    {
        return price;
    }

    private void SetTarget()
    {
        if (!GameMaster.instatiate.isGo) { return; }
        
        var enemy = GameObject.FindGameObjectsWithTag(enemyTag);
        
        if(enemy.Length <= 0) 
        { 
            if(enemyTag == "Enemy")
            {
            Debug.Log("---GAME WIN---");
            }
            else
            {
            Debug.Log("---GAME OWER---");
            }
            GameMaster.instatiate.isGo = false;
            return;
        }

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
