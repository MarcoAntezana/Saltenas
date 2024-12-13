using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlEscenas : MonoBehaviour
{
    public void IrAEscena(string escenaNueva)
    {
        SceneManager.LoadScene(escenaNueva);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

