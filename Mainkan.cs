using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainkan : MonoBehaviour
{
    public void ARProfesi()
    {
        SceneManager.LoadScene("ARKameraProfesi");
    }

    public void Kuis()
    {
        SceneManager.LoadScene("MulaiGame");
    }

    public void Kembali()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
