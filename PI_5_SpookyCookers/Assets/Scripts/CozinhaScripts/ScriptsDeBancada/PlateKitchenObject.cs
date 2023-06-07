using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static PlateKitchenObject;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler <OnIngredientAddedEventArgs> OnIngredientAdded;

    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

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
        //Código para identificar ingredientes duplicados, possivelmente farei alterações para o player poder errar a receita na hora de montar.
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        } else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });

            return true;
        }
       
    }
    public List<KitchenObjectSO> GetKichenObjectSOList()
    {
        return kitchenObjectSOList;
    }

}
