using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ARKameraProfesi : MonoBehaviour
{
    public int indexObjectActive;

    public GameObject buttonInformasi;
    public GameObject panelInformasi;
    public Image imageInformasi;
    public Sprite[] spriteInformasiObject;

    public GameObject penanda;

    

    [Header("audio")]
    public  AudioSource audioSourceDefault;
    public Button buttonVoiceOver;
    public Sprite spritePlay, spriteStop;
    public AudioClip[] audioClipsInformasi;





    void Start()
    {
        
    }

     void Update()
    {
        
    }

    void ChangeSpriteButtonVoiceOver()
    {
         buttonVoiceOver.image.sprite = spritePlay;
    }

    public void  ButtonVoiceOver()
    {
        if (audioSourceDefault.isPlaying == false)
        {
            audioSourceDefault.clip = audioClipsInformasi[indexObjectActive];

            audioSourceDefault.Play(); //play voice over
            buttonVoiceOver.image.sprite = spriteStop;

            Invoke("ChangeSpriteButtonVoiceOver", audioSourceDefault.clip.length);
        }
        else
        {
            audioSourceDefault.Stop(); //stop voice over

            buttonVoiceOver.image.sprite = spritePlay;

            CancelInvoke("ChangeSpriteButtonVoiceOver");
        }


    }

   

    public void ButtonInformasi()
    {
        if (panelInformasi.activeInHierarchy == false)
        {
            panelInformasi.SetActive(true);

            imageInformasi.sprite = spriteInformasiObject[indexObjectActive];
        }
        else
        {
            panelInformasi.SetActive(false);
        }
    }

    public void OnTargetFound(int indexObject)
    {
        indexObjectActive = indexObject;
        buttonInformasi.SetActive(true); // turn on button

        penanda.SetActive(false);
    }

    public void OnTargetLoss()
    {
        buttonInformasi.SetActive(false); //tutrn off button
        panelInformasi.SetActive(false); // turn off panel info

        penanda.SetActive(true);

        if (audioSourceDefault.isPlaying == true)
        {
            audioSourceDefault.Stop(); // stop audio
            buttonVoiceOver.image.sprite = spritePlay;
            CancelInvoke("ChangeSpriteButtonVoiceOver");

        }

        audioSourceDefault.clip = null;
    }

     public void Kembali()
    {
        SceneManager.LoadScene("Mainkan");
    }
}
