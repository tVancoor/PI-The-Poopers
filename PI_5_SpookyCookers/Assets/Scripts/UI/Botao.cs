using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour
{
    // Start is called before the first frame update
    public void CarregarJogo()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Update is called once per frame
    public void SairDoJogo()
    {
        Application.Quit();
    }
}
