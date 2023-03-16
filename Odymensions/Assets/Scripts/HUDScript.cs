using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{

    public GameManager gameManager;
    public TextMeshProUGUI points;

    public void UpdatePoints(int totalPoints)
    {
        points.text = totalPoints.ToString();
    }
}
