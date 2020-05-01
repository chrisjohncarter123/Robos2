using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnVariableGUIClickGUI : MonoBehaviour, IPointerClickHandler
{
    public ArgumentGUI argumentGUI;


    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        argumentGUI.PopulateVariableDropdowns();
    }
}
