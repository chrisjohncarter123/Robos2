using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


class OptionsMenuBodyTrigger : EventTrigger, IPointerEnterHandler, IPointerExitHandler {


    public OptionsMenu optionsMenu;

    public void OnPointerEnter(PointerEventData eventData){

    }

    public void OnPointerExit(PointerEventData eventData){
        optionsMenu.HideMenu();

    }
       


    
}