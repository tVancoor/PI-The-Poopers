using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMultiplayerUI : MonoBehaviour
{
    private void Start()
    {
        KitchenManager.Instance.OnMultiplayerGamePaused += KitchenManager_OnMultiplayerGamePaused;
        KitchenManager.Instance.OnMultiplayerGameUnpaused += KitchenManager_OnMultiplayerGameUnpaused;
        
        Hide();
    }

    private void KitchenManager_OnMultiplayerGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void KitchenManager_OnMultiplayerGamePaused(object sender, System.EventArgs e)
    {
        Show();
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
