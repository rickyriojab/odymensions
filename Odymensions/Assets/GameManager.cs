using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int TotalPoints { get { return totalPoints; } }
    private int totalPoints;
    public HUDScript hud;

    //vidas
    private int tries = 3;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("MORE THAN ONE GAME MANAGER ON SCENE!!!!");
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        totalPoints += pointsToAdd;
        //Debug.Log(totalPoints);
        hud.UpdatePoints(totalPoints);
    }

    public void RemoveTry()
    {
        tries -= 1;
        if (tries == 0) SceneManager.LoadScene(0);
        hud.HideTry(tries);
    }

    public void AddTry()
    {
        tries += 1;
        if (tries < 3)
        {
            hud.ShowTry(tries);
        }
        
    }
}
