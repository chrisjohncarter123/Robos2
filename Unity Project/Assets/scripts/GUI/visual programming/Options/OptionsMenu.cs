using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public Transform menuParent;
    public Transform optionsParent;
    public OptionsItem optionsItemBase;
    public bool hideOnMouseOut = false;
    public bool displayOnStart = false;
    public Vector3 mousePositionOffset = new Vector3(0,-10, 0);
    public float heightAdd;
    bool isOpen = false;
    int optionsCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        if(displayOnStart){
            ShowMenuAtCurrentPosition();
        }
        else{
            HideMenu();
        }
        
    }

    // Update is called once per frame
     void Update() {
    }

    public bool GetIsOpen(){
        return isOpen;
    }
    
    public OptionsItem AddOption(string title, UnityEngine.Events.UnityAction  action){

        OptionsItem newOption = AddOption(title);
        newOption.AddListener(action);
        return newOption;
    }
    public OptionsItem AddOption(string title){

        /*
        Vector2 size = GetComponent<RectTransform>().sizeDelta;
        size.y += heightAdd;
        GetComponent<RectTransform>().sizeDelta = size;
        */

        OptionsItem newOption = Instantiate(optionsItemBase.gameObject).GetComponent<OptionsItem>();
        newOption.transform.SetParent(optionsParent);
        /*
        newOption.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            0,
            -GetComponent<RectTransform>().sizeDelta.y + ((++optionsCount) * -heightAdd));
        */

        newOption.GetComponent<RectTransform>().sizeDelta = new Vector2(
            newOption.GetComponent<RectTransform>().sizeDelta.x,
            heightAdd
        );
        
        
        return newOption;
    }



    public void ToggleMenu(){
        if(isOpen){
            HideMenu();
        }else {
            ShowMenuAtCurrentPosition();
        }
    }

    public void ShowMenuAtCurrentPosition(){
        ShowMenu(menuParent.gameObject.GetComponent<Transform>().position);
    }

    public void ShowMenuByMousePosition(){
        ShowMenu(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) + mousePositionOffset);
    
    }

    public void ShowMenu(Vector2 position){
        menuParent.gameObject.GetComponent<Transform>().position = position;
        menuParent.gameObject.SetActive(true);
        isOpen = true;


    }
        public void HideMenu(){
        menuParent.gameObject.SetActive(false);
        isOpen = false;

    }

    public void MouseOut(){
        if(hideOnMouseOut){
            HideMenu();
        }
    }
}
