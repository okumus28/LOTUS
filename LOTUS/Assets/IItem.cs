using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class IItem : MonoBehaviour
{
    [SerializeField]
    public enum Process
    {
        plus,
        multi
    }

    //public Transform[] firePointt;
    public List<Transform> firePoint;

    private void Start()
    {
        GetFirePoints();
    }

    public Process process;
    public GameObject bulletPrefab;
    public int calValue;
    public abstract void Calculate();
    public void GetFirePoints()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //firePoint[i] = transform.GetChild(i).transform;
            firePoint.Add(transform.GetChild(i));
        }
    }
}
