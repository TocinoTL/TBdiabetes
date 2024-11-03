using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Iniciar(string scena1)
    {
        SceneManager.LoadScene(scena1);
    }
    public void Salir()
    {
        Application.Quit();

    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
