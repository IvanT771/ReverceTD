using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private float range = 4f;
    [SerializeField] private int forceDamage = 20;

    private void SetTargetsDamage()
    {
        var enemu = GameObject.FindGameObjectsWithTag("Player");
        if(enemu.Length <= 0) { Destroy(gameObject); return;}


        foreach (var en in enemu)
        {
            if(Vector3.Distance(transform.position,en.transform.position) <= range)
            {
                var buf = en.GetComponent<MobsAI>();
                if (buf != null)
                {
                    buf.Damage(forceDamage);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            SetTargetsDamage();
        }
    }
}
