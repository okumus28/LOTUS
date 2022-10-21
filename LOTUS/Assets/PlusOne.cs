using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : IItem
{
    //public Transform[] firePoint;

    public override void Calculate()
    {
        Gun.Instance.bulletForPerSecond += calValue;

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    firePoint[i] = transform.GetChild(i).transform;
        //}

        //for (int i = 0; i < firePoint.Length; i++)
        //{
        //    Instantiate(bulletPrefab , firePoint[i].transform.position ,Quaternion.identity);
        //}
    }
}
