using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSwitchButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonSwitchGunDown = true;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonSwitchGunDown = false;

    }
}
