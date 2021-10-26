using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class crecedecrece : MonoBehaviour
{
    GameObject player;
    GameObject[] esferas;
    public float distance = 0.5f;
    public float aumento = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        esferas = GameObject.FindGameObjectsWithTag("Esfera");
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
        if(distanceEuclidea <= distance)
            {
                Vector3 tmp = transform.localScale;
                if((tmp.y - aumento) >= 0.0)
                {
                    tmp.y = tmp.y - aumento;
                }
                else
                {
                    tmp.y = 0.0f;
                }
                transform.localScale = tmp;
            }
        if(transform.localScale.y >= 0.0)
        {
            Vector3[] direccionesEsferas = new Vector3[esferas.Length];
            for (int i = 0; i < esferas.Length; i++)
            {
                direccionesEsferas[i] = esferas[i].transform.position;
                difX = direccionesEsferas[i].x - transform.position.x;
                difZ = direccionesEsferas[i].z - transform.position.z;
                distanceEuclidea = Convert.ToSingle(Math.Sqrt(Math.Pow(difX, 2) + Math.Pow(difZ, 2)));
                if(distanceEuclidea <= distance)
                {

                    Vector3 tmp = transform.localScale;
                    tmp.y = tmp.y + aumento;
                    transform.localScale = tmp;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + other.gameObject.name);
    }

     private void OnTriggerExit(Collider other)
    {
        //Debug.Log("El " + gameObject.name + " dejó de colicionar con el gamobject " + other.gameObject.name);
    }
    
}
