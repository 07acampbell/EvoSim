using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finderscript : MonoBehaviour
{
    public NewBehaviourScript parent;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        foodScript fs = collision.GetComponent<foodScript>(); // if the entity has found food
        if (collision.gameObject.tag == "food" && !fs.targeted)
        {
            parent.huntFood(collision.transform.position);
            parent.foundFood = true; // go to the food, and mark it as targeted so other entities do not steal it.
            fs.targeted = true;
        } else if(collision.gameObject.tag == "entity" && this.parent.sizeScale < this.parent.sizeScale)
            //if the entity has found prey (smaller size than itself)^
        {
            parent.huntFood(collision.transform.position);
            parent.foundFood = true; // go to the prey, and mark it as targeted so other entities do not kill it.
            fs.targeted = true;
        }
    }
}
