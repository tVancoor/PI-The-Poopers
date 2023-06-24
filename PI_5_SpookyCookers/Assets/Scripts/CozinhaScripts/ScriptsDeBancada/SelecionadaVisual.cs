using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionadaVisual : MonoBehaviour
{
    [SerializeField] private BancadaBase bancadaBase;
    [SerializeField] private GameObject[] visualGameObjectArray;
    private void Start()
    {
        if (PlayerTeste.LocalInstance != null)
        {
            PlayerTeste.LocalInstance.OnSelectedCounterChanged += PlayerTeste_OnSelectedCounterChanged;
        } else
        {
            PlayerTeste.OnAnyPlayerSpawned += PlayerTeste_OnAnyPlayerSpawned;
        }
        
    }
    private void PlayerTeste_OnAnyPlayerSpawned(object sender, EventArgs e)
    {
        if (PlayerTeste.LocalInstance != null)
        {
            PlayerTeste.LocalInstance.OnSelectedCounterChanged -= PlayerTeste_OnSelectedCounterChanged;
            PlayerTeste.LocalInstance.OnSelectedCounterChanged += PlayerTeste_OnSelectedCounterChanged;
        }
    }

    private void PlayerTeste_OnSelectedCounterChanged(object sender, PlayerTeste.OnSelectedCounterChangedEventArgs e)
    {
        if (e.bancadaSelecionada == bancadaBase)
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
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }  
    }

    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(false);
        }
    }
}
