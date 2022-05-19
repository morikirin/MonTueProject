using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInteractiveHandler : MonoBehaviour
{
    public MouseInteractiveCtrller mouseInteractiveCtrl;

    private Ray mouseRay;
    private RaycastHit2D rayHit;

    private void OnMouseDown()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        rayHit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, 10, 1 << 18);
        mouseInteractiveCtrl.MoveAction(rayHit.point);
    }
}
