using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemCategory
{
    food,
}
public class InteractiveItem : MonoBehaviour
{
    public InteractiveItemCtrller interactiveItemCtrl;
    private float canUseDistance = 2.5f;
    private Collider2D spottedCharacter;

    public Image actTimeBar;

    private bool isCountdown = false;
    private float actCompleTime = 5f;
    private float actCompleRemaing = 0f;

    private void Update()
    {
        ItemActCompleteTimer();
    }

    private void OnMouseDown()
    {
        if (characterDistanceDetect())
            interactiveItemCtrl.ItemActiveAction(this);
        else
            interactiveItemCtrl.GetCloserAction(this);
    }

    public void ItemAction()
    {
        if (!isCountdown)
        {
            isCountdown = true;
            actCompleRemaing = actCompleTime;
        }
    }

    private void ItemActCompleteTimer()
    {
        if (isCountdown)
        {
            actCompleRemaing -= Time.deltaTime;

            if (actCompleRemaing < 0.0f)
            {
                isCountdown = false;
                interactiveItemCtrl.GetItemAction(this);
                actTimeBar.fillAmount = 0f;
            }
            else
            {
                actTimeBar.fillAmount = actCompleRemaing / actCompleTime;
            }
        }
    }

    private bool characterDistanceDetect()
    {
        spottedCharacter = Physics2D.OverlapCircle(transform.position, canUseDistance, LayerMask.GetMask("Character"));

        if (spottedCharacter != null)
            return true;
        else
            return false;
    }
}
