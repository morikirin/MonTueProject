using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    public MouseDetector mousePos;
    public float movingSpd;

    private Rigidbody2D rigidy;

    private bool movingSwitch;
    private Vector2 movingTargetPos;
    private Vector2 movingVector;


    private void Awake()
    {
        rigidy = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovingRequire();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void MovingRequire()
    {
        if (Input.GetMouseButton(0))
        {
            movingSwitch = true;
            movingTargetPos = mousePos.GetPos();
            movingVector = new Vector2(movingTargetPos.x - Position2D().x, movingTargetPos.y - Position2D().y);
        }
    }

    public void Moving()
    {
        if (!movingSwitch)
            return;
        rigidy.velocity = movingVector.normalized * movingSpd * Time.deltaTime;

        MovingArrived();
    }

    private void MovingArrived()
    {
        if(Vector2.Distance(Position2D(),movingTargetPos) < 0.1f) 
        {
            movingSwitch = false;
            rigidy.velocity = Vector2.zero;
        }
    }



    #region

    private Vector2 Position2D()
    {
        return new Vector2(this.transform.position.x, this.transform.position.y);
    }

    #endregion
}
