# FSM Simple
### Cambios en el proyecto

- He creado el suelo usando planos y estos les he metido debajo del un objeto padre "Floors". A este objeto padre le he asignado un **NavMesh Surface** con un **Agent Type** "Humanoid" y en **Use Geomentry** lo puse a "Physics Colliders". Hice un "bake".
- También he creado paredes con cubos y colliders (previo al bake).
- He creado un punto de destino "Assembly Point" con un cilindro donde irán los NPCs cuando suene la bomba.
- Luego creé un NPC con un clindro, le agregué un **Nav Mesh Agent** con Agent Type a "Humanoid", speed a 5.
- A este NPC le adjunte un script en el que tiene dos estados, pasear e ir al punto seguro. El estado del inicio es pasear y cuando se activa la bomba con la tecla "E" cambia al otro estado. Dentro de este script hay varios parametros como velocidad de movimiento, de rotación, tiempos de espera entre cada movimiento, y la distancía que puede pasear desde donde se encuentran.
- Para la función de pasear (Wander), cuando el tiempo de espera ha pasado, creo un nuevo punto aleatorio con Random.Range dentro de un Vector3 y mando al agente a ese punto con NavMesh Agent SetDestination.
- Para ir al punto seguro cuando suena la bomba, establezco el SetDestination a la posición donde se encuentra dicho punto seguro (gameobject en parámetros).
- Para el sonido de la bomba le puse un AudioSource a la camerá y un script que detecta cuando la tecla "E" se pulsa.
- Hice un prefab con el NPCs y puse varios por el escenario.


[Vínculo al repositorio en Github](https://github.com/jnomada/IAFiniteStateMachineSimple)