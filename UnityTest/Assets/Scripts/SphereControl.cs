using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    public GameObject targetCube = default;
    public Vector3 rotateDirection = Vector3.zero;
    private float sphereSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This is Unity's Hello World!!!");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(targetCube.transform.position, rotateDirection, sphereSpeed * Time.deltaTime);
    }
}
