using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelOptions;
    public Sprite[] spritesMute;
    public Button buttonMute;
    


    public void ButtonOptions()
    {
       
    }
    public void Keluar(){
        Application.Quit();
    }
    
    public void Tentang()
    {
        SceneManager.LoadScene("Tentang");
    }

    public void Mainkan()
    {
        SceneManager.LoadScene("Mainkan");
    }

    public void Bantuan()
    {
        SceneManager.LoadScene("Bantuan");
    }

    public void Unduh()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1xCF0aR2t7RBXDp9-ityPlsEptUy3T4eh?usp=sharing");
    }

    public void ButtonMute()
    {
        SoundManager.Instance.MuteSound();

        if (SoundManager.Instance.music.mute == true)
        {
            buttonMute.image.sprite = spritesMute[1];
        }
        else
        {

            buttonMute.image.sprite = spritesMute[0];
        }
    }
}
