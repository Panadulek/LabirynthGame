using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] uint time;
    bool endGame;
    bool win;
    static bool mode;
    // Start is called before the first frame update
    void Start()
    {
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
}
