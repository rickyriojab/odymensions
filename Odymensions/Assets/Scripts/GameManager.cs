using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int TotalPoints { get { return totalPoints; } }
    //public Collider2D Collider { get; private set; }
    private int totalPoints;
    public HUDScript hud;
    public Timer timer;


    //vidas
    private int tries = 3;

    /*detectar jugador
    private bool playerHasEnter = false;
    public GameObject playerGameObject;
    */

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

    public void AwakeTime()
    {
        timer.AwakeTimer();
    }
    /*
  public IEnumerator ShowInstructions(string instructions)
  {
      instructionsText.text = instructions;
      yield return new WaitForSeconds(3.0f);
      instructionsText.text = string.Empty;
      yield return new WaitForSeconds(1.0f);
  }



  public void OnTriggerEnter2D(Collider2D collision)
  {
      Debug.Log("Estoy checando");
      if(collision.gameObject.tag == "Player")
      {
          playerGameObject = null;
          playerHasEnter = true;
      }
  }

  public bool GetPlayerHasEnter()
  {
      return playerHasEnter;
  }

  public GameObject GetPlayerGameObject() { return playerGameObject; }
  */
}
