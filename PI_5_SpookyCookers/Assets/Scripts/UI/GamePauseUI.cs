using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;
    
    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            KitchenManager.Instance.PauseGame();
        });

        restartButton.onClick.AddListener(() =>
        {
            //NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.Gameplay);
        });

        menuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.Menu);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    private void Start()
    {
        KitchenManager.Instance.OnLocalGamePaused += KitchenManager_OnLocalGamePaused;
        KitchenManager.Instance.OnLocalGameUnpaused += KitchenManager_OnLocalGameUnpaused;

        Hide();
    }

    private void KitchenManager_OnLocalGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void KitchenManager_OnLocalGamePaused(object sender, System.EventArgs e)
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
