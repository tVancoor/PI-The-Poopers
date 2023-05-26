using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancadaScript : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform topoDaBancada;

    private KitchenObject kitchenObject;
    public void Interact()
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, topoDaBancada);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetClearCounter(this);
        } else
        {
            Debug.Log(kitchenObject.GetBancadaScript());
        }
        
    }
}
