using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : BancadaBase
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(PlayerTeste player)
    {
        if (!HasKitchenObject())
        {
            if (!player.HasKitchenObject())
            {
               KitchenObject.SpawnKitchenObjectSO(kitchenObjectSO, player);
            }
        }
    }
}
