using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchReloadButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonReloadDown = true;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonReloadDown = false;

    }
}
