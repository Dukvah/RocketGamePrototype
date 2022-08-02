using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RocketGame.Managers
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnGameOver;
        public event Action OnGameCompleted;
        public static GameManager Instance { get; private set; }
       
        private void Awake()
        {
            SingletonThisGameObject();
        }

        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
        }

        public void GameCompleted()
        {
            OnGameCompleted?.Invoke();
        }

        public void StartGame(GameObject menu)
        {
            menu.SetActive(false);
        }

        
    }
}

