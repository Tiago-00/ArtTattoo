using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PopUpImageAdd1 : MonoBehaviour
{
    
    [SerializeField] Button button_1;
    [SerializeField] Button button_2;
    [SerializeField] TextMeshProUGUI buttontext_1;
    [SerializeField] TextMeshProUGUI buttontext_2;
    [SerializeField] TextMeshProUGUI popup_text;


    public void Init(Transform canvas, string popupMessage, string btn_1, string btn_2, Action action ){

        popup_text.text = popupMessage;
        buttontext_2.text = btn_2;
        buttontext_1.text = btn_1;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero;
        GetComponent<RectTransform>().offsetMax = Vector2.zero;

        button_2.onClick.AddListener(() => {
            GameObject.Destroy(this.gameObject);
        });

        button_1.onClick.AddListener(() => {
            action();
        });



    }
}
