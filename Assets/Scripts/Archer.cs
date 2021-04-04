using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MobsAI
{
    [Header("Arrow")]
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform spawnPoint;

    [Space(3)]
    [Header("Animation and speed")]
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 3f;


    public override void Attack()
    {
        Debug.Log("Attack");
       Instantiate(arrow.gameObject,spawnPoint.position,Quaternion.identity);
    }

    private void Update()
    {
        if (target == null || !GameMaster.instatiate.isGo) { if (!GameMaster.instatiate.isGo) { animator.enabled = false; } return; }
        animator.enabled = true;
        Vector3 dir = target.position - transform.position;

        //look 
        Quaternion look = Quaternion.LookRotation(dir);
        Vector3 rot = look.eulerAngles;
        transform.eulerAngles = new Vector3(0, rot.y, 0);

        if (Vector3.Distance(transform.position, target.position) <= rangeAttack)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }

}
