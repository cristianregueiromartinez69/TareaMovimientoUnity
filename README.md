# TAREA UNITY: MOVIMIENTO DE LA CÁMARA Y EL JUGADOR 😄

**Índice** 😎

1. Explicación del script de la cámara normal.
2. Explicación del script de la cámara en primera persona.
3. Explicación del script de la cámara cenital.
4. Explicación del script de la camara manager.
5. Explicación del script del jugador.


### 1. Explicación del script de la cámara normal.

Este script permite que un objeto (como la cámara) siga a otro objeto (generalmente el jugador) mientras mantiene una distancia y posición relativa constante. Es ideal para juegos en tercera persona, donde la cámara necesita seguir al jugador sin moverse demasiado cerca o lejos de él.

Descripción
El script CameraController asegura que la cámara (u otro objeto que tenga este script) siga al jugador durante el juego, manteniendo una distancia constante entre ambos. La posición de la cámara se ajusta automáticamente según el movimiento del jugador.

Requisitos
Unity 3D (cualquier versión reciente).
Un GameObject para el jugador (player).
Un GameObject que actúe como la cámara o el objeto que debe seguir al jugador.
Funcionamiento
El script se encarga de ajustar la posición de la cámara para que siempre siga al jugador desde la misma distancia. La posición de la cámara se actualiza en cada fotograma durante la ejecución del juego.

### 2. Explicación del script de la cámara en primera persona.

