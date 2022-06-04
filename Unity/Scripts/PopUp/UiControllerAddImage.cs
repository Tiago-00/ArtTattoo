using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControllerAddImage : MonoBehaviour
{

    public static UiControllerAddImage Instance;

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

    public PopUpImageAdd1 CreatePopUpAddImage(){
        GameObject popUpGo = Instantiate(Resources.Load("UI/Foto1") as GameObject);
        return popUpGo.GetComponent<PopUpImageAdd1>();

    }


}
