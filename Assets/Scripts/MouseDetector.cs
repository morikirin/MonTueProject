using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetector : MonoBehaviour
{

    private Ray mouseRay;

    private RaycastHit2D rayHit;

    public Vector2 GetPos()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        rayHit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, 10, -1);
        if (rayHit.collider)
            return rayHit.point;
        else
            return Vector2.zero;
    }
}
