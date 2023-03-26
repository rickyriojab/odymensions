using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public TextMeshProUGUI points;
    public GameObject[] tries;

    public void UpdatePoints(int totalPoints)
    {
        points.text = GameManager.Instance.TotalPoints.ToString();
    }

    public void HideTry(int i)
    {
        tries[i].SetActive(false);
    }

    public void ShowTry(int i)
    {
        tries[i].SetActive(true);
    }
}
