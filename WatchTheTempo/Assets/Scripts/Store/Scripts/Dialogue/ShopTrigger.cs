using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopTrigger : MonoBehaviour
{
   public void Shop()
    {
        //cargar la escena de la tienda
        SceneManager.LoadScene("Tienda2");
    }
    public void Store()
    {
        //cargar escena fuera de tienda
        SceneManager.LoadScene("Tienda1");
    }
    public void nextLevel()
    {
        SceneManager.LoadScene("2nd Level");
    }
}
