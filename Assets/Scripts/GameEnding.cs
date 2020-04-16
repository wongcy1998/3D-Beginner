﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeduration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    public CanvasGroup ExitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    float m_Timer;

    void OnTriggerEnter (Collider other){
        if (other.gameObject == player) {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer(){
        m_IsPlayerCaught = true;
    }

    void Update() {
        if (m_IsPlayerAtExit){
            EndLevel(ExitBackgroundImageCanvasGroup, false);
        }

        else if (m_IsPlayerCaught){
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart) {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeduration;

        if(m_Timer > fadeduration + displayImageDuration){
            if(doRestart){
                SceneManager.LoadScene(0);
        }

            else {
                Application.Quit();
            }
        }
    }
}
