using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;

    public string completeParagraph;

    public GameObject[] allLevels;

    public int levelCount;

    public static GameManager Instance
    {
        get
        {
            return gameManager;
        }
    }

    private void Awake()
    {
        if (gameManager && gameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameManager = this;
        }
    }


    public void AddStrings(string addition)
    {
        completeParagraph = completeParagraph + " " + addition;
        Debug.Log(completeParagraph);
    }

    public void NextLevelLoad()
    {
        levelCount++;
        if(levelCount <= allLevels.Length - 1)
        {
            Instantiate(allLevels[levelCount]);
        }
        else
        {
            
            //Load Main Menu
            Debug.Log("FINISH");
        }

        
    }

}
