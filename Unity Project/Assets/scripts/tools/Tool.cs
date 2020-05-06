using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Tool : MonoBehaviour
{
    
    public string title;
    public string description;
    public LayerMask layerMask;
    public Camera camera;

    public bool useMainCamera = true;

    public Pointer pointer;

    public GameObject selectionCube;

    public GameObject previewCube;

    Transform previewTransform;
    Transform selectTransform;

    // Start is called before the first frame update
    void Start()
    {
        if(useMainCamera){
            camera = Camera.main;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(previewTransform && previewCube){
            previewCube.transform.position = previewTransform.position;
            previewCube.transform.eulerAngles = previewTransform.eulerAngles;

            previewCube.GetComponent<Renderer>().enabled = true;
        }
        else if (previewCube){
            previewCube.GetComponent<Renderer>().enabled = false;
        }

        if(selectTransform && selectionCube){
            selectionCube.transform.position = selectTransform.position;
            selectionCube.transform.eulerAngles = selectTransform.eulerAngles;
            selectionCube.GetComponent<Renderer>().enabled = true;
        }
        else if (selectionCube){
            selectionCube.GetComponent<Renderer>().enabled = false;
        }
    }

    public void SetTool(){
        pointer.SetTool(this);
    }
    public void UpdateCubes(Transform preview, Transform selection){
        UpdatePreviewCube(preview);
        UpdateSelectionCube(selection);
    }
    public void UpdateSelectionCube(Transform hit){
        selectTransform = hit;

    }
    public void UpdatePreviewCube(Transform hit){
        previewTransform = hit;

    }
}
