using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loaduser : MonoBehaviour
{
   public TextMeshProUGUI display_nome;

   public void Awake(){
       display_nome.text= SaveUser.Conta.nome;
   }

   public void Reset(){
       display_nome.text="";
   }
}
