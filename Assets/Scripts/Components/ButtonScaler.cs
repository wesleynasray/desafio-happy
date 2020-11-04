using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Transform toScale;
    
    public UnityEvent OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        toScale.localScale *= .9f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        toScale.localScale /= .9f;
    }
}
