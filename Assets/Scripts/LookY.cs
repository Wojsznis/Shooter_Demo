using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {  
        LookYAxis();
    }

    void LookYAxis()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - (mouseY * sensitivity), 
        transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
