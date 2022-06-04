using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController4 : MonoBehaviour
{

    public static UiController4 Instance;

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

    public PopUp4 CreatePopUp4(){
        GameObject popUpGo = Instantiate(Resources.Load("UI/PopUp4") as GameObject);
        return popUpGo.GetComponent<PopUp4>();

    }


}
