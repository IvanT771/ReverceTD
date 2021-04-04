using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    [SerializeField] private int forceDamage = 20;

    private bool isContact = false;

    private GameObject[] enemu; 
    private void Start()
    {
        enemu = GameObject.FindGameObjectsWithTag("Player");
    }

    private void SetTargetsDamage()
    {

        foreach (var en in enemu)
        {

            if (Vector3.Distance(transform.position,en.transform.position) <= range)
            {
                var buf = en.GetComponent<MobsAI>();
                if (buf != null)
                {
                    buf.Damage(forceDamage);
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isContact) { return;}
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player")) {
            
            isContact = true;
            SetTargetsDamage();
            Destroy(gameObject);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
