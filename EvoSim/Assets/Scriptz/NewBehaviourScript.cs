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
    public int sizeScale;

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
        transform.position = new Vector3(UnityEngine.Random.Range(-20.0f, 20.0f), 1.13f, UnityEngine.Random.Range(-20.0f, 20.0f));
        sizeScale = UnityEngine.Random.Range(1, 3);
        transform.localScale = new Vector3(1 * sizeScale, 0.75f * sizeScale, 1 * sizeScale);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
        variables.setSpeed((int)Mathf.Floor(UnityEngine.Random.Range(1f, 10f)));//ranhdomly assigns speed stat for gen 0.
        myRenderer = gameObject.GetComponent<Renderer>();//gets entity renderer.
        Color setCol = new Color(variables.speed / 10, 0.1f, 0.1f, 1f);//picks a shade of red based on speed stat.
        myRenderer.material.color = setCol;//sets material colour to the chosen shade above
        agent.speed = variables.speed;//sets movement speed to match speed stat.
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("ExecuteAfterTime");
        wonder();
    }

    IEnumerator ExecuteAfterTime()//stops the 'standing still' bug encountered in phase 1.
    {
        yield return new WaitForSeconds(1f);
        oldPos = transform.position;
    }

    private void wonder()
    {
        if (oldPos == transform.position)//updated wandering algorithm, that is more efficient and less CPU intensive.
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