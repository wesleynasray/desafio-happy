using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerUpOption : MonoBehaviour, IPointerClickHandler
{
    public static event Action<PowerUpOption> OnClicked;

    [SerializeField] Text label;
    [SerializeField] Image icon;
    [SerializeField] PowerUpBase m_PowerUp;
    
    public PowerUpBase PowerUp { get => m_PowerUp; set => SetPowerUp(value); }

    private void SetPowerUp(PowerUpBase power)
    {
        m_PowerUp = power;
        label.text = power.Name.Replace(' ', '\n');
        icon.sprite = power.Icon;
    }

    public void OnPointerClick(PointerEventData eventData) => OnClicked?.Invoke(this);
}
