using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lookatcam : MonoBehaviour
{
    public Camera cam;
    private Transform local;

    private void Start()
    {
        local = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, -Vector3.down);
        transform.RotateAround(transform.position, transform.up, 180f);
    }
}