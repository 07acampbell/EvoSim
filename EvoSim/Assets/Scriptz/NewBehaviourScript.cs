using UnityEngine;
using System.Collections;
using System;

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
    public Vector3 oldPos;
    public Renderer myRenderer;
    public Rigidbody rigidbody;
    public float velocity;

    // OnEnable is called at the start of the program
    void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
        variables.setSpeed((int)Mathf.Floor(UnityEngine.Random.Range(1f, 10f)));
        myRenderer = gameObject.GetComponent<Renderer>();
        Color setCol = new Color(variables.speed / 10, 0.1f, 0.1f, 1f);
        myRenderer.material.color = setCol;
        agent.speed = variables.speed;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("ExecuteAfterTime");
        wonder();
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(1f);
        oldPos = transform.position;
    }

    private void wonder()
    {
        if (oldPos == transform.position)
        {
                
            Vector3 wanderTo = new Vector3(UnityEngine.Random.RandomRange(-20f, 20f), transform.position.y, UnityEngine.Random.RandomRange(-20f, 20f));
                huntFood(new Vector3(UnityEngine.Random.RandomRange(-20f, 20f), transform.position.y, UnityEngine.Random.RandomRange(-20f, 20f)));
            

        }

    }

    public void huntFood(Vector3 target)
    {
        agent.SetDestination(target);

        if (variables.getFoodEaten() < 3)
        {
            foundFood = true;
            agent.SetDestination(target);
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