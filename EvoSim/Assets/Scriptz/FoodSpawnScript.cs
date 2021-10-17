using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnScript : MonoBehaviour
{
    public GameObject foodFab;
    public float delay;
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(foodFab);
        StartCoroutine(spawn());
    }
}
