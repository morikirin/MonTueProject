using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItemCtrller : MonoBehaviour
{
    private CharacterController character;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    public void ItemActiveAction(InteractiveItem activeItem)
    {
        activeItem.ItemAction();
    }

    public void GetCloserAction(InteractiveItem activeItem)
    {

    }
    public void GetItemAction(InteractiveItem activeItem)
    {

    }
}
