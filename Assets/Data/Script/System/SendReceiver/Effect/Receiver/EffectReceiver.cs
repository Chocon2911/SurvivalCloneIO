using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectReceiver : HuyMonoBehaviour
{
    [SerializeField] protected EffectReceiverSO effectReceiverSO;
    public EffectReceiverSO EffectReceiverSO => effectReceiverSO;
}
