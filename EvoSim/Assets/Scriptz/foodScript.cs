using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodScript : MonoBehaviour
{
    public bool targeted = false;
    public GameObject[] entityList;
    public string predatorName;
    // Start is called before the first frame update
    void Start()
    {
        setPos();
        Destroy(gameObject, 10f);
    }
    void setPos()
    {
        transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1.13f, Random.Range(-20.0f, 20.0f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "wall")
        {
            setPos();
        }
        if(collision.collider.name == predatorName)
        {
            
                Destroy(gameObject);
            
        }
    }
}
