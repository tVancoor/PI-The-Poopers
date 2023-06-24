using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    private void Awake()
    {
        CuttingCounter.ResetStaticData();
        BancadaBase.ResetStaticData();
        TrashCounter.ResetStaticData();
    }
}
