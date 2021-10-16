using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum Keys : int
    {
        Red = 0,
        Green = 1,
        Gold = 2
    };

    public static GameManager gameManager;
    [SerializeField] uint time;
    bool endGame;
    bool win;
    static bool mode;
    int point;
    public  int[] keys; 
    // Start is called before the first frame update
    void Start()
    {
        keys = new int[3];
        for(int i = 0; i <= (int)Keys.Gold; i++)
        {
            keys[i] = 0;
        }
        point = 0;
        mode = true;
        endGame = false;
        win = false;
        if (gameManager == null)
        {
            gameManager = this;
        }
       
        /*fun(--i) a fun(i--)
         * 
         */
     
        time = 100;
        Debug.Log("Time:" + time + " s");
        InvokeRepeating("Stoper", 1, 1);
    }
    void Stoper()
    {
        time--;
        Debug.Log("Time:" + time + " s");
        if (time == 0)
        {
            endGame = true;
        }
        if(endGame)
        {
            EndGame();
        }
    }
    public void EndGame()
    {
        CancelInvoke("Stoper");
        if(win)
        {
            Debug.Log("win");
        }
        else
        {
            Debug.Log("lose");
        }

    }
    public void chaneStaus ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (mode)
            {
                Debug.Log("Pause Game");
                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("Resume Game");
                Time.timeScale = 1f;
                
            }
            mode = !mode;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        chaneStaus();
    }
    public void AddPoint(int point)
    {
        this.point += point;
        
    }
    public void Freez(int freez)
    {
        CancelInvoke("Stoper");
        InvokeRepeating("Stoper", freez, 1);
    }

}
