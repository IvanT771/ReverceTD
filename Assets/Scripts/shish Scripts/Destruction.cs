using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public bool des=false;
    public float remaining=10;

    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<Rigidbody>().isKinematic = false;
        des = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().isKinematic == false)
        {
        if (des)
        {
            remaining -= Time.deltaTime;
            if (remaining<0)
            {
                Destroy(gameObject);
            }
        }
        }
    }
}
