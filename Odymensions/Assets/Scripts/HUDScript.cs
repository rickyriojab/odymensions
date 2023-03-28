using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public static HUDScript Instance { get; private set; }
    public TextMeshProUGUI points;
    public TextMeshProUGUI instructionsText;
    public GameObject[] tries;

    private void Start()
    {
    }

    public void UpdatePoints(int totalPoints)
    {
        points.text = GameManager.Instance.TotalPoints.ToString();
    }

    public IEnumerator ShowInstructions(TextMeshProUGUI instructions)
    {
        instructionsText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        instructionsText.gameObject.SetActive(false);
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
