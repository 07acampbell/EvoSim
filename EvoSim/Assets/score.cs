using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public agentVariables attached;
    public Text scoretext;
    public Camera cam;

  

    // Update is called once per frame
    void Update()
    {
        scoretext.text = attached.getFoodEaten().ToString();
        transform.LookAt(cam.transform);
    }
}
