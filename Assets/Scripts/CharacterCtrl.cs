using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterCtrl : MonoBehaviour
{
    public MouseInteractiveCtrller mouseInteractiveCtrl;

    private Rigidbody2D rigidy;

    private bool movingSwitch;
    private bool isForItemMove;
    private Vector2 movingVector;

    [SerializeField]
    private float movingSpd;
    private Vector2 movingTargetPos;

    [Header("持有道具")]
    public TextMeshProUGUI foodQuantityText;
    public TextMeshProUGUI stoneQuantityText;
    private int foodQuantity = 0;
    private int stoneQuantity = 0;

    private void Awake()
    {
        rigidy = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        foodQuantityText.text = ": " + foodQuantity;
        stoneQuantityText.text = ": " + stoneQuantity;
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void MovingRequire(Vector2 position)
    {
        movingSwitch = true;
        movingTargetPos = position;
        movingVector = new Vector2(movingTargetPos.x - Position2D().x, movingTargetPos.y - Position2D().y);
    }
    public void ItemMovingRequire(Vector2 position)
    {
        isForItemMove = true;
        movingSwitch = true;
        movingTargetPos = position;
        movingVector = new Vector2(movingTargetPos.x - Position2D().x, movingTargetPos.y - Position2D().y);
    }

    private void Moving()
    {
        if (!movingSwitch)
            return;
        rigidy.velocity = movingVector.normalized * movingSpd * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - movingTargetPos.x) < 0.1f && Mathf.Abs(transform.position.y - movingTargetPos.y) < 0.1f)
        {
            movingSwitch = false;
            rigidy.velocity = Vector2.zero;
            if (isForItemMove)
            {
                isForItemMove = false;
                Collider2D reFindItem = Physics2D.OverlapCircle(transform.position, 1, 1 << 15);
                mouseInteractiveCtrl.ItemActiveAction(reFindItem.GetComponent<InteractiveItem>());
            }
        }
    }




    public void GetItem(ItemType gotItemType)
    {
        switch (gotItemType)
        {
            case ItemType.food:
                foodQuantity += 1;
                foodQuantityText.text = ": " + foodQuantity;
                break;
            case ItemType.stone:
                stoneQuantity += 1;
                stoneQuantityText.text = ": " + stoneQuantity;
                break;
        }
    }



    #region

    private Vector2 Position2D()
    {
        return new Vector2(this.transform.position.x, this.transform.position.y);
    }

    #endregion
}