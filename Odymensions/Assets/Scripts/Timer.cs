using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;

public class Timer : MonoBehaviour
{
    //contador
    public float maxTime;
    private float actTime;
    private bool isTimeAwake = false;
    [SerializeField] private Slider slider;
    //texto
    public TextMeshProUGUI instructions;

    // Start is called before the first frame update
    void Start()
    {
        CR_PointsChallenge();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeAwake)
        {
            UpdateTimer();
        }
        
    }

    public void UpdateTimer()
    {
        //Debug.Log(actTime);
        actTime -= Time.deltaTime;

        if (actTime >= 0)
        {
            slider.value = actTime;
        }

        if (actTime <= 0)
        {
            Debug.Log("Se acabo el tiempo");
            ChangeTimer(false);
            PointsChallenge();
        }
    }

    public void ChangeTimer(bool state)
    {
        isTimeAwake = state;
    }

    public void AwakeTimer()
    {
        actTime = maxTime;
        slider.maxValue = maxTime;
        ChangeTimer(true);
    }
    public void KillTimer()
    {
        ChangeTimer(false);
    }

    public void PointsChallenge()
    {
        if (GameManager.Instance.TotalPoints >= 4)
        {
            return;
        }
        else if (GameManager.Instance.TotalPoints < 4)
        {
            GameManager.Instance.RemoveTry();
        }
    }

    public IEnumerator CR_PointsChallenge()
    {
        HUDScript.Instance.ShowInstructions(instructions);
        yield return new WaitForSeconds(1.0f);
        AwakeTimer();
    }
}
