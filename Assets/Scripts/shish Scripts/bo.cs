using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bo : MonoBehaviour
{
    Collider m_ObjectCollider;
     public float thrust = 0.001f;
    public Rigidbody rb;
    public int hit = 10;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
       
    // Physics.IgnoreLayerCollision(3,6,true);
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
             GetComponent<Rigidbody>().isKinematic = false;
             GetComponent<Rigidbody>().useGravity = true;
             transform.gameObject.tag="Breaked Tower";
              rb.AddForce(0, 0, thrust, ForceMode.Impulse);             
         }

    }

   public void OnTriggerEnter(Collider other) 
   {
        
         
        //     if (other.tag == "Player")
        // {
        //      GetComponent<Rigidbody>().isKinematic = false;
        //      GetComponent<Rigidbody>().useGravity = true;
        //      transform.gameObject.tag="Breaked Glass";
        //       E();
        //    //  transform.gameObject.layer=6;
            
            
        // }
       
            if (other.tag == "Breaked Tower" && gameObject.tag=="Tower")
        {
             GetComponent<Rigidbody>().isKinematic = false;
             GetComponent<Rigidbody>().useGravity = true;
             transform.gameObject.tag="Breaked Tower";
                  
        } 
     
          
    }
  
   
}

// var bush = other.GetComponent<script>()
// other.GetComponent<script>()
// if bush!=null

// in tower 
