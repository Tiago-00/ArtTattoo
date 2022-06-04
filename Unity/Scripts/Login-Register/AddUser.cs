using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Sockets;

public class AddUser : MonoBehaviour
{
    [SerializeField] private string authenticationEndpoint = "https://arttattoo.herokuapp.com/api/users/adduser";


    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button RegisterButton;
    public Button goToLoginButton;

    public void OnLoginClick()
    {
        alertText.text = "Signing in...";
        RegisterButton.interactable = false;

        StartCoroutine(TryLogin());
    }

    void Start()
    {
    
        goToLoginButton.onClick.AddListener(goToLoginTestScene);

    }
    

    private IEnumerator TryLogin()
    {

        string nome = usernameInputField.text;
        string email = emailInputField.text;
        string password = passwordInputField.text;

        WWWForm form = new WWWForm();
        form.AddField("use_nome", nome);
        form.AddField("use_email", email);
        form.AddField("use_pass", password);


        UnityWebRequest request = UnityWebRequest.Post(authenticationEndpoint, form);
        var handler = request.SendWebRequest();


        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }

            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.downloadHandler.text != "Nome ou password incorreta")// Login success
            {
                alertText.text = "Conta Criada ";
                RegisterButton.interactable = false;
                goToLoginTestScene();
            }
            else
            {
                alertText.text = "Tente de novo ";
                RegisterButton.interactable = true;
            }

        }
        else
        {
            alertText.text = "Error connecting";
            RegisterButton.interactable = true;
        }

        yield return null;
    }

    void goToLoginTestScene()
    {
        SceneManager.LoadScene("Login");
    }

}
