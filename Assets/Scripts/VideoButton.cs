using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour {

    public AudioSource soundStep;
    public void OnMouseUpAsButton()
    {

        switch (gameObject.name)
        {
            case "notvideobut":
                Game.NotVideo = true;

                Step();
                break;

            case "videobut":
                Game.video = true;

                Step();
                break;


        }
    }
    public void Step()
    {
        soundStep.Play();
    }
}
