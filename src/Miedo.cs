using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Miedo : MonoBehaviour
{
    public float distance = 3.0f; 
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        GetComponent<Renderer>().material.color = Color.green;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direcciones = player.transform.position;
        float difX = direcciones.x - transform.position.x;
        float difZ = direcciones.z - transform.position.z;
        
        float distanceEuclidea = Convert.ToSingle(Math.Sqrt(Math.Pow(difX, 2) + Math.Pow(difZ, 2)));
        if(distanceEuclidea <= distance){
            if (difX < 0.0)
        {
            direcciones.x = transform.position.x + distanceEuclidea;
        }
        else
        {
            direcciones.x = transform.position.x - distanceEuclidea;
        }
        
        

        if (difZ < 0.0)
        {
            direcciones.z = transform.position.z + distanceEuclidea;
        }
        else
        {
            direcciones.z = transform.position.z - distanceEuclidea;
        }
        
        transform.position = direcciones;
        }
    }
}
