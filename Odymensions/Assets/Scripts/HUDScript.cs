using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public TextMeshProUGUI points;
    public GameObject[] lifes;

    public void UpdatePoints(int totalPoints)
    {
        points.text = GameManager.Instance.TotalPoints.ToString();
    }

    public void HideLife(int i)
    {
        lifes[i].SetActive(false);
    }

    public void ShowLife(int i)
    {
        lifes[i].SetActive(true);
    }
}
