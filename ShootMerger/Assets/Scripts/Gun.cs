using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun Instance { get; private set; }

    public int speed = 10;
    [SerializeField] Transform firePoint;
    public GameObject bulletPrefab;

    bool change = false;


    public int finishMultiPoint = 0;
    public int _bulletForPerSecond;
    public int bulletForPerSecond
    {
        get { return _bulletForPerSecond; }
        set 
        {
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
        finishMultiPoint = 0;
    }

    private void Update()
    {
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
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 10;
        if (Input.GetMouseButton(0))
        {
            x = Input.GetAxisRaw("Mouse X");
        }

        transform.position += new Vector3(x, 0, speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), 0, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnPicked"))
        {
            transform.localScale = Vector3.one;
            other.GetComponent<IItem>().Calculate(bulletForPerSecond);
            //StopCoroutine(nameof(Fire));
            other.tag = "Item";
            other.transform.parent = this.transform;

            int x = Mathf.RoundToInt(other.transform.localPosition.x);
            float y = -0.5f;
            int z = Mathf.RoundToInt(other.transform.localPosition.z);

            Vector3 newCord = new Vector3(x , y , z);
            other.transform.localPosition = newCord;
        }
    }
}
