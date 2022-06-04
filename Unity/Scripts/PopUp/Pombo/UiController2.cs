using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController2 : MonoBehaviour
{

    public static UiController2 Instance;

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

    public PopUp2 CreatePopUp2(){
        GameObject popUpGo = Instantiate(Resources.Load("UI/PopUp2") as GameObject);
        return popUpGo.GetComponent<PopUp2>();

    }


}
