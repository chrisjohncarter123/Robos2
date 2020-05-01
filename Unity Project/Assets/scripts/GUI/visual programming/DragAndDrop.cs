using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : EventTrigger {


    [SerializeField]
    public GameObject draggedObject;


    bool dragParent = true;

    private bool dragging;
    Vector2 mouseStart;
    Vector2 posStart;

    void Start() {
        if(dragParent){
            draggedObject = transform.parent.gameObject;

        }
        else{
            draggedObject = gameObject;
        }
        
    }

    public void Update() {
        if (dragging) {
            Vector2 mouseDifference = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - mouseStart;
            draggedObject.transform.position = posStart + mouseDifference ;
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
        mouseStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        posStart = draggedObject.transform.position;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
    }
}

