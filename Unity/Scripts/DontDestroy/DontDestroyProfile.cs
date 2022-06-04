using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyProfile : MonoBehaviour
{

    public Gallery galleryScript; 
    public Texture2D textureStay;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Profile");

        
        objs[0].GetComponent<DontDestroyProfile>().FindGalleryScript();
          

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

   public void FindGalleryScript(){
       galleryScript = GameObject.FindGameObjectWithTag("GalleryScript").GetComponent<Gallery>();
       galleryScript.rawImage.texture = textureStay;
       galleryScript.DDP = this.gameObject;
   }
}
