using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveUser : MonoBehaviour
{
    public static SaveUser Conta;
    public TMP_InputField inputField;

    public string nome;

    private void Awake(){

        if (Conta == null){

            Conta = this;
           DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

        public void SetNome(){
            nome=inputField.text;
            SceneManager.LoadSceneAsync("HomePage");

        }
    
    

       

}
