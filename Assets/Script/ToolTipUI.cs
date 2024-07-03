using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ToolTipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ToolTipPopUp tooltipPopup;
    [SerializeField] private Item item;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipPopup.DisplayInfo(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPopup.HideInfo();
    }
}
