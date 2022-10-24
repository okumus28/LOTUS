using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class IItem : MonoBehaviour
{
    public List<Transform> firePoint;

    private void Start()
    {
        GetFirePoints();
    }
    public GameObject bulletPrefab;
    public int calValue;
    public abstract void Calculate(float time);
    public abstract void Destroyed();
    public void GetFirePoints()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            firePoint.Add(transform.GetChild(i));
        }
    }
}
