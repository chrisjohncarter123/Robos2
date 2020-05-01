using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHelper
{
    
    public const int robotLayer = 8;
    public const int wiringShowLayer = 9;
    public const int ConnectionPointsLayer = 10;
    public const int ScreenLayer = 11;
    
    public static void SetLayerOfAllChildren(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }
       
        obj.layer = newLayer;
       
        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerOfAllChildren(child.gameObject, newLayer);
        }
    }

    public static void MoveSiblingIndex(Transform t, int move){
        int index = t.transform.GetSiblingIndex();

         t.SetSiblingIndex(index + move);

         /*

         if(index - move >= 0 && index + move < t.p().Length){
            

         }

         */
    }
}
