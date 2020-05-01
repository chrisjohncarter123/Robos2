using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCube : MonoBehaviour
{

    public enum Side{
        Left,
        Right,
        Top,
        Bottom,
        Front,
        Back
    }
    public GameObject left, right, top, bottom, front, back;

    public void TryDestroySide(Side side){
        Debug.Log(side);
        switch (side){
            case Side.Back:
                if(back){
                    Destroy(back);
                    
                }
            break;
             case Side.Front:
                if(front){
                    Destroy(front);
                }
            break;
             case Side.Left:
                if(left){
                    Destroy(left);
                }
            break;
             case Side.Right:
                if(right){
                    Destroy(right);
                }
            break;
             case Side.Top:
                if(top){
                    Destroy(top);
                }
            break;
             case Side.Bottom:
                if(bottom){
                    Destroy(bottom);
                }
            break;

        }

    }
}