using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public int maxHealt;
    [SerializeField] int currentHealt;

    [SerializeField] TextMeshProUGUI currentHealtText;

    private void Start()
    {
        currentHealt = maxHealt;
        currentHealtText.text = currentHealt.ToString();
    }
    public void TakeDamage()
    {
        currentHealt--;
        currentHealtText.text = currentHealt.ToString();
        if (currentHealt <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage();
        }

        if (other.CompareTag("Item"))
        {
            other.GetComponent<IItem>().Destroyed();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Pistol"))
        {
            Time.timeScale = 0;
            Debug.Log("Game OVER");
            if (Gun.Instance.finishMultiPoint > 0)
            {
                UIController.Instance.Victory();
            }

            else
            {
                UIController.Instance.GameOver();
            }
        }
    }
}
