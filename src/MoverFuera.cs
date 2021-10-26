using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFuera : MonoBehaviour
{
    public float size = 0.05f; 
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        size = 0.05f;
        GetComponent<Renderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 direcciones = player.transform.position;
            float difX = direcciones.x - transform.position.x;
            float difZ = direcciones.z - transform.position.z;
            
            if (difX < 0.0)
            {
                direcciones.x = transform.position.x + (1.0f * size);
            }
            else
            {
                direcciones.x = transform.position.x - (1.0f * size);
            }

            if (difZ < 0.0)
            {
                direcciones.z = transform.position.z + (1.0f * size);
            }
            else
            {
                direcciones.z = transform.position.z - (1.0f * size);
            }
            
            transform.position = direcciones;
        }
    }
}
