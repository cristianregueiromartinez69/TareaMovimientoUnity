# tarea Unity: Movimiento de camara y jugador 😄

**Indice** 😎
1. Explicacion movimiento de las cámaras
2. Explicación movimiento jugador
3. Explicación del cámara manager

### 1. Explicacion movimiento de las cámaras 😄

En base al script de las cámaras, vamos a empezar por la primera de todas. La cámar normal que sigue al jugador.

### Cámara normal 😃
Este script implementa una cámara que sigue al jugador manteniendo una posición fija relativa a él.

Funcionalidad:
**player**: Referencia al objeto que la cámara seguirá (en este caso, el jugador).
**offset**: Vector que define la distancia inicial entre la cámara y el jugador. Se calcula al inicio del juego en el método Start.
Flujo del Script:
En Start(), el script calcula la diferencia entre la posición de la cámara (transform.position) y la posición del jugador (player.transform.position) y la guarda en offset.
En LateUpdate(), actualiza la posición de la cámara sumando el offset a la posición actual del jugador, manteniendo así la distancia inicial.

### Cámara primera persona 😃
Básicamente igual que el primero pero con matices:
1. Posicionamos la cámara justo en la parte frontal del jugador para simular la primera persona.
2. Le añadimos rotación cuando el jugador pulse las teclas de movimiento horizontal, esta línea
```bash
 if (movimientoHorizontal != 0)
        {
            transform.Rotate(0, movimientoHorizontal, 0);

        }
```
3. Nos vamos al script del jugador, ya qye ahí hay una referencia al movimiento del jugador para la cámara en primera persona.

```bash
if (firstPersonCamera.activeSelf)
        {
            Debug.Log("hola, entre en la primera persona");


            Quaternion cameraRotation = firstPersonCamera.transform.rotation; // esto obtiene la rotacíon de la cámara


            Vector3 cameraForward = cameraRotation * Vector3.forward; // esto calcula la dirección hacia adelante de la cámara


            Vector3 movementDirection = Vector3.ProjectOnPlane(cameraForward, Vector3.up).normalized; // esto  Proyecta la dirección hacia adelante en el plano horizontal (ignora inclinaciones verticales)


            Vector3 movement = movementDirection * movementY; // Crea el vector de movimiento basado en el input y la dirección de la cámara


            rb.AddForce(movement * speed);
        }
```
Este es el bloque de código que hace que cuando la cámara gire y le demos hacia adelante, vayamos en la dirección en la que apunta la cámara.

**Explicación** 🤗
1. Recogemos con Quaternion, la rotación de la cámara para saber a donde mira
2. Hacemos un vector 3, el cual multiplica la orientación de la cámara por Vector3.forward, este último es básicamente un vector hacia adelante
3. Luego lo que hacemos es hacer otro vector para normalizar el movimiento del vector anterior y que no vayamos súper rápido al ir hacia adelante
4. Por último añadimos la fuerza al jugador

**Importante** 😱
Si nos fijamos, le he quitado el movimiento horizontal al jugador, por eso es el if, que básicamente pregunta si la cámara en primera persona está o no activa.
1. Si la cámara está activa, el jugador no se desplaza horizontalmente, si no que si pulsa las teclas de derecha o izquierda, la camara se mueve y luego va hacia adelante o atrás en función de donde mira la cámara.
2. Si la cámara no está activa, el movimiento es el de la cámara normal

### 3. Cámara cenital 😄
El script es diferente al de las otras cámaras. Esta cámara gira en torno a algo y en el script lo vemos claramente.

**Explicación** 😄

1. Tenemos un array de planos que son sobre los que gira la cámara
2. Tenemos un indice para seleccionar el terreno correspondiente
3. El texto que indica si estamos en un nivel u en otro
4. La velocidad de rotación de la cámara

```bash
void Update()
    {

        transform.RotateAround(target[indexTerreno].position, Vector3.up, rotationSpeed * Time.deltaTime);

        transform.LookAt(target[indexTerreno]);
        changeTerremo();

    }

    void changeTerremo()
    {
        if (countLevelsTextToChange.text == "Level: 2/3"){
            indexTerreno = 1;
        }
        else if (countLevelsTextToChange.text == "Level: 3/3"){
            indexTerreno = 2;
        } 
    }
```
De lo anterior, el método que hace que cambie target, es decir, el terreno sobre el que gira la cámara, es el método changeTerreno(). Con un if, comprobamos el nivel en el que estamos para poner un target u otro.
Las variables al ser **públicas**, podemos meter los terrenos en el Unity y nos dá mucha flexibilidad.
El método para rotar al recedor es el .RotateAround que recibe varios parámetros:
1. La posicion del target
2. El vector3.Up, que es Y, es decir, la posicion sobre la que gira
3. la velocidad de rotación
4. el Time*deltaTime para que esté rotando continuamente

### Cámera manager 😄
Este script se encarga de manejar 
