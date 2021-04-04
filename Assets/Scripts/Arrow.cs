using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MobsAI
{
    [SerializeField] private float speed = 3f;


    public override void Attack()
    {
        if (target == null) { return; }

        var buf = target.GetComponent<MobsAI>();
        if (buf == null) { Destroy(gameObject); return; }



        buf.Damage(forceDamage);
        Destroy(gameObject);
    }

    public override void SetTarget()
    {
        var a = GameObject.FindGameObjectsWithTag("Archer");

        if(a != null)
        {
            float dist = Mathf.Infinity;
            foreach (var en in a)
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
        

        if(target == null)
        base.SetTarget(); 

    }

    private void Update()
    {
        if (target == null) { return; }
        
        Vector3 dir = target.position - transform.position;

        //look 
        Quaternion look = Quaternion.LookRotation(dir);
        Vector3 rot = look.eulerAngles;
        transform.eulerAngles = new Vector3(0, rot.y, 0);

        if (Vector3.Distance(transform.position, target.position) <= rangeAttack)
        {
           Attack();
        }
        else
        {
            
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
