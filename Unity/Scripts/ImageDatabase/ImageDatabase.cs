using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public static class ButtonExtension
{
	public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
	{
		button.onClick.AddListener (delegate() {
			OnClick (param);
		});
	}
}

public class ImageDatabase : MonoBehaviour
{
	

	

	[Serializable]
	public struct Images
	{
		public string image_nome;
		public Sprite Icon;
		public string image_url;
				
	}

	Images[] allImages;
	[SerializeField] Sprite defaultIcon;
	

	void Start ()
	{
		//fetch data from Json
		StartCoroutine (GetImages ());
		
	}

	void DrawUI ()
	{
		GameObject buttonTemplate = transform.GetChild (0).gameObject;
		GameObject g;

		int N = allImages.Length;
		 
      
		for (int i = 0; i < N; i++) {
			g = Instantiate (buttonTemplate, transform);
			g.transform.GetChild (0).GetComponent <Image> ().sprite = allImages [i].Icon;
			g.transform.GetChild (1).GetComponent <Text> ().text = allImages [i].image_nome;
			

			g.GetComponent <Button> ().AddEventListener (i, ItemClicked);
		}

		Destroy (buttonTemplate);
	}

	void ItemClicked (int itemIndex)
	{
		Debug.Log ("name " + allImages [itemIndex].image_nome);
			
	}
	

	IEnumerator GetImages ()
	{
		 string url = "http://localhost:3000/api/users/images";

		UnityWebRequest request = UnityWebRequest.Get(url);
		request.chunkedTransfer = false;
		yield return request.Send ();
		
			if (request.isDone) {
				allImages = JsonHelper.GetArray<Images> (request.downloadHandler.text);
				StartCoroutine (GetImagesIcones ());
			}

			print(allImages );
								
	}

	IEnumerator GetImagesIcones ()
	{

		
		for (int i = 0; i < allImages.Length; i++) {
			WWW w = new WWW (allImages [i].image_url);
			yield return w;
           
			if (w.error != null) {
				//error
				//show default image
				//allImages [i].Icon = defaultIcon;
			} else {
				if (w.isDone) {
					Texture2D tx = w.texture;
					allImages [i].Icon = Sprite.Create (tx, new Rect (0f, 0f, tx.width, tx.height), Vector2.zero, 10f);
				}

					//Debug.Log( allImages [i].image_nome);
					//Debug.Log( allImages [i].image_url);
						Debug.Log(allImages.Length);
			}
		}

		DrawUI ();	
	}

}
