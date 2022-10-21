using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun Instance { get; private set; }

    [SerializeField] Transform firePoint;
    public GameObject bulletPrefab;
    bool change = false;

    [SerializeField]float offsetZ;

    public int _bulletForPerSecond;
    public int bulletForPerSecond
    {
        get { return _bulletForPerSecond; }
        set 
        {
            Debug.Log("value change");
            _bulletForPerSecond = value;
            change = true;
        }
    }



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(nameof(Fire), bulletForPerSecond);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletForPerSecond++;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            bulletForPerSecond = 1;
        }

        if (change)
        {
            StopAllCoroutines();
            //CancelInvoke(nameof(Firee));
            Debug.Log("between");
            StartCoroutine(nameof(Fire), bulletForPerSecond);
            //InvokeRepeating(nameof(Firee), .1f, 1 / bulletForPerSecond);
            Debug.Log("last");

            change = false;
        }

        Move();
    }

    IEnumerator Fire(float time)
    {
        while (true)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1 / time);
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") / 2;
        float z = Input.GetAxisRaw("Vertical") / 2;
        transform.position += new Vector3(x, 0, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnPicked"))
        {
            other.transform.position = firePoint.position;
            other.tag = "Item";
            other.transform.parent = this.transform;
            other.transform.localPosition = Vector3.zero;
            other.transform.localPosition = new Vector3(0,-.5f,offsetZ);
            offsetZ += transform.localScale.z;
        }
    }
}
