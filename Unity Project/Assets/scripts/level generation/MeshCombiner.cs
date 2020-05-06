// This script should be put on an empty GameObject
// Objects to be combined should be children of the empty GameObject
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
 
 public class MeshCombiner : MonoBehaviour {
     
    void Start () {
        

    }

    public void Combine() {
        foreach (Transform child in transform){
            child.position += transform.position;
        }
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        var index = 0;
        for (var i = 0; i < meshFilters.Length; i++)
        {
            if (meshFilters[i].sharedMesh == null) continue;
            combine[index].mesh = meshFilters[i].sharedMesh;
            combine[index++].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].GetComponent<Renderer>().enabled = false;
        }
        GetComponent<MeshFilter>().mesh = new Mesh();
        GetComponent<MeshFilter>().mesh.CombineMeshes (combine);
        GetComponent<Renderer>().material = meshFilters[0].GetComponent<Renderer>().material;
    }
 }