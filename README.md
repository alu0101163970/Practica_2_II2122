# **Práctica 2 de Interfaces Inteligentes**
## **Autor**: Francisco Jesus Mendes Gomez

## **Índice:**  

1. [**Apartado 1**](#id1)
2. [**Apartado 2**](#id2)  
3. [**Apartado 3**](#id3) 

<div name="id1" />

## Apartado 1
a. Ninguno de los objetos será físico.
![](./img/1a.png)  

Los dos objetos se quedan estáticos al ejecutar.  

b. La esfera tiene físicas y el cubo no.
![](./img/1b.gif)  

El cubo se queda estático y la esfera tiene gravedad y colisiona con el plano.  

c. La esfera y el cubo tienen físicas.
![](./img/1c.gif)  

A ambos les afecta la gravedad y colisionan con el plano.  

d. La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo.
![](./img/1d.gif)  

A pesar de que la esfera tiene más masa no se observa en el resultado ya que la masa no afecta a la velocidad con la que cae un objeto por acción de la gravedad.  

e. La esfera tiene físicas y el cubo es de tipo IsTrigger.
![](./img/1e.gif)  

Como observamos solo la esfera es afectada por la gravedad pero el cubo no, además de que el cubo es intangible ya que la esfera colisiona pero pasa através de él.  

f. La esfera tiene físicas, el cubo es de tipo IsTrigger y tiene físicas.
![](./img/1f.gif)  

En este caso ambos son afectados por la gravedad pero el cubo no es tangible por lo que no colisiona con el plano y pasa a través de él.

g. La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo, se impide la rotación del cubo sobre el plano XZ.
![](./img/1g.gif)  

Como observamos el movimiento que observamos en el cubo no son los que habitualmente tendría ya que no tiene rotación en el plano XZ quedando ligeramente levantado sobre el plano después de haber colisionado. 


<div name="id2" />

## Apartado 2

Resultado:  
![](./img/2.gif) 

Observamos como podemos mover y rotar el cubo rojo ya sea con las flechas o con el WASD y rotar sobre su eje OY con las teclas 'z'(antihorario) y 'x'(horario). Así como cambiar los parámetros para cambiar entre flechas y wasd, la velocidad de movimiento y la velocidad de rotación.

Todo esto gracias al siguiente script añadido la objeto cubo.Véase en el script `Character_Controller_Propia_v1.cs`. 
```c#
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

```
<div name="id3" />

## Apartado 3

Resultado
![](./img/3.gif)  


+ Se ha añadido nuevo código en el script del apartado anterior para el tema de las puntuaciones. Véase en el script `Character_Controller_Propia_v2.cs`.

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller_Propia : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotateSpeed = 20.0f;
    GameObject player;
    public bool WASD = true;
    int puntuacion = 0;// Se ha añadido esto
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

    // Se ha añadido esto
    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + other.gameObject.name);
    }

    // Se ha añadido esto
    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Cilindro Punto") || (other.tag =="Tipo A") || (other.tag =="Alejado")){
            puntuacion++;
            Debug.Log("Puntuación: " + puntuacion);
        }
        //Debug.Log("El " + gameObject.name + " dejó de colicionar con el gamobject " + other.gameObject.name);
    }

}
```

+ Cada Cilindro posee el script `ScaleCilinder.cs` para que aumente su tamaño cuando colisiona con el jugador
```c#
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
```  
+ Se han etiquetado los cilindros azules de la imagen como tipo A y tienen la particularidad de que al precionar la tecla espacio se alejan del jugador con una distancia dada por parámetro. Véase en el script `MoverFuera.cs`.

```c#
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
```
+ Los cilindros verdes se alejan del jugador cuando este se acerca a una distancia dada por parámetro. Véase en el script `Miedo.cs`.

```c#
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
```
+ Se ha creado un tercer objeto en la escena el cual pude moverse con las teclas I,J,K y L, el cual muestra un mensaje por consola cada vez que colisiona con un objeto y con cual objeto ha colisionado. Véase en el script `movimiento.cs`.

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {   
        GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime,  Space.Self);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime,  Space.Self);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime,  Space.Self);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime,  Space.Self);
        }
    
    }
     private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + other.gameObject.name);
    }

     private void OnTriggerExit(Collider other)
    {
        Debug.Log("El " + gameObject.name + " dejó de colicionar con el gamobject " + other.gameObject.name);
    }
}
```
+ Por último se han añadido a la escena cubos los cuales aumentan su tamaño si un objeto con la etiqueta esfera se les acerca y disminuyen su tamaño cuando se le acerca el jugador. La distancia de acercamiento y el aumento de tamaño viene dado por parámetro. Véase en el script `crecedecrece.cs`.

```c#
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
```

