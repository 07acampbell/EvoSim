using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public agentVariables variables;
    public bool foundFood = false;
    public string targetDest;
    private Vector3 targetPos;
    void Update()
    {
        agent.speed = variables.speed;
        move();
    }

    public void huntFood()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "food" && hitCollider.GetComponent<foodScript>().targeted == false && variables.getFoodEaten() < 2)
            {
                foundFood = true;
                targetDest = hitCollider.name;
                hitCollider.gameObject.GetComponent<foodScript>().predatorName = name;
                hitCollider.GetComponent<foodScript>().targeted = true;
                targetPos = hitCollider.transform.position;
                agent.SetDestination(targetPos);
                break;

            }
        }
        
    }
    

    private void move()
    {
        if (foundFood == false)
        {
            int[] possibleValues = { Random.Range(-20, -10), Random.Range(10, 20), Random.Range(-20, -10), Random.Range(10, 20)};
            agent.SetDestination(new Vector3( possibleValues[Random.Range(0,2)], 1.25f, possibleValues[Random.Range(2, 4)]));
            
        }
        huntFood();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "food")
        {
            variables.setFoodEaten(variables.getFoodEaten() + 1);
            variables.setSpeed(2);
            foundFood = false;
        }
        if(variables.getFoodEaten() > 1)
        {
            Debug.Log("now i can reproduce");
            foundFood = true;
            agent.SetDestination(new Vector3(20, 1.25f, 20));
        }
    }



}
