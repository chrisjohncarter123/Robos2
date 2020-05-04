using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsMenuOpen  : MonoBehaviour, IPointerDownHandler, IPointerExitHandler {

    public OptionsMenu menu;

    void Update() {
        //if(Input)
    }
 
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("C");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("RC");
            menu.gameObject.SetActive(true);
            menu.gameObject.GetComponent<Transform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");

        menu.gameObject.SetActive(false);
    }
}