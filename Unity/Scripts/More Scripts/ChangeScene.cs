using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   /*ARTrackImages arImages;
   
   void Start()
    {
          arImages = GameObject.FindGameObjectWithTag("Images").GetComponent<ARTrackImages >();
    }*/
   
   public void LoadByIndex (int sceneIndex) 
   {
        SceneManager. LoadScene (sceneIndex); // Renenber scene numbers start at 0, then 1,2,3 etc.
        //arImages.OnTrackedImagesChangedStart(arImages.EventArgs);
   }
    
}
