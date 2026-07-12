using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class dashButton : MonoBehaviour
{
    public Player player;
    public Button dashBtn;
    [SerializeField] private float stopDuration = 2f;
    private Coroutine stopRoutine;

    public void Dash()
    {
        player.Dash();

        if (stopRoutine == null)
        {
            dashBtn.interactable = false;
            stopRoutine = StartCoroutine(StopDash());
        }
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(stopDuration);
        
        dashBtn.interactable = true;
        stopRoutine = null;
    }
}