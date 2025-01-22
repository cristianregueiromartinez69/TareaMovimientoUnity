using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    //objeto rigidBody para mover la esfera
    private Rigidbody rb;


    //variable de velocidad para el movimiento de la esfera
    public float speed = 10.0f;

    //variable de velocidad para el movimiento del eje x
    private float movementX;

    //variable de velocidad para el movimiento del eje y

    private float movementY;

    //variable para actualizar en la UI los items que ha cogido el jugador
    public int countObjectsInt;

    //variable para actualizar las vidas del jugador en la UI
    private int countLifeInt = 3;


    private float limitY = -200f;

    //variable para actualizar el nivel del jugador en la UI
    private int countLevelInt = 1;

    //variables para acceder a los textos de la UI
    public Text countObjectsText;
    public Text countLifeText;
    public Text countLevelsText;

    //Items totales ha coger en los niveles
    public const int totalItems = 12;

    //color de los items de la UI
    private Color greenColor = Color.green;
    private Color redColor = Color.red;




    //empujon del enemigo
    public float knockbackForce = 0.001f;

    //referencia al objeto del enemigo
    public GameObject enemy;



    //variables públicas que son las camaras
    public GameObject cameraNormal;
    public GameObject firstPersonCamera;
    public GameObject cenitalCamera;





    //metodo que sirve para iniciar estados de objetos
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countObjectsInt = 0;
        countLevelInt = 1;
        countLifeInt = 3;
        setCountText();
        setLevelText();
        setLifeText();
    
    }




    //metodo para mover al jugador
    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;


    }


    //metodo que se llama en el transcurso de cada frame
    private void FixedUpdate()
    {
        if (cameraNormal.activeSelf || cenitalCamera.activeSelf)
        {
            Debug.Log("hola, entre en la camera normal");
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);

            rb.AddForce(movement * speed);
        }
        Debug.Log("Estado de la camara normal" + cameraNormal.activeSelf);
        Debug.Log("Estado de primera persona: " + firstPersonCamera.activeSelf);
        if (firstPersonCamera.activeSelf)
        {
            Debug.Log("hola, entre en la primera persona");


            Quaternion cameraRotation = firstPersonCamera.transform.rotation; // esto obtiene la rotacíon de la cámara


            Vector3 cameraForward = cameraRotation * Vector3.forward; // esto calcula la dirección hacia adelante de la cámara


            Vector3 movementDirection = Vector3.ProjectOnPlane(cameraForward, Vector3.up).normalized; // esto  Proyecta la dirección hacia adelante en el plano horizontal (ignora inclinaciones verticales)


            Vector3 movement = movementDirection * movementY; // Crea el vector de movimiento basado en el input y la dirección de la cámara


            rb.AddForce(movement * speed);
        }

        setCountText();
        setLevelText();
        setLifeText();
        setColorText(countObjectsInt);
        resetFallPlayer();
        changeLevel();
        
    }


    //metodo que actúa cuando entramos en el area de un objeto
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            countObjectsInt += 1;
            setCountText();

        }
    }

    //metodo para sumar los items recogidos y actualizar la UI
    void setCountText()
    {
        countObjectsText.text = "Items: " + countObjectsInt.ToString() + "/12";
    }

    //metodo para restar las vidas del jugador y actualizar la UI
    void setLifeText()
    {
        countLifeText.text = "Vidas: " + countLifeInt.ToString() + "/3";
    }

    //metodo para sumar niveles y actualizar la UI
    void setLevelText()
    {
        countLevelsText.text = "Level: " + countLevelInt.ToString() + "/3";

    }

    //metodo que actualiza el color de la UI de los items al llegar a 12 de 12
    void setColorText(int numberItem)
    {
        if (numberItem >= totalItems)
        {
            countObjectsText.color = greenColor;
        }
    }

    //metodo que aplica la fuerza al player cuando es tocado por el enemigo
    public void ApplyKnockback()
    {
        Vector3 knockback = new Vector3(0f, knockbackForce, 0f);
        rb.AddForce(knockback, ForceMode.Impulse);
    }

    //metodo para cambiar de niveles
    void changeLevel()
    {
        /*
            Explicacion:
            1. Para cambiar de niveles, verificamos si has cogido todos los items
            2. si es así el nivel le sumamos un +1
            3. luego vamos cambiando de niveles dependiendo de el valor del nivel
            4. en cada nivel, hacemos reseteo de items encontrados, posicion del jugador y del enemigo
            5. para el enemigo, tenemos que deshabilitar al agente ya que si no bloquea la posicion y no nos deja moverlo
        */
        if (countObjectsInt == totalItems)
        {
            countLevelInt += 1;
            if (countLevelInt == 2)
            {
                transform.position = new Vector3(77.02f, 3.79f, -0.889570f);
                firstPersonCamera.transform.position = new Vector3(77.02f, 3.79f, -0.6f);

                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.enabled = false;
                    enemy.transform.position = new Vector3(68.23f, 3.676f, 0.768f);
                    agent.enabled = true;
                    countObjectsInt = 0;
                    countObjectsText.color = redColor;
                }
            }
            if (countLevelInt == 3)
            {
                transform.position = new Vector3(38.99f, 3.79f, -151.89f);
                firstPersonCamera.transform.position = new Vector3(38.99f, 3.79f, -151.89f);

                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.enabled = false;
                    enemy.transform.position = new Vector3(54.18f, 3.69f, -136.6f);
                    agent.enabled = true;
                    countObjectsInt = 0;
                    countObjectsText.color = redColor;
                }

            }




        }


    }

    void resetFallPlayer()
    {
        if (transform.position.y < limitY && countLevelInt == 1)
        {
            countLifeInt -= 1;
            transform.position = new Vector3(-1.723833f, 3.79f, -0.8895702f);
        }
        else if (transform.position.y < limitY && countLevelInt == 2)
        {
            countLifeInt -= 1;
            transform.position = new Vector3(77.02f, 3.79f, -0.889570f);
        }
        else if (transform.position.y < limitY && countLevelInt == 3)
        {
            countLifeInt -= 1;
            transform.position = new Vector3(38.99f, 3.79f, -151.89f);
        }
    }




}
