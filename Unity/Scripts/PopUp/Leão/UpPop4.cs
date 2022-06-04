using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UpPop4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Action action = () => {
         void LoadByIndex (int sceneIndex) 
   {

        SceneManager.LoadScene (sceneIndex); // Renenber scene numbers start at 0, then 1,2,3 etc.
   }
    };

    Button button = GetComponent<Button>();
    button.onClick.AddListener(() => {
        PopUp4 popup = UiController4.Instance.CreatePopUp4();

        popup.Init(UiController4.Instance.MainCanvas,
        "Tem a certeza que pretende usar este grafismo?",
        "Sim",
        "Não",
        action
        );
    });

    }
    
}
