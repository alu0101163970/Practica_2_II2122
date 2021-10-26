using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_Propia : MonoBehaviour
{
    public float speed = 10.0f; // Velocidad de movimiento
    public float rotateSpeed = 20.0f;// Velocidad de rotación
    GameObject player; // Referencia a player.
    public bool WASD = true; // Switch para usar las flechas o el WASD.
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //Cambiar de color el cubo a rojo para distinguirlo
        player.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento sobre el plano XZ
        Transform tf = player.GetComponent<Transform>();
        if (WASD){
            if (Input.GetKey(KeyCode.W))
            {
                tf.Translate(Vector3.forward * speed * Time.deltaTime,  Space.Self);
                Debug.Log(tf.position);
            }
            if (Input.GetKey(KeyCode.A))
            {
                tf.Translate(Vector3.left * speed * Time.deltaTime,  Space.Self);
                Debug.Log(tf.position);
            }
            if (Input.GetKey(KeyCode.S))
            {
                tf.Translate(Vector3.back * speed * Time.deltaTime,  Space.Self);
                Debug.Log(tf.position);
            }
            if (Input.GetKey(KeyCode.D))
            {
                tf.Translate(Vector3.right * speed * Time.deltaTime,  Space.Self);
                Debug.Log(tf.position);
            }
        }
        else 
        {
            if (Input.GetKey("up"))
            {
                tf.Translate(Vector3.forward * speed * Time.deltaTime,  Space.Self);
                Debug.Log(tf.position);
            }
            if (Input.GetKey("left"))
            {
                tf.Translate(Vector3.left * speed * Time.deltaTime,  Space.Self);
                Debug.Log(tf.position);
            }
            if (Input.GetKey("down"))
            {
                tf.Translate(Vector3.back * speed * Time.deltaTime,  Space.Self);
                Debug.Log(tf.position);
            }
            if (Input.GetKey("right"))
            {
                tf.Translate(Vector3.right * speed * Time.deltaTime,  Space.Self);
                Debug.Log(tf.position);
            }
        }
        //Rotación
        float rotation = Input.GetAxis("Y") * rotateSpeed;
        rotation *= Time.deltaTime;
        tf.Rotate(0, rotation, 0);
    }
}
