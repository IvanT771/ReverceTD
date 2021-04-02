using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlAnim : MonoBehaviour
{
    private MobsAI mobs = null;
    private void Start()
    {
        mobs = transform.parent.GetComponent<MobsAI>();

    }
    public void SetAttack()
    {
        if(mobs == null) { Debug.LogError("no scripts MobsAI"); return;}

        mobs.Attack();
    }
}
