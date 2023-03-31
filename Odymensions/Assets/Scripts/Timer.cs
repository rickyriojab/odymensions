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
    public string instructions;
    string text;
    public HUDScript hud;

    private void Awake()
    {
        hud.EmptyInstructions();
    }

    void Update()
    {
        if (isTimeAwake)
        {
            UpdateTimer();
        }
        else
        {
            actTime = maxTime;
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hud.ShowInstructions(instructions);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
