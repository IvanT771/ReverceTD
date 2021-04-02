using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MobsAI
{
    [Header("Контроль анимацией")]
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 3f;
    
    

    private void Attack()
    {
        if(target == null) { return;}

        var buf = target.GetComponent<MobsAI>();
        if(buf == null) { return;}

        buf.Damage(forceDamage);
    }

    private void Update()
    {
        if(target == null || !GameMaster.instatiate.isGo) { return;}

        Vector3 dir = target.position - transform.position;

        if(Vector3.Distance(transform.position,target.position) <= rangeAttack)
        {
            Attack();
        }
        else
        {
            animator.SetBool("attack",false);
            transform.Translate(dir.normalized * speed*Time.deltaTime);
        }
    }

}
