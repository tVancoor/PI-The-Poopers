using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Search;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;


    private void Start()
    {
        KitchenManager.Instance.OnStateChanged += KitchenManager_OnStateChanged;

        Hide();

    }

    private void KitchenManager_OnStateChanged(object sender, System.EventArgs e)
    {
       if (KitchenManager.Instance.IsCountdownToStartActive())
        {
            Show();
        } else
        {
            Hide();
        }

    }

    private void Update()
    {
        countdownText.text = Mathf.Ceil(KitchenManager.Instance.GetCountdownToStartTimer()).ToString();
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
