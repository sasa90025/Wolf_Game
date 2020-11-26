using UnityEngine;
using System.Collections;

public class www : MonoBehaviour {
	public AudioSource soundStep;
	public void OnMouseUpAsButton (){

		switch (gameObject.name) {
		case "up1":
			Game.playerPos=1;

			Step ();
			break;
		case "up2":
			Game.playerPos=2;
			Step ();

			break;

		case "up3":
			Game.playerPos=3;
			Step ();

			break;
		case "up4":
			Game.playerPos=4;
			Step ();

			break;
		case "play":
		Game.push=true;
			
			break;

		case "pause":
			Game.Pause=true;
			
			break;
		case "resume":
		Game.Resume=true;
			
		   break;
		}
	}
	public  void Step (){
		soundStep.Play ();
	}
}
