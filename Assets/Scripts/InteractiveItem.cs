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
    public CharacterCtrl character;

    public Image actTimeBar;

    private float canUseDistance = 1f;

    private bool isCountdown = false;
    private float actCompleTime = 5f;
    private float actCompleRemaing = 0f;

    private void Update()
    {
        ItemActCompleteTimer();
    }



    private void OnMouseDown()
    {
        Debug.Log("???");
        ItemAction();
    }

    private void ItemAction()
    {
        if (characterDistanceDetect())
        {
            if (!isCountdown)
            {
                isCountdown = true;
                actCompleRemaing = actCompleTime;
            }
            else
            {
                Debug.Log("距離太遠");
            }
        }
        else
        {
            Debug.Log("距離太遠");
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
                character.GetItem();
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
        if (Vector2.Distance(transform.position, character.transform.position) < canUseDistance)
            return true;
        else
            return false;
    }
}
