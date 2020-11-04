using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToMainCamera : MonoBehaviour
{
    [SerializeField] bool triggerOnce;
 
    [ContextMenu("Update")]
    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
        
        if (triggerOnce && Application.isPlaying)
            enabled = false;
    }
}
