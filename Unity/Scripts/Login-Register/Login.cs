using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    [SerializeField] private string authenticationEndpoint = "https://arttattoo.herokuapp.com/api/users/login";


    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    public Button loginButton;
    public Button goToRegisterButton;

    public void OnLoginClick()
    {
        alertText.text = "Signing in...";
        loginButton.interactable = false;

        StartCoroutine(TryLogin());
    }
    void Start()
    {
        //loginButton.onClick.AddListener(Principal);
        goToRegisterButton.onClick.AddListener(moveToRegister);
    }

   
 private  IEnumerator TryLogin()
  {

        string nome = usernameInputField.text;
        string password = passwordInputField.text;
        Debug.Log(nome);
        Debug.Log(password);

                WWWForm form = new WWWForm();
                form.AddField("nome", nome);
                form.AddField("password", password);

        UnityWebRequest request = UnityWebRequest.Post(authenticationEndpoint, form);
        yield return request.SendWebRequest();


        /*float startTime = 0.0f;
            while (!handler.isDone)
                {
                    startTime += Time.deltaTime;

                    if (startTime > 10.0f)
                    {
                        break;
                    }

                    yield return null;
                }*/

                Debug.Log(request.downloadHandler.text);
       
            if (request.result == UnityWebRequest.Result.Success)
            {
                if (request.downloadHandler.text != "Nome ou password incorreta")// Login success
                {
                    alertText.text = "Welcome ";
                    loginButton.interactable = false;
                    //Principal();
                }
                else
                {
                    alertText.text = "Invalid credentials ";
                    loginButton.interactable = true;
                }

            }
            else
            {
                alertText.text = "Error connecting";
                loginButton.interactable = true;
            }

            yield return null;
        
    }

    void moveToRegister()
    {
        SceneManager.LoadScene("AddUser");
    }

   /* void Principal()
    {
        SceneManager.LoadScene("Principal");
    }*/
}

