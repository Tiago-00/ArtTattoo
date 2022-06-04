using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PopUpAddImage : MonoBehaviour
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
        PopUpImageAdd1 popup = UiControllerAddImage.Instance.CreatePopUpAddImage();

        popup.Init(UiControllerAddImage.Instance.MainCanvas,
        "Escolha a sua Imagem",
        "Sim",
        "Não",
        action
        );
    });

    }
    
}
