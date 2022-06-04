using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{

    public static UiController Instance;

    public Transform MainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null){
            GameObject.Destroy(this.gameObject);
            return; 
        }

        Instance = this;
    }

    public PopUp CreatePopUp(){
        GameObject popUpGo = Instantiate(Resources.Load("UI/PopUp") as GameObject);
        return popUpGo.GetComponent<PopUp>();

    }


}
