using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCilinder : MonoBehaviour
{
    public float aumento = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + other.gameObject.name);
    }

     private void OnTriggerExit(Collider other)
    {
        //Debug.Log("El " + gameObject.name + " dejó de colicionar con el gamobject " + other.gameObject.name);
       if(other.tag == "Player")
       { 
            Vector3 tmp = transform.localScale;
            tmp.y = tmp.y + aumento;
            transform.localScale = tmp;
        }
    }
}
