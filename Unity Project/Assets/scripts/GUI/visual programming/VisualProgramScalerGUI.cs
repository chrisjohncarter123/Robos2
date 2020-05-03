using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualProgramScalerGUI : MonoBehaviour
{

    public float scaleSpeed = 1;
    public float minScale = .75f, maxScale = 1.25f;
    static float currentScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 scale = gameObject.GetComponent<RectTransform>().localScale;
        float dt = Time.deltaTime;
        var d = Input.GetAxis("Mouse ScrollWheel");

        scale.x += d;
        scale.y += d;

        scale = scale * scaleSpeed;

        scale.x = Mathf.Clamp(scale.x, minScale, maxScale);
        scale.y = Mathf.Clamp(scale.y, minScale, maxScale);
        gameObject.GetComponent<RectTransform>().localScale = scale;
        currentScale = gameObject.GetComponent<RectTransform>().localScale.x;
        

        
    }

    public static float GetCurrentScale(){
        return currentScale;

    }
}
