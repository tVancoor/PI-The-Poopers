using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionadaVisual : MonoBehaviour
{
    [SerializeField] private BancadaScript bancadaVazia;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        PlayerTeste.Instance.OnSelectedCounterChanged += PlayerTeste_OnSelectedCounterChanged;
    }

    private void PlayerTeste_OnSelectedCounterChanged(object sender, PlayerTeste.OnSelectedCounterChangedEventArgs e)
    {
        if (e.bancadaSelecionada == bancadaVazia)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
