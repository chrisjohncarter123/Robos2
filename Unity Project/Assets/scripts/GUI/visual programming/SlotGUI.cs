using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotGUI : EventTrigger
{
    // Start is called before the first frame update
    LineGUI line;
    private bool dragging;
    RectTransform rectTransform;
    public NodePutGUI nodePutGUI;

    public GameObject nodePut;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        line = GetComponent<LineGUI>();
        nodePutGUI = GetComponent<NodePutGUI>();
        
    }

    public void Update() {
        if (dragging) {

            line.UpdateLine(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;

        line.CreateLine(
            new Vector2(rectTransform.rect.x, rectTransform.rect.y),
             nodePutGUI.GetLineWidth(), nodePutGUI.GetLineColor());
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;

        line.DestroyLine();
    }

    public override void OnPointerEnter(PointerEventData eventData){

    }
}
