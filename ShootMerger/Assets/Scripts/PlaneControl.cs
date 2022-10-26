using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    public int multiPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pistol"))
        {
            Gun.Instance.finishMultiPoint = multiPoint;
            if (multiPoint >= 10)
            {
                Time.timeScale = 0;
                UIController.Instance.Victory();
            }
        }
    }

}
