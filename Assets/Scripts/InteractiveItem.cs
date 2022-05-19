using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    food,
    stone,
}
public class InteractiveItem : MonoBehaviour
{
    private float canUseDistance = 1f;
    private Collider2D spottedCharacter;

    private bool isCountdown = false;
    private float actCompleTime = 5f;
    private float actCompleRemaing = 0f;

    public MouseInteractiveCtrller mouseInteractiveCtrl;
    public Image actTimeBar;
    public ItemType itemType;

    private void Update()
    {
        ItemActCompleteTimer();
    }

    private void OnMouseDown()
    {
        if (characterDistanceDetect())
            mouseInteractiveCtrl.ItemActiveAction(this);
        else
            mouseInteractiveCtrl.GetCloserAction(this);
    }

    public void ItemAction()
    {
        if (!isCountdown)
        {
            isCountdown = true;
            actCompleRemaing = actCompleTime;
            actTimeBar.enabled = true;
        }
    }

    public void ItemComplete()
    {
        Destroy(gameObject);
    }

    private void ItemActCompleteTimer()
    {
        if (isCountdown)
        {
            actCompleRemaing -= Time.deltaTime;

            if (actCompleRemaing < 0.0f)
            {
                isCountdown = false;
                actTimeBar.fillAmount = 0f;
                mouseInteractiveCtrl.GetItemAction(this);
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
