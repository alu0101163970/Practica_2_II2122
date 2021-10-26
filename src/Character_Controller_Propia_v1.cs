using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_Propia : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotateSpeed = 20.0f;
    GameObject player;
    public bool WASD = true;
    int puntuacion = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Transform tf = player.GetComponent<Transform>();
        if (WASD){
            if (Input.GetKey(KeyCode.W))
            {
                tf.Translate(Vector3.forward * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey(KeyCode.A))
            {
                tf.Translate(Vector3.left * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey(KeyCode.S))
            {
                tf.Translate(Vector3.back * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey(KeyCode.D))
            {
                tf.Translate(Vector3.right * speed * Time.deltaTime,  Space.Self);
            }
        }
        else 
        {
            if (Input.GetKey("up"))
            {
                tf.Translate(Vector3.forward * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey("left"))
            {
                tf.Translate(Vector3.left * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey("down"))
            {
                tf.Translate(Vector3.back * speed * Time.deltaTime,  Space.Self);
            }
            if (Input.GetKey("right"))
            {
                tf.Translate(Vector3.right * speed * Time.deltaTime,  Space.Self);
            }
        }

        float rotation = Input.GetAxis("Y") * rotateSpeed;
        rotation *= Time.deltaTime;
        tf.Rotate(0, rotation, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + other.gameObject.name);
    }

     private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Cilindro Punto") || (other.tag =="Tipo A") || (other.tag =="Alejado")){
            puntuacion++;
            Debug.Log("Puntuación: " + puntuacion);
        }
        //Debug.Log("El " + gameObject.name + " dejó de colicionar con el gamobject " + other.gameObject.name);
    }

}
