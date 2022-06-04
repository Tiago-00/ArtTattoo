using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController3 : MonoBehaviour
{

    public static UiController3 Instance;

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

    public PopUp3 CreatePopUp3(){
        GameObject popUpGo = Instantiate(Resources.Load("UI/PopUp3") as GameObject);
        return popUpGo.GetComponent<PopUp3>();

    }


}
