using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ComboCounter : MonoBehaviour
{
    [Header("Enemies")]
    public GameObject Blasto;
    public GameObject Dacenta;
    public GameObject Scholler;

    public PlayerHealth playerHealht;
    //public Image comboCounter;
    private float timer = 8f;
    //private bool enemyKilled = false;

    private int enemyKilledCount = 0;

    /*void Awake()
    {
        //comboCounter.SetActive(false);
        enemyKilled = false;
    }*/

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blasto") && playerHealht.health >= 100)
        {
            enemyKilledCount++;
            //enemyKilled = true;
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        timer = 8f;

        while(timer > 0)
        {
            if (enemyKilledCount >= 3)
            {
                Debug.Log("Rest CC");
                yield break;
            }

            Debug.Log(timer);
            yield return new WaitForSeconds(1f);
            timer--;
        }
        Debug.Log("No Combo");
        yield break;
    }
}
