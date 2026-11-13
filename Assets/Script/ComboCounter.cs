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
    public GameObject ComboParent;
    public ComboBar comboBar;
    private float timer = 8f;

    private int enemyKilledCount = 0;
    private Coroutine myCoroutineRef; // for avoiding another coroutine to run

    void Awake()
    {
        ComboParent.SetActive(false);
    }

    public void DisappearBar()
    {
        Debug.Log("Bar disappear");
        StartCoroutine(Delay(.2f));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blasto") && playerHealht.health >= 100)
        {
            enemyKilledCount++;

            if (enemyKilledCount >= 3) // Under this Bar will appear
            {
                Debug.Log("Combo Bar Appear!!");
                ComboParent.SetActive(true);
                comboBar.ComboStart();
                //comboBar.ResetFill();
                myCoroutineRef = null;
                //yield break;
            }

            if (myCoroutineRef != null)
            {
                Debug.Log("Timer already running");
                return;
            }
            myCoroutineRef = StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown() // 8 sec countdown that start when a player kills an enemy 
    {
        timer = 8f;

        while(timer > 0)
        {
            /*if (enemyKilledCount >= 3) // Under this Bar will appear
            {
                Debug.Log("Combo Bar Appear!!");
                ComboParent.SetActive(true);
                comboBar.ComboStart();
                //comboBar.ResetFill();
                myCoroutineRef = null;
                //yield break;
            }*/
            Debug.Log("Killed" + enemyKilledCount);
            Debug.Log(timer);
            yield return new WaitForSeconds(1f);
            timer--;
        }

        enemyKilledCount = 0;
        Debug.Log("Killed" + enemyKilledCount);
        
        Debug.Log("No Combo");
        
        myCoroutineRef = null;
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ComboParent.SetActive(false);
    }
}
