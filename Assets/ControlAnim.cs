using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlAnim : MonoBehaviour
{
    public bool isRocker = false;

    private MobsAI mobs = null;
    private Rocker rocker = null;
    private void Start()
    {
        if (!isRocker) { 
        mobs = transform.parent.GetComponent<MobsAI>();
        }
        else
        {
            rocker = transform.parent.GetComponent<Rocker>();
        }

        

    }
    public void SetAttack()
    {
        if(mobs == null) { Debug.LogError("no scripts MobsAI"); return;}

        mobs.Attack();
    }

    public void UpSt()//Upper Stone
    {
        if(rocker == null) { return;}

        rocker.UpStone();
    }

    public void DownStone()
    {
        if (rocker == null) { return; }
        rocker.Attack();
    }

}
