using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : ScriptableObject
{
    [SerializeField] string m_PowerName;
    [SerializeField] Sprite m_Icon;
    [SerializeField] PowerUpBase[] m_PowerUpsToOverride;

    public string Name => m_PowerName;
    public Sprite Icon => m_Icon;
    public PowerUpBase[] PowerUpsToOverride => m_PowerUpsToOverride;

    public abstract void Action(GameObject caller);
}
