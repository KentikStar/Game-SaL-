using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RayPlus
{
    public static Camera m_Camera;

    public static Ray getRay()
    {
        return m_Camera.ScreenPointToRay(Input.mousePosition);
    }
}
