using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Splashy
{
    
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;
        public GameObject winPanel, loosePanel;

        private void Awake()
        {
            if(Instance != null) Destroy(Instance);
            Instance = this;
        }

        private void Start()
        {
            Time.timeScale = 0;
        }
        public void StartGame()
        {
            Time.timeScale = 1;
        }

        private void StopGame()
        {
            Time.timeScale = 0;
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void QuitApp()
        {
            Application.Quit();
        }
        public void Lose()
        { 
            StopGame();
            loosePanel.SetActive(true);
        }

        public void Win()
        {
            winPanel.SetActive(true);
            StopGame();
        }
    }
}
