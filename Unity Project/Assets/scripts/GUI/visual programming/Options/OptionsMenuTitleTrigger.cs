using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsMenuTitleTrigger  : EventTrigger, IPointerDownHandler, IPointerExitHandler {

    OptionsMenu menu;

    
    PointerEventData.InputButton button = PointerEventData.InputButton.Left;
    bool isOpen = false;

    

    void Start() {
        menu = GetComponent<OptionsMenu>();
    }

    public void SetButton(PointerEventData.InputButton button){
        this.button = button;

    }

   
 
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == button) {
            menu.ShowMenuByMousePosition();

         }
    }
    public void OnPointerExit(PointerEventData eventData){

    }
}