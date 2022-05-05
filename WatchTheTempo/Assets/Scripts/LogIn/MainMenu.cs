using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI resultado;

    public InputField textoUsuario;
    public InputField textoPassword;

    // Start is called before the first frame update
    public void AbreURL()
    {
      Application.OpenURL("https://watchthetempo.games");
    }

    public void LeerTextoPlano()
    {
        print("Leer texto plano");
        StartCoroutine(DescargaDatosRed());
    }
    private IEnumerator DescargaDatosRed()
    {
        string usuario = textoUsuario.text;
        string password = textoPassword.text;

        WWWForm forma = new WWWForm();

        forma.AddField("username", usuario);
        forma.AddField("password", password);

        UnityWebRequest request = UnityWebRequest.Post("https://snowker.xyz/phpmyadmin/compareData.php", forma);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string textoPlano = request.downloadHandler.text;
            resultado.text = textoPlano;
            if (resultado.text == "Login successful")
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            resultado.text = "Error";
        }
    }
}
