using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchJumpButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonJumpDown = true;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonJumpDown = false;

    }
}
