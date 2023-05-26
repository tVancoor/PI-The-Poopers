using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private BancadaScript bancadaScript;

    public KitchenObjectSO GetKitchenObjectSO() { 
        return kitchenObjectSO; 
    }

    public void SetClearCounter(BancadaScript bancadaScript)
    {
        this.bancadaScript = bancadaScript;
    }

    public BancadaScript GetBancadaScript() 
    {
        return bancadaScript;    
    }
}
