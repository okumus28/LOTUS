using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.forward * 25;
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponent<IItem>().Calculate();
            Destroy(gameObject);
        }
    }

}
