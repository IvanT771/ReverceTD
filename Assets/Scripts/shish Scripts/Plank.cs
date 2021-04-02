using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
     public float thrust = 0.001f;
    public Rigidbody rb;
    public int hit = 100;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
         {
             hit-=30;
         }

         if (hit<=0)
         {           
             
              if (gameObject.tag=="Planks")
              {
                  Destroy(gameObject);
                   rb.AddForce(0, 0, thrust, ForceMode.Impulse);
              }
         }
 
    }
}
