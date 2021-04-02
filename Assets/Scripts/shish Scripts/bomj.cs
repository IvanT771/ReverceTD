using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomj : MonoBehaviour
{
    GameObject[] enemy;
    GameObject closest;

    public GameObject tower;
    public Transform targetBox;

    public string nearest;
    public float speed = 2f;

    public float next = 3f;
    public bool isEn = false;

    public Animator big;

    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }
        GameObject FindClosestEnemy()
        {
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in enemy)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
         return closest;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag=="Enemy"){ isEn = true; big.SetBool("attack", true);} else {isEn = false; big.SetBool("attack", false);}
        }
       
    // Update is called once per frame

    void Update()
    {
        
            nearest = FindClosestEnemy().name;
            tower = GameObject.Find(nearest);

            if (isEn == false)
            {
            targetBox = tower.transform;     
            transform.position += (targetBox.position - transform.position).normalized * speed * Time.deltaTime;
            }
            if ((targetBox.position - transform.position).sqrMagnitude < 0.01f)
            {
                
            }
           
        
        
}
}
