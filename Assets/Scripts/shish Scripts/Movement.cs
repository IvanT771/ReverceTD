using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator grimlin;
    public Rigidbody rb;

    public GameObject plr;
    public float speed = 5f;

    public float sensitivity = 0.1f; 

    private bool isMovingFor = false;
    private bool isMovingBack = false;

    
    // Start is called before the first frame update
    void Start()
    {      
      
    }

   
    void Update()
    {
       

          if (Input.GetKey(KeyCode.W))
        {
           grimlin.SetBool("walk", true);
          transform.Translate(0,0,speed * Time.deltaTime);
        } else grimlin.SetBool("walk", false);

       if (Input.GetKey(KeyCode.S))
         {
           grimlin.SetBool("back", true);
          transform.Translate(0,0,-speed * Time.deltaTime);
        } else grimlin.SetBool("back", false);
        
         

         if (Input.GetKey(KeyCode.A))
         {
            grimlin.SetBool("left", true);
           transform.Translate(-speed * Time.deltaTime, 0,0);
         } else grimlin.SetBool("left", false);

         if (Input.GetKey(KeyCode.D))
         {
           grimlin.SetBool("right", true);
           transform.Translate(speed * Time.deltaTime, 0,0);
         } else grimlin.SetBool("right", false);
    }
     void FixedUpdate()
     {         
         float rotateHorizontal = Input.GetAxis ("Mouse X");
       //  float rotateVertical = Input.GetAxis ("Mouse Y");
         transform.RotateAround (plr.transform.position, Vector3.up, rotateHorizontal * sensitivity);
        // transform.RotateAround (plr.transform.position, Vector3.left, rotateVertical * sensitivity);
          //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
       //  transform.RotateAround (Vector3.zero, transform.right, rotateVertical * sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player
     }
    // if(isMovingFor)
    //   {
          
    //       rb.velocity = new Vector3(0,0,2);
    //   } else isMovingFor=false;

    //    if(isMovingBack)
    //   {
          
    //       rb.velocity = new Vector3(0,0,-2);
    //   } else isMovingBack=false;
    // }
}
