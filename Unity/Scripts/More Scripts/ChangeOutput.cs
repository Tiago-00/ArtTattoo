using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ChangeOutput : MonoBehaviour
{

public ARTrackImages trackedImageScript;
public ARObjectPrefab[] outputs;
public GameObject prefab;
public Sprite sprite;


    // Start is called before the first frame update
    void Start()
    {
        //trackedImageScript.objectPrefabs[0].prefab = outputs[0];
        prefab.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
