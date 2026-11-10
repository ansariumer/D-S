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
    //private bool enemyKilled = false;

    private int enemyKilledCount = 0;
    private Coroutine myCoroutineRef; // for avoiding another coroutine to run

    void Awake()
    {
        ComboParent.SetActive(false);
        //enemyKilled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blasto") && playerHealht.health >= 100)
        {
            enemyKilledCount++;
            //enemyKilled = true;
            if (myCoroutineRef != null)
            {
                Debug.Log("Timer already running");
                return;
            }
            myCoroutineRef = StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        timer = 8f;

        while(timer > 0)
        {
            if (enemyKilledCount >= 3)
            {
                Debug.Log("Combo Bar Appear!!");
                ComboParent.SetActive(true);
                comboBar.ComboStart();
                //comboBar.ResetFill();
                myCoroutineRef = null;
                yield break;
            }

            Debug.Log(timer);
            yield return new WaitForSeconds(1f);
            timer--;
        }
        enemyKilledCount = 0;
        Debug.Log("No Combo");
        
        myCoroutineRef = null;
    }
}
