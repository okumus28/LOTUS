using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlusTwo : IItem
{
    //public Transform[] firePoint;
    
    public override void Calculate()
    {
        //GetFirePoints();

        for (int i = 0; i < firePoint.Count; i++)
        {
            Instantiate(bulletPrefab, firePoint[i].position + Vector3.forward , Quaternion.identity);
        }
    }
}
