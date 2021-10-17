using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{

    public float wanderRadius = 100;
    public float wanderTimer = 3;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;

    public agentVariables variables;
    private string foodLocation;
    private Vector3 targetPos;
    public bool foundFood = false;
    public bool eaten = false;

    // OnEnable is called at the start of the program
    void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        huntFood();
        if (!foundFood)
        {
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomWander(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }   
    }



    public static Vector3 RandomWander(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    private void huntFood()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, variables.vision);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "food" && hitCollider.GetComponent<foodScript>().targeted == false && variables.getFoodEaten() < 2)
            {
                    foundFood = true;
                    agent.destination = gameObject.transform.position;
                    foodLocation = hitCollider.name;
                    hitCollider.gameObject.GetComponent<foodScript>().predatorName = name;
                    hitCollider.GetComponent<foodScript>().targeted = true;
                    targetPos = hitCollider.transform.position;
                    agent.SetDestination(targetPos);
            }
            break;
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "food")
        {
            variables.setFoodEaten(variables.getFoodEaten() + 1);
            variables.setSpeed(2);
            foundFood = false;
        }
        if (variables.getFoodEaten() > 1)
        {
            Debug.Log("now i can reproduce");
            foundFood = false;
            //foundFood = true;
            //agent.SetDestination(new Vector3(20, 1.25f, 20));
        }
    }
}