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

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        if(verticalInput != 0)
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

        camera.transform.position = transform.position + offset;

    }
}
