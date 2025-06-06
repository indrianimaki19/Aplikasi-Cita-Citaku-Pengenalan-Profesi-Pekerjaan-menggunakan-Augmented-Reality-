using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MulaiGame : MonoBehaviour
{
   public void mulai ()
    {
        SceneManager.LoadScene("Kuis");
    }

    public void Kembali()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
