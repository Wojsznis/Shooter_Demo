using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{

    [SerializeField] private float sensitivity = 1f;

    void Start()
    {
        
    }

    void Update()
    {  
        LookXAxis();
    }

    void LookXAxis()
    {
        float mouseX = Input.GetAxis("Mouse X");

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 
        (mouseX * sensitivity), transform.localEulerAngles.z);
    }
}
