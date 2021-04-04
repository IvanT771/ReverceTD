using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MobsAI
{
    [Header("Контроль анимацией")]
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 3f;



    
 
   
    public override void Attack()
    {
        
        if (target == null) { return; }

        var buf = target.GetComponent<MobsAI>();
        if (buf == null) { return; }

        

        buf.Damage(forceDamage);
        
    }

    private void Update()
    {
        if(target == null || !GameMaster.instatiate.isGo) { if(!GameMaster.instatiate.isGo){ animator.enabled = false;} return;}
        animator.enabled = true;
        Vector3 dir = target.position - transform.position;

        //look 
        Quaternion look = Quaternion.LookRotation(dir);
        Vector3 rot = look.eulerAngles;
        transform.eulerAngles = new Vector3(0, rot.y, 0);

        if (Vector3.Distance(transform.position,target.position) <= rangeAttack)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack",false);

            Vector3 d = transform.position;

            transform.Translate(dir.normalized * speed*Time.deltaTime,Space.World);
            d = new Vector3(transform.position.x,d.y,transform.position.z);
            transform.position = d;
        }
    }

}
