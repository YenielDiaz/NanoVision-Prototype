﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10;
    [SerializeField] float timeSinceGameStart;
    bool timerFinished = false;
    bool gameStarted = false;
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        //for testing purposes I just say I start the game when I press the K key
        if (Input.GetKeyDown(KeyCode.K) && !gameStarted)
        {
            gameStarted = true;
            //we store the time at which we started the game
            timeSinceGameStart = Time.timeSinceLevelLoad;
        }


        //when gameStarted is true then we start the timer
        if (gameStarted)
        {

            /* we divide the time since the game has started by
             the amount of time we want the level to have
             so that the slider value is proportional to how much time
             we want the level to last
            */
            slider.value = (Time.timeSinceLevelLoad - timeSinceGameStart) / levelTime;
        }

        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            //FindObjectOfType<LevelController>().LevelTimerFinished();
            timerFinished = true;
        }
    }
}
