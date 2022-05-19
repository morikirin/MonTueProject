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
    public void GetItemAction(InteractiveItem activeItem)
    {
        Debug.Log("Complete");
        character.GetItem(activeItem.itemType);
        activeItem.ItemComplete();
    }

    public void GetCloserAction(InteractiveItem activeItem)
    {

    }
    

    public void MoveAction(Vector2 position)
    {
        character.MovingRequire(position);
    }
}
