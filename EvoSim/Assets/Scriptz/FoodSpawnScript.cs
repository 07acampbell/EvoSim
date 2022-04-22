using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnScript : MonoBehaviour
{
    public GameObject foodFab;
    public float delay;
    public GameObject creatureFab;
    private int count = 0;

    void Start()
    {
        
        StartCoroutine(spawn());//begins food spawning process
        
    }
    public void spawn(int x)// when the slider value is changed, it calls this function while passing in the new value as the argument.
    {
        count = 0;
        while (count <= x) // spawns x number of creatures
        {
            Instantiate(creatureFab);
            count += 1;
        }
    }

    IEnumerator spawn() // spawns food after certain delay - set in unity inspector.
    {
        yield return new WaitForSeconds(delay);
        Instantiate(foodFab);
        StartCoroutine(spawn());
    }
}
