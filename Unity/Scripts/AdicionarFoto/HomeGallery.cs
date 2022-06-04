using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeGallery : MonoBehaviour {

    public RawImage rawImage;
    public GameObject DDP;
    

	// Use this for initialization
	void Start () {
        rawImage.texture = DDP.GetComponent<DontDestroyCanvas>().textureStay;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            /*if (Input.mousePosition.x /0.5 > Screen.width / 2 && Input.mousePosition.y /0.5 > Screen.height / 2  )
            {
                // Don't attempt to pick media from Gallery/Photos if
                // another media pick operation is already in progress
                if (NativeGallery.IsMediaPickerBusy())
                    return;*/

                if (  Input.mousePosition.x  < Screen.width / 2 /*&& Input.mousePosition.y /0.5 < Screen.height / 2*/)
                {
                    // Pick a PNG image from Gallery/Photos
                    // If the selected image's width and/or height is greater than 512px, down-scale the image
                    PickImage(512);
                //}
            }
        }

    
    }

    private void PickImage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                // Assign texture to a temporary quad and destroy it after 5 seconds
                /*GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                quad.transform.forward = Camera.main.transform.forward;
                quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);*/

               rawImage.texture = texture;
                DDP.GetComponent<DontDestroyCanvas>().textureStay = texture;
            }
        });

        Debug.Log("Permission result: " + permission);
    }


}