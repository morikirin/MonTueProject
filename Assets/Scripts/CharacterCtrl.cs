using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCtrl : MonoBehaviour
{
    public MouseInteractiveCtrller mouseInteractiveCtrl;

    private Rigidbody2D rigidy;

    private bool movingSwitch;
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

    private void Moving()
    {
        if (!movingSwitch)
            return;
        rigidy.velocity = movingVector.normalized * movingSpd * Time.deltaTime;

        if (Vector2.Distance(Position2D(), movingTargetPos) < 0.1f)
        {
            movingSwitch = false;
            rigidy.velocity = Vector2.zero;
        }
    }

    public void GetItem(ItemType gotItemType)
    {
        switch (gotItemType)
        {
            case ItemType.food:
                foodQuantity += 1;
                foodQuantityText.text = ": "+ foodQuantity;
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
