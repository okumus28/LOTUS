using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTwo : IItem
{
    public override void Calculate(float time)
    {
        Gun.Instance.bulletForPerSecond *= calValue;
        StartCoroutine(nameof(Firee), time);
    }

    public override void Destroyed()
    {
        Gun.Instance.bulletForPerSecond /= calValue;
    }

    IEnumerator Firee(float time)
    {
        while (true)
        {
            for (int i = 0; i < firePoint.Count; i++)
            {
                Instantiate(bulletPrefab, firePoint[i].position + Vector3.forward, Quaternion.identity);
            }
            yield return new WaitForSeconds(1 / time);
        }
    }
}
