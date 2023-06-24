using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class BancadaBase : NetworkBehaviour, IKitchenObjectParent
{
    //public static event EventHandler OnAnyObjectPlacedHere;
    public static void ResetStaticData()
    {
        //OnAnyObjectPlacedHere = null;
    }

    [SerializeField] private Transform topoDaBancada;
    
    private KitchenObject kitchenObject;

    public virtual void Interact(PlayerTeste player)
    {
        Debug.LogError("BaseCounter.Interact();"); 
    }

    public virtual void InteractAlternate(PlayerTeste player)
    {
        //Debug.LogError("BaseCounter.InteractAlternate();");
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return topoDaBancada;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

    public NetworkObject GetNetworkObject()
    {
        return NetworkObject;
    }
}
