using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlQuest : MonoBehaviour
{
    public void Kembali()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Kembaligame()
    {
        SceneManager.LoadScene("MulaiGame");
    }
    public AudioSfx audioSfx;
    [System.Serializable]
    public class Soals
    {
        [System.Serializable]
        public class ElementSoals
        {
            public Sprite spriteSoal; //gambar
            public Sprite[] spritesJawabans; 

            public int kunciJawaban; // kunci jawaban dalam int untuk array
        }

        public ElementSoals elementSoals;

    }

    public Soals[] soals;

    [Header("Random Index")]
    //Random Index
    public int[] indexRandomSoal;
    public int[] indexRandomJawaban;
    public int totalSoal; // total soal yang akan dipakai/
    public int urutanSoal; //0-1
    int jawabanBenar;


    [Header("UI soal dan jawaban")]
    public Image imageSoal;
    public Image[] imageJawabans;


    [Header("voice over")]
    public AudioSource audioSourceVO;
    public AudioClip[] audioClipVOs;
    public Button buttonPlayVO;

    [Header("score")]
    public Text textScore;
    public Text textScoreAkhir;
    public int increaseScore; //score yang di tambahkan
    public int decreaseScore;
    public int totalScoreAkhir;
    public GameObject panelEndGame;
   

    [Header("kondisi next soal")]
    public bool isJawabanHarusBenar;
    [Tooltip("hanya untuk debug")]
    public bool isJawabanBenar;

    [Header("sistem hasil jawaban atau jeda")]
    public bool isHasilJawab;
    public GameObject panelHasilJawab;
    public Image imageCharacterHasilJawab;
    public Sprite[] spriteCharacterHasilJawab; //0 benar 1 salah 
    int indexHasiljawab;
    public float waktuTungguHasilJawab;



    void Start()
    {
        GenerateIndexRandomSoal();
        GenerateindexRandomJawaban();

        GenerateSoal();
    }

    void Update()
    {
        
    }

    void DecreaseScore()
    {
        if (totalScoreAkhir - decreaseScore >= 0)
        {
            totalScoreAkhir -= decreaseScore;
        }
        else
        {
            Debug.Log("hasil negatif");

            totalScoreAkhir = 0;

        }

            textScore.text = totalScoreAkhir.ToString();

    }

    void IncreaseScore()
    {
        totalScoreAkhir += increaseScore; // menambah score
        textScore.text = totalScoreAkhir.ToString(); //score end game
    }

    void StopVoiceOver()
    {
        if (audioSourceVO.isPlaying == true)
        {
            audioSourceVO.Stop();
            buttonPlayVO.interactable = true;
            CancelInvoke();
        }
    }

    void ReactiveButtonVO()
    {
        buttonPlayVO.interactable = true; //mengaktifkan buttton vo
    }

    public void ButtonPlayVoiceOver()
    {
        if (audioSourceVO.isPlaying == false) //jika tidak main
        {
            audioSourceVO.clip = audioClipVOs[indexRandomSoal[urutanSoal]]; //set up audioclip vo
            audioSourceVO.Play();
            buttonPlayVO.interactable = false; //menonaktifkan button vo

            Invoke("ReactiveButtonVO", audioClipVOs[indexRandomSoal[urutanSoal]].length);
        }
    }

    public void ButtonJawabans(int indexJawaban)
    {
        if (indexRandomJawaban[indexJawaban] == jawabanBenar)
        {
            Debug.Log("benar");

            StopVoiceOver();

            IncreaseScore(); 

            isJawabanBenar = true; 

            indexHasiljawab = 0; // benar

            audioSfx.SoundSfxBenaar(); //sfx
        }
        else
        {
            Debug.Log("salah");

            DecreaseScore();

            indexHasiljawab = 1; //salah

            audioSfx.SoundSfxSalah(); //sfx
        }

        if (isJawabanHarusBenar == true)
        {
            if (isJawabanBenar == true)
            {
                if (isHasilJawab == false)
                {
                    GenerateNextSoal();
                }
                else //true
                {
                    HasilJawab();
                }
            }
        }
        else
        {
            if (isHasilJawab == false)
            {
              GenerateNextSoal();
            }
            else //true
            {
                HasilJawab();
            }
        }
    }

    void TutupHasilJawab()
    {
        panelHasilJawab.SetActive(false);

        GenerateNextSoal();
    }

    void HasilJawab()
    {
        panelHasilJawab.SetActive(true);

        //gambar
        imageCharacterHasilJawab.sprite = spriteCharacterHasilJawab[indexHasiljawab];

        Invoke("TutupHasilJawab", waktuTungguHasilJawab);
    }

    void GenerateNextSoal() //generate next soal setelah menjawab
    {
        if (urutanSoal < totalSoal - 1) //cek kondisi
            {
                urutanSoal +=1; //menambah urutan soal
                GenerateindexRandomJawaban(); //mengacar posisi jawaban lagi
                GenerateSoal(); 

                isJawabanBenar = false; //mengembalikan kondisi ini
            }
            else
            {
                Debug.Log("Finish Game");
                //panel end game
                panelEndGame.SetActive(true); // mengaktifkan panelnya
                textScoreAkhir.text = totalScoreAkhir.ToString(); //update text ui panel end game

                //sound finish
            }
    }

    void GenerateindexRandomJawaban()
    {
        indexRandomJawaban = new int[4]; //4=abcd 3=abc 2=ab
        for (int i = 0; i < indexRandomJawaban.Length; i++)
        {
            indexRandomJawaban[i] = i;
        }
        for (int i = 0; i < indexRandomJawaban.Length; i++)
        {
            int a = indexRandomJawaban[i];
            int b = Random.Range(0, indexRandomJawaban.Length);
            indexRandomJawaban[i] = indexRandomJawaban[b];
            indexRandomJawaban[b] = a;
        }
    }

    void GenerateIndexRandomSoal()
    {
        indexRandomSoal = new int[soals.Length]; //creat slot array
        for (int i = 0; i < indexRandomSoal.Length; i++) //fill slot array dengan int
        {
            indexRandomSoal[i] = i;
        }

        for (int i = 0; i < indexRandomSoal.Length; i++) // random index
        {
            int a = indexRandomSoal[i];
            int b = Random.Range(0, indexRandomSoal.Length);
            indexRandomSoal[i] = indexRandomSoal[b];
            indexRandomSoal[b] = a;
        }
    }

    void GenerateSoal()
    {
        //update soal
        imageSoal.sprite = soals[indexRandomSoal[urutanSoal]].elementSoals.spriteSoal; //soal image

        //update jawaban
        for (int i = 0; i < 4; i++) //4 karena abcd
        {
            imageJawabans[i].sprite = soals[indexRandomSoal[urutanSoal]].elementSoals.spritesJawabans[indexRandomJawaban[i]]; //jawaban image
        }

        // jawaban benar
        jawabanBenar = soals[indexRandomSoal[urutanSoal]].elementSoals.kunciJawaban; //mengambil kunci jawaban

        ButtonPlayVoiceOver();
    }
}
