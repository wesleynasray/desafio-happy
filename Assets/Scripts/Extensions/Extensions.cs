using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskExtensions
{
    public static bool Includes(this LayerMask layerMask, int layer)
    {
        return layerMask == (layerMask.value | (1 << layer));
    }
}
