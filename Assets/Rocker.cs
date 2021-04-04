using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocker : MobsAI
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject stone;

    [SerializeField] private Animator animator;

    private GameObject stoneObj = null;
    private Rigidbody stoneRb = null;
    public override void Attack()
    {
        if(stoneObj==null || stoneRb==null) { return;}

        stoneObj.transform.parent = null;
        stoneRb.isKinematic = false;

        stoneObj = null;
        stoneRb = null;
    }

    public void UpStone()
    {
        if(stoneObj != null || !GameMaster.instatiate.isGo) { return;}

        stoneObj = Instantiate(stone,spawnPoint.position,spawnPoint.rotation);
        stoneObj.transform.parent = spawnPoint.transform;
        stoneRb = stoneObj.GetComponent<Rigidbody>();

        if(stoneRb == null) { return;}
        stoneRb.isKinematic = true;
    }
    private void Update()
    {
        if(target == null || !GameMaster.instatiate.isGo) { animator.SetBool("attack", false); return;}

            

        if( Vector3.Distance(transform.position,target.position) <= rangeAttack)
        {
            animator.SetBool("attack",true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
        
    }

}
