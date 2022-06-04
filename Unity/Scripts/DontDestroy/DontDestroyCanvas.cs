using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour
{
    public HomeGallery galleryScript; 
    public Texture2D textureStay;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("HomePage");

        
        objs[0].GetComponent<DontDestroyCanvas>().FindGalleryScript();
          

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

   public void FindGalleryScript(){
       galleryScript = GameObject.FindGameObjectWithTag("GalleryScript").GetComponent<HomeGallery>();
       galleryScript.rawImage.texture = textureStay;
       galleryScript.DDP = this.gameObject;
   }
   
}
