using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locallization : MonoBehaviour
{

    public AudioSource soundStep;
    public Sprite button1, button2, Ru, UK;
    public GameObject rus;
    public GameObject en;


     public static string logo = "ДЛЯ ПРОДОЛЖЕНИЯ  ПРОСМОТРИТЕ ВИДЕО";
    public static string logo2 = "ОСТАЛОСЬ ПОПЫТОК: ";
    public static bool Networkrus = false;
    public static string Start = "НАЖМИТЕ СТАРТ";
    public static string Pause = "ПАУЗА";
    public static string Gameover = "ПРОИГРАЛИ";




    void OnMouseUpAsButton ()
    {
        switch (gameObject.name)
        {
            case "Russia":
                Networkrus = true; 
                logo = "ДЛЯ ПРОДОЛЖЕНИЯ  ПРОСМОТРИТЕ ВИДЕО";
                logo2 = "ОСТАЛОСЬ ПОПЫТОК: ";
                Start = "НАЖМИТЕ СТАРТ";
                Pause = "ПАУЗА";
                Gameover = "ПРОИГРАЛИ";
                
                rus.GetComponent<SpriteRenderer>().sprite = button2;
                en.GetComponent<SpriteRenderer>().sprite = UK;

                Step();
                break;

            case "UK":
                Networkrus = false;
                logo = "TO CONTINUE VIEW THE VIDEO";
                logo2 = " REMAINING ATTEMPT: ";
                Start = "Press To Start";
                Pause = "PAUSE";
                Gameover = "GAME OVER";

                rus.GetComponent<SpriteRenderer>().sprite = Ru;
                en.GetComponent<SpriteRenderer>().sprite = button1;

                Step();
                break;

           
        }
    }

 
  


    public void Step()
    {
        soundStep.Play();
    }
}
