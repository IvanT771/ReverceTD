using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MobsAI
{
    [Header("Контроль анимацией")]
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float timeFre = 2f;


    
    private float time = 2f;
    private void Start()
    {
        time = timeFre;
        InvokeRepeating("SetTarget", 0, 0.5f);
    }
    private void Attack()
    {
        if(target == null) { return;}

        var buf = target.GetComponent<MobsAI>();
        if(buf == null) { return;}

        animator.SetBool("attack", true);

        if(time >= timeFre) { 
        time = 0;
        buf.Damage(forceDamage);
        }
        else
        {
            time+=Time.deltaTime;
        }

    }

    private void Update()
    {
        if(target == null || !GameMaster.instatiate.isGo) {  return;}

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
