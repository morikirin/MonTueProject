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
    [SerializeField]
    [Range(0.1f,3)]
    private float canUseDistance = 1f;
    private Collider2D spottedCharacter;

    private bool isCountdown = false;
    [SerializeField]
    [Range(1f, 10)]
    private float actionCompleTime = 5f;
    private float actionCompleRemaing = 0f;

    public MouseInteractiveCtrller mouseInteractiveCtrl;
    public Image actTimeBar;
    public ItemType itemType;

    private void Update()
    {
        ItemActCompleteTimer();
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(0.6f,0.6f,1);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 1);
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
            actionCompleRemaing = actionCompleTime;
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
            actionCompleRemaing -= Time.deltaTime;

            if (actionCompleRemaing < 0.0f)
            {
                isCountdown = false;
                actTimeBar.fillAmount = 0f;
                mouseInteractiveCtrl.GetItemAction(this);
            }
            else
            {
                actTimeBar.fillAmount = actionCompleRemaing / actionCompleTime;
                if (!characterDistanceDetect())
                {
                    mouseInteractiveCtrl.StopItemActiveAction(this);
                }
            }
        }
    }

    public void StopItemInteract()
    {
        isCountdown = false;
        actTimeBar.fillAmount = 1f;
        actionCompleRemaing = 0f;
        actTimeBar.enabled = false;
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
