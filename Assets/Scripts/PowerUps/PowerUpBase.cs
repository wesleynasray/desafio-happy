using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : ScriptableObject
{
    [SerializeField] Sprite icon;
    [SerializeField] PowerUpBase[] powerUpsToOverride;
    public abstract void Action(GameObject caller);
}
