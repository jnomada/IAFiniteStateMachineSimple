using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))] // Requiere NavMeshAgent
public class NPCController : MonoBehaviour
{
    enum State { Wander, RunToExit }; // Los dos estados
    State currentState = State.Wander; // Estado actual
    [SerializeField] Transform assemblyPointLocation; // Destino cuando suena la bomba
    [SerializeField] float movementSpeed; // Velocidad de movimiento
    [SerializeField] float rotationSpeed; // Velocidad de rotación
    [SerializeField] float waitingTimeMin; // Tiempo mínimo de espera cuando llega a un punto aleatorio
    [SerializeField] float waitingTimeMax; // Tiempo máximo de espera cuando llega a un punto aleatorio
    [SerializeField] float wanderDistance; // Distancia que puede pasear desde donde se encuentra
    float waitingTimePassed = 0; // Guardamos el tiempo pasado
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Obtenemos el NavMeshAgent del objeto
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Escuchamos la entrada del teclado
        {
            currentState = State.RunToExit; // Cambiamos el estado cuando suena la bomba
        }

        switch (currentState)
        {
            // Según cual sea el estado lanzamos una función u otra
            case State.Wander: 
            Wander();
            break;
            case State.RunToExit:
            RunToExit();
            break;
        }
    }

    // Función de pasear de forma aleatoria
    void Wander()
    {
        waitingTimePassed += Time.deltaTime; // Añadimos tiempo al tiempo pasado
        float waitingTime = Random.Range(waitingTimeMin, waitingTimeMax); // Establecemos un tiempo de espera aleatorio
        if (waitingTimePassed > waitingTime) // Si el tiempo pasado supera el tiempo de espera camina a otro punto aleatorio
        {
            waitingTimePassed = 0; // Reseteamos el tiempo pasado
            Vector3 wanderPoint = new Vector3(Random.Range(-wanderDistance, wanderDistance), 0, Random.Range(-wanderDistance, wanderDistance)); // Creamos un nuevo destino aleatorio
            navMeshAgent.SetDestination(wanderPoint); // Le decimos al NavMeshAgent donde está el nuevo punto donde tiene que ir
        }
    }

    void RunToExit()
    {
        Debug.Log("BOMB!!");
        navMeshAgent.SetDestination(assemblyPointLocation.position); // Enviamos al agente al punto seguro
    }
}
