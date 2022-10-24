using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusThree : IItem
{
    public override void Calculate(float time)
    {
        Gun.Instance.bulletForPerSecond += calValue;
        StartCoroutine(nameof(Firee) , time);
    }
    public override void Destroyed()
    {
        Gun.Instance.bulletForPerSecond -= calValue;

    }
    IEnumerator Firee(float time)
    {
        while (true)
        {
            Instantiate(bulletPrefab, firePoint[firePoint.Count - 1].position + Vector3.forward, Quaternion.identity);
            yield return new WaitForSeconds(1 / time);
        }
    }
}
