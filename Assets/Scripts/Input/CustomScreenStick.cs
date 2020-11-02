using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;

public class CustomScreenStick : OnScreenStick, IPointerDownHandler, IPointerUpHandler
{
    [Header("Custom")]
    [SerializeField] GameObject controlParent;
    
    PlayerInput playerInput;

    private void Awake()
    {
        controlParent.SetActive(Application.isMobilePlatform);
        playerInput = FindObjectOfType<PlayerInput>();
    }

    public new void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        playerInput.SwitchCurrentControlScheme("Gamepad");
    }
    
    public new void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        playerInput.SwitchCurrentControlScheme("Keyboard&Mouse");
    }
}
