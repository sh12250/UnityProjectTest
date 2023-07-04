using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    private float rotationSpeed = 50.0f;
    private Vector3 cubeRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This is Unity's Hello World!!!");

        // 모든 transform는 gameObject를 들고있다
        // 모든 gameObject는 transform를 들고있다
        // transform.Rotate(new Vector3(0f, 45f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        cubeRotation.x = (rotationSpeed * Time.deltaTime);
        cubeRotation.y = (rotationSpeed * Time.deltaTime);
        transform.Rotate(cubeRotation);
    }
}
