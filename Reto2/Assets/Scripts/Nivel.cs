using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Nivel : MonoBehaviour
{
    public Text textoNivel;
    private void Start()
    {
        textoNivel.text = "Nivel: " + SceneManager.GetActiveScene().buildIndex;
    }
}
