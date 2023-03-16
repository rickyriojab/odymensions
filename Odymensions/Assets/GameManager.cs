using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int TotalPoints { get { return totalPoints; } }
    private int totalPoints;
    public HUDScript hud;

    public void AddPoints(int pointsToAdd)
    {
        totalPoints += pointsToAdd;
        Debug.Log(totalPoints);
        hud.UpdatePoints(totalPoints);
    }
}
