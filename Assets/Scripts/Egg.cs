using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {
    public Game game;
    public int spawn;
    public GameObject[] egg;
    public int step = 0;
    public static float timer = 0.7f;

    void Start()
    {
        StartCoroutine(Steps());

    }

    void Update()
    {
        if ((step == 5) && (Game.playerPos == spawn))
        {
            egg[4].SetActive(false);
            game.Count();
            Destroy(this.gameObject);


        }
        if (Game.Resume == true)
        {
            StopAllCoroutines();
        }

    }

    IEnumerator Steps()
    {
        if (step == 0)
        {
            egg[step].SetActive(true);
        }
        else if (step == 10)
        {
            egg[9].SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            egg[step].SetActive(true);
            egg[step - 1].SetActive(false);
            if (step == 5)
            {
                game.Crash();
            }
            else game.Step();


        }
        step++;
        yield return new WaitForSeconds(timer);
        StartCoroutine(Steps());
    }
}
