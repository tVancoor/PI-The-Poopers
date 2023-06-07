using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BancadaBase
{
    public override void Interact(PlayerTeste player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
        }
    }
}
