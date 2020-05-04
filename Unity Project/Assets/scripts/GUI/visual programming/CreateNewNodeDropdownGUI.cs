using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateNewNodeDropdownGUI : EventTrigger
{

    public GameObject dropdownObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnPointerDown(PointerEventData eventData) {
        dropdownObject.GetComponent<Transform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        dropdownObject.SetActive(true);
    }

 
}
