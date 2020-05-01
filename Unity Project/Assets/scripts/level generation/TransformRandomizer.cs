using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRandomizer : MonoBehaviour
{
    public Vector3 minPos, maxPos;
    public Vector3 minRot, maxRot;
    public Vector3 minScale, maxScale;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += Random(minPos, maxPos);
        transform.eulerAngles += Random(minRot, maxRot);

        foreach(Transform t in GetComponentsInChildren<Transform>()){
            t.localScale += Random(minScale, maxScale);
        }
        
    }

    public static Vector3 Random(Vector3 min, Vector3 max)
     {
         return new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
     }



    // Update is called once per frame
    void Update()
    {
        
    }
}
