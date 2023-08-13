using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SeleccionarNivel : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void PrimerNivel()
    {
        SceneManager.LoadScene(1);
    }

    public void SegundoNivel()
    {
        SceneManager.LoadScene(2);
    }

    public void TercerNivel()
    {
        SceneManager.LoadScene(3);
    }
}
