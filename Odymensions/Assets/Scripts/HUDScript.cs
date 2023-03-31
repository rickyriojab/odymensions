using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public GameObject[] tries;
    public TextMeshProUGUI points;
    public TextMeshProUGUI instructionsText;

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

    public void EmptyInstructions()
    { 
        instructionsText.text = string.Empty;
    }

    public void ShowInstructions(string instructions)
    {
        StartCoroutine(CR_ShowInstructions(instructions));
    }

    public IEnumerator CR_ShowInstructions(string instructions)
    {
        instructionsText.text = instructions;
        yield return new WaitForSeconds(3.0f);
        instructionsText.text = string.Empty;
        yield return new WaitForSeconds(1.0f);
        GameManager.Instance.AwakeTime();
    }

}
