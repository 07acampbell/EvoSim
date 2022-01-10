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
        foodScript fs = collision.GetComponent<foodScript>();
        if (collision.gameObject.tag == "food" && !fs.targeted)
        {
            parent.huntFood(collision.transform.position);
            parent.foundFood = true;
            fs.targeted = true;
        }
    }
}
