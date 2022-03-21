using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] GameObject crateDestroyed;

    public void DestroyCrate()
    {
        Instantiate(crateDestroyed, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
