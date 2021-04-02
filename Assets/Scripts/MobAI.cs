using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour
{
    [Header("Кого атакует?(кто цель?)")]
    [SerializeField] private string enemyTag = "Enemy";

    [Header("Характеристики")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rangeAttack = 3f;
    [SerializeField] private int damageForce = 1;
    [SerializeField] private short myHp = 100;

    private Transform target = null;

    private void SetTarget()
    {
        var enemy = GameObject.FindGameObjectsWithTag(enemyTag);

        float dist = Mathf.Infinity;
        foreach (var en in enemy)
        {
            float buf = Vector3.Distance(transform.position, en.transform.position);
            if ( dist > buf)
            {
                if(en != null) { 
                dist = buf;
                target = en.transform; }
            }
        }
    }

    private void Attack()
    {

    }

    private void Start()
    {
         InvokeRepeating("SetTarget",0,0.5f);
    }

    private void Update()
    {
        if(target == null) { return;}

        Vector3 dir = target.position - transform.position;

        if(Vector3.Distance(transform.position,target.position) <= rangeAttack)
        {
            Attack();
        }
        else
        {
            transform.Translate(dir.normalized * speed*Time.deltaTime);
        }
    }

}
