using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemento : MonoBehaviour
{
    void Start()
    {
        
    }
    [SerializeField] private GameObject camera;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);

    [SerializeField] private float speed = 10f;
    [SerializeField] private float lateralSpeed = 15f;

    private float horizontalInput;
    private float verticalInput;
    private float rotateInput;
    private float rt;
    private float angle =0;
    private Vector3 noffset = new Vector3(0, 0, 0);
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Rotate");
        rt = rotateInput * Time.deltaTime * 10;
        Debug.Log(rt);

        if (verticalInput != 0)
        {
            if (verticalInput < 0)
            {
                transform.Rotate(0, -horizontalInput * lateralSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, horizontalInput * lateralSpeed * Time.deltaTime, 0);
            }
        }
       
        transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime * verticalInput);
        angle += rt;
        noffset = new Vector3(angle % 180 * 0.11111111111f, 5f, (angle % 180 * 0.1111111111111f) - 10);
        camera.transform.Rotate(0, rt, 0);
        camera.transform.position = transform.position + noffset;

    }
}
