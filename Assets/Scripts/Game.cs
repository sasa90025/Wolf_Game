using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using AppodealAds.Unity.Api;
//using AppodealAds.Unity.Common;
using UnityEngine.Networking;

public class Game : MonoBehaviour

{
    public GameObject zero;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

   public GameObject hp1;
   public GameObject hp2;
   public GameObject hp3;

    public GameObject play;
    public GameObject pause ;
    public GameObject resume;
    //
    public GameObject Panel;
    //
    public AudioSource soundStep;
   public AudioSource soundCrash;
   public AudioSource soundCount;
   public static bool isPlaying = false;
   public TextMesh counter;
    // Текст на панели просмотра рекламы
    public Text TextNum;
    public Text TextPanel;
    public Text InternetError;
    // ТЕКСТ НАДПИСЕЙ

    public TextMesh Begin;
    public TextMesh End;
    public TextMesh Stoped;
/// <summary>
/// //
/// </summary>
    public GameObject GameOver;
    public GameObject PressToStart;
    public GameObject PauseS;
    // переменная для кнопкі старт, пауза і продолжіть
    public static bool push = false;
    public static bool Pause = false;
    public static bool Resume = false;

    public static int playerPos = 0;
    // Кол-во попыток просмотра рекламы
   // int num = 3;

    public static bool NotVideo = false;
    public static bool video = false;
    public bool consentValue = false;
    public string nointerneta = "";
  
  

  

    [HideInInspector]
    public Transform egg;

    [HideInInspector]
    public GameObject[] egg1;

    [HideInInspector]
    public GameObject[] egg2;

    [HideInInspector]
    public GameObject[] egg3;

    [HideInInspector]
    public GameObject[] egg4;

    public float time = 1.7f;
    public int count;
   
    public int hp=0;

    // переменные методов обратного вызова рекламы
    bool videoFinished = false;

    // Use this for initialization
    void Start()
    {
      

        //Appodeal.setRewardedVideoCallbacks(this);
       // string appKey = "8d0b6c9baed8f60b9ef0c8e181ba35c974c24f5ab7ae8768";
       //Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO, consentValue);
        
        egg = GameObject.Find("Spawn1").transform;
        egg1 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++)
            egg1[i] = egg.Find(i.ToString()).gameObject;

