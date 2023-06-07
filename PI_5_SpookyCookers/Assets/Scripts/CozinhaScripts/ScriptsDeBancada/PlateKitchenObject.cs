using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient (KitchenObjectSO kitchenObjectSO)
    {
        if(!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        }
        //C�digo para identificar ingredientes duplicados, possivelmente farei altera��es para o player poder errar a receita na hora de montar.
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        } else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
       
    }
}
