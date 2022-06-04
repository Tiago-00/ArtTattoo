using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController5 : MonoBehaviour
{

    public static UiController5 Instance;

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

    public PopUp5 CreatePopUp5(){
        GameObject popUpGo = Instantiate(Resources.Load("UI/PopUp5") as GameObject);
        return popUpGo.GetComponent<PopUp5>();

    }


}