        egg = GameObject.Find("Spawn2").transform;
        egg2 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++)
            egg2[i] = egg.Find(i.ToString()).gameObject;

        egg = GameObject.Find("Spawn3").transform;
        egg3 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++)
            egg3[i] = egg.Find(i.ToString()).gameObject;


        egg = GameObject.Find("Spawn4").transform;
        egg4 = new GameObject[10];
        for (int i = 0; i < egg.childCount; i++)
            egg4[i] = egg.Find(i.ToString()).gameObject;



        foreach (GameObject eg in egg1)
            eg.SetActive(false);
        foreach (GameObject eg in egg2)
            eg.SetActive(false);
        foreach (GameObject eg in egg3)
            eg.SetActive(false);
        foreach (GameObject eg in egg4)
            eg.SetActive(false);

        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        pause.SetActive(false);
        resume.SetActive(false);
        GameOver.SetActive(false);
        Panel.SetActive(false);
        PauseS.SetActive(false);

        hp1.SetActive(false);
        hp2.SetActive(false);
        hp3.SetActive(false);

    }

    void Update()
    {
        // вставка надписей
        Begin.text = Locallization.Start;
        End.text = Locallization.Gameover;
        Stoped.text = Locallization.Pause;
        // проверка инернета
        Internet();


        if (push == true)
        {
            
            push = false;
            StartGame();


        }
        if (Pause == true)
        {
            Pause = false;
            Pauses();
        }
        if (Resume == true)
        {
            Resume = false;

            Resum();
        }

        if (videoFinished)
        {
            videoFinished = false;
            ResumAfteVideo();
        }

        if (isPlaying == true)
       {

            if (playerPos == 1)
            {
                player1.SetActive(true);
                player2.SetActive(false);
                player3.SetActive(false);
                player4.SetActive(false);

            }
            if (playerPos == 2)
            {
                player1.SetActive(false);
                player2.SetActive(false);
                player3.SetActive(true);
                player4.SetActive(false);


            }
            if (playerPos == 3)
            {
                player1.SetActive(false);
                player2.SetActive(true);
                player3.SetActive(false);
                player4.SetActive(false);

            }
            if (playerPos == 4)
            {
                player1.SetActive(false);
                player2.SetActive(false);
                player3.SetActive(false);
                player4.SetActive(true);

            }
            if (NotVideo ==true)
            {
                NotVideo = false;
                StopGame();

            }

            if (video == true)
            {
//InternetError.text = NotInternet;
                video = false;
               // Appodeal.show(Appodeal.REWARDED_VIDEO);
            }

        }

     
    }

    IEnumerator Timer()
    {
        GameObject egg = Instantiate(zero) as GameObject; ;
        Egg comp = egg.AddComponent<Egg>();
        comp.game = this;
        comp.spawn = Random.Range(1, 5);
        if (comp.spawn == 1)
            comp.egg = egg1;
        if (comp.spawn == 2)
            comp.egg = egg2;
        if (comp.spawn == 3)
            comp.egg = egg3;
        if (comp.spawn == 4)
            comp.egg = egg4;

        yield return new WaitForSeconds(time);
        StartCoroutine(Timer());

    }

   void Internet()
    {

      
      

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {

            nointerneta = "  ";

        }else

        {
            if (Locallization.Networkrus)
            {
                nointerneta = " НЕТ ПОДКЛЮЧЕНИ К СЕТИ ";
            } else
            {
                nointerneta = " NO NETWORK CONNECTION ";
            }

        }
       
     
       
       
       


    }

    public void StartGame()
    {
        PressToStart.SetActive(false);
        isPlaying = true;
        GameOver.SetActive(false);
        play.SetActive(false);
        pause.SetActive(true);
        playerPos = 1;
        
        player1.SetActive(true);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

       	count = 0;
       

        hp = 0;
        hp1.SetActive(false);
        hp2.SetActive(false);
        hp3.SetActive(false);

        


        StartCoroutine(Timer());
       
    }
    void Pauses()
    {
        pause.SetActive(false);
        resume.SetActive(true);
        PauseS.SetActive(true);
        playerPos = 0;
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        isPlaying = false;


        StopAllCoroutines();

        foreach (GameObject eg in egg1)
            eg.SetActive(false);
        foreach (GameObject eg in egg2)
            eg.SetActive(false);
        foreach (GameObject eg in egg3)
            eg.SetActive(false);
        foreach (GameObject eg in egg4)
            eg.SetActive(false);
        GameObject[] eggsArray = GameObject.FindGameObjectsWithTag("zero");
        foreach (GameObject eg in eggsArray)
            if (eg.name == "Zero(Clone)")
                Destroy(eg);

        //Appodeal.show(Appodeal.INTERSTITIAL);

    }
    void Resum()
    {
        playerPos = 1;
        pause.SetActive(true);
        PauseS.SetActive(false);
        resume.SetActive(false);
        Panel.SetActive(false);
        PressToStart.SetActive(false);
        StartCoroutine(Timer());
        isPlaying = true;
    }
   public  void StopGame()
    {

        
        isPlaying = false;
       hp = 0;
        count = 0;
        counter.text = count.ToString();

        play.SetActive(true);
      GameOver.SetActive(true);
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        pause.SetActive(false);
        Panel.SetActive(false);


        StopAllCoroutines();

        foreach (GameObject eg in egg1)
            eg.SetActive(false);
        foreach (GameObject eg in egg2)
            eg.SetActive(false);
        foreach (GameObject eg in egg3)
            eg.SetActive(false);
        foreach (GameObject eg in egg4)
            eg.SetActive(false);

       

        GameObject[] eggsArray = GameObject.FindGameObjectsWithTag("zero");
        foreach (GameObject eg in eggsArray)
            if (eg.name == "Zero(Clone)")
                Destroy(eg);


        



    }

    public void Step()
    {
        soundStep.Play();
    }

    public void Count()
    {
        count++;
         counter.text = count.ToString();
         soundCount.Play();
        if ((count % 50 == 0) && (count > 0))
        {
            Egg.timer -= 0.1f;
        }
    }
    public void Crash()
    {
        hp++;
        soundCrash.Play();
        if (hp >= 1)
        {
            hp1.SetActive(true);

        }
        if (hp >= 2)
        {
            hp2.SetActive(true);
        }
        if (hp >= 3)
        {
          //  if (num > 0)
           // {
                hp3.SetActive(true);
                playerPos = 0;
                player1.SetActive(false);
                player2.SetActive(false);
                player3.SetActive(false);
                player4.SetActive(false);

                Video();
           // } else
           // {
                StopGame();
           // }
        }
      
    }

public void Video ()
    {
        
        InternetError.text = nointerneta ;
        pause.SetActive(false);
        play.SetActive(false);
        Panel.SetActive(true);
        TextPanel.text =Locallization.logo;
        //TextNum.text= Locallization.logo2 + num.ToString();
        StopAllCoroutines();

      

      

        foreach (GameObject eg in egg1)
            eg.SetActive(false);
        foreach (GameObject eg in egg2)
            eg.SetActive(false);
        foreach (GameObject eg in egg3)
            eg.SetActive(false);
        foreach (GameObject eg in egg4)
            eg.SetActive(false);
        GameObject[] eggsArray = GameObject.FindGameObjectsWithTag("zero");
        foreach (GameObject eg in eggsArray)
            if (eg.name == "Zero(Clone)")
                Destroy(eg);

     
    }
 void ResumAfteVideo ()
    {
        pause.SetActive(false);
        resume.SetActive(true);
        Panel.SetActive(false);
        PressToStart.SetActive(true);

        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);

        hp = 0;
        hp1.SetActive(false);
        hp2.SetActive(false);
        hp3.SetActive(false);
        isPlaying = false;
        //num--;
       
    }

    public void onRewardedVideoLoaded(bool precache)
    {
       

        throw new System.NotImplementedException();
    }

    public void onRewardedVideoFailedToLoad()

    {
       
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoShown()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        videoFinished = true;
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoClosed(bool finished)
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoExpired()
    {
        throw new System.NotImplementedException();
    }

    public void onRewardedVideoClicked()
    {
        throw new System.NotImplementedException();
    }
}
