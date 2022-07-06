using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchFireButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField]
    private RectTransform _buttonHandler;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonFire1 = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonFire1Down = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonToKeyConverter.s_buttonFire1 = false;
        ButtonToKeyConverter.s_buttonFire1Down = false;
    }
}
