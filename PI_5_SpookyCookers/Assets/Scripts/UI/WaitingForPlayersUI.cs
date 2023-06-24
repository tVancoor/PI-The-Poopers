using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForPlayersUI : MonoBehaviour
{
    private void Start()
    {
        KitchenManager.Instance.OnLocalPlayerReadyChanged += KitchenManager_OnLocalPlayerReadyChanged;
        KitchenManager.Instance.OnStateChanged += KitchenManager_OnStateChanged;


        Hide();
    }

    private void KitchenManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void KitchenManager_OnLocalPlayerReadyChanged(object sender, System.EventArgs e)
    {
        if (KitchenManager.Instance.IsLocalPlayerReady())
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
