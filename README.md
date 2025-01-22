# Proyecto Unity - Descripción de Scripts

Este archivo README proporciona una explicación de cada uno de los scripts incluidos en este proyecto de Unity. Los scripts están diseñados para manejar la cámara, las interacciones del jugador y los objetos recogibles.

---

## **1. camara2ºPiso.cs**

### Propósito
Este script controla la posición de la cámara para que siga al jugador mientras mantiene una distancia fija. Es específico para situaciones en las que la cámara debe permanecer en el mismo plano que el jugador, como un segundo piso.

### Funcionalidades clave
- Calcula un **offset** inicial entre la cámara y el jugador.
- Actualiza la posición de la cámara en el método `LateUpdate` para seguir al jugador con el offset calculado.

---

## **2. CameraScript.cs**

### Propósito
Este script proporciona un control avanzado de la cámara para seguir al jugador y manejar la rotación basada en la entrada del ratón. Está diseñado para una perspectiva en primera persona o tercera persona.

### Funcionalidades clave
- **Seguimiento del jugador:** Similar al script `camara2ºPiso.cs`, calcula un offset para la posición de la cámara.
- **Control de rotación:** La cámara rota en función del movimiento del ratón, con ángulos verticales limitados para evitar rotaciones extrañas.
- **Interacción con el cursor:** Bloquea el cursor en la pantalla para una experiencia de control inmersiva.

---

## **3. PickUp.cs**

### Propósito
Este script proporciona funcionalidad para un objeto recogible, como un ítem que el jugador puede recolectar en el juego.

### Funcionalidades clave
- **Rotación constante:** El objeto rota continuamente en los ejes X, Y y Z usando `Update` para hacerlo visualmente más atractivo.

---

## **4. player.cs**

### Propósito
Este script controla el comportamiento y las interacciones del jugador, incluyendo el movimiento, el salto y la recogida de objetos.

### Funcionalidades clave
- **Movimiento:**
  - Utiliza un `Rigidbody` para aplicar fuerzas basadas en la entrada del jugador.
  - Soporta movimiento en los ejes X y Y mediante la entrada del teclado.
- **Salto:**
  - Detecta si el jugador está en el suelo antes de aplicar una fuerza hacia arriba.
- **Recogida de objetos:**
  - Detecta colisiones con objetos recogibles usando `OnTriggerEnter`, desactivándolos al recogerlos y actualizando un contador interno.
- **Interacción con la cámara:**
  - Calcula direcciones de movimiento en función de la orientación de la cámara.

---

## **Instrucciones de Uso**
1. **camara2ºPiso.cs:**
   - Asigne este script a una cámara secundaria que seguirá al jugador en escenarios específicos como un segundo piso.
   - Vincule el objeto jugador en el campo `player` del Inspector.

2. **CameraScript.cs:**
   - Use este script para una cámara principal que siga al jugador y permita controles de rotación.
   - Asigne los valores necesarios como `player`, `playerBody` y la sensibilidad del ratón.

3. **PickUp.cs:**
   - Asigne este script a los objetos que el jugador puede recoger.
   - Estos objetos rotarán automáticamente para mayor atractivo visual.

4. **player.cs:**
   - Este script debe ser asignado al modelo del jugador.
   - Asegúrese de configurar un componente `Rigidbody` en el jugador y ajustar la velocidad.
   - Vincule la cámara del juego en el campo `camara` del Inspector.

---
