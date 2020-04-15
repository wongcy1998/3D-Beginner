using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeduration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    bool m_IsPlayerAtExit;
    public CanvasGroup ExitBackgroundImageCanvasGroup;
    float m_Timer;

    void OnTriggerEnter (Collider other){
        if (other.gameObject == player) {
            m_IsPlayerAtExit = true;
        }
    }

    void Update() {
        if (m_IsPlayerAtExit){
            EndLevel();
        }
    }

    void EndLevel() {
        m_Timer += Time.deltaTime;
        ExitBackgroundImageCanvasGroup.alpha = m_Timer / fadeduration;

        if(m_Timer > fadeduration + displayImageDuration){
            Application.Quit();
        }
    }
}
