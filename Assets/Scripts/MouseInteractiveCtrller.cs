using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractiveCtrller : MonoBehaviour
{
    public CharacterCtrl character;


    public void ItemActiveAction(InteractiveItem activeItem)
    {
        activeItem.ItemAction();
    }

    public void StopItemActiveAction(InteractiveItem activeItem)
    {
        activeItem.StopItemInteract();
    }
    public void GetItemAction(InteractiveItem activeItem)
    {
        character.GetItem(activeItem.itemType);
        activeItem.ItemComplete();
    }

    public void GetCloserAction(InteractiveItem activeItem)
    {
        character.ItemMovingRequire(ClosePoint(activeItem));
    }
    

    public void MoveAction(Vector2 position)
    {
        character.MovingRequire(position);
    }


    private Vector2 ClosePoint(InteractiveItem activeItem)
    {
        Vector2 itemPosition = activeItem.transform.position;
        Vector2 characterPosition = character.transform.position;

        float allDistance = Vector2.Distance(itemPosition,characterPosition);
       
        float posX = (characterPosition.x - itemPosition.x) / allDistance + itemPosition.x;
        float posY = (characterPosition.y - itemPosition.y) / allDistance + itemPosition.y;

        return new Vector2(posX,posY);
    }
}
