using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    Camera camera;
    public Color color1, color2;
    public float duration = 3.0F;

    public bool pingPong = true;
    
    bool fogActive = true;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
        
    }

    public void SetColors(Color color1){
        this.color1 = color1;
        pingPong = false;
    }

    public void SetColors(Color color1, Color color2){
        this.color1 = color1;
        this.color2 = color2;
        pingPong = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(pingPong){
            float t = Mathf.PingPong(Time.time, duration) / duration;
            Color color = Color.Lerp(color1, color2, t);
            SetBackgroundAndFogColors(color);

        }
        else {
            SetBackgroundAndFogColors(color1);

        }
        
        
        
    }

    void SetBackgroundAndFogColors(Color color){
        //Set Camera
        camera.backgroundColor = color;

        //Set fog
        RenderSettings.fog = fogActive;
        RenderSettings.fogColor = color;

    }
}
