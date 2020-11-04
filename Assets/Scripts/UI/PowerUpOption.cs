using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerUpOption : MonoBehaviour, IPointerClickHandler
{
    public static event Action<PowerUpOption> OnClicked;
    public void OnPointerClick(PointerEventData eventData) => OnClicked?.Invoke(this);
}
