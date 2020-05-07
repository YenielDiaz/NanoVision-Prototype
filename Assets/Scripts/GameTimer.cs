using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10;
    bool timerFinished = false;
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        /* we divide the time since the level has loaded by
         the amount of time we want the level to have
         so that the slider value is proportional to how much time
         we want the level to last
         */
        slider.value = Time.timeSinceLevelLoad / levelTime;

        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            //FindObjectOfType<LevelController>().LevelTimerFinished();
            timerFinished = true;
        }
    }
}
