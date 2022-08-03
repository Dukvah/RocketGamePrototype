using System.Collections;
using System.Collections.Generic;
using RocketGame.Managers;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RocketGame.UIs
{
 
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _winMenu;
        [SerializeField] private GameObject _loseMenu;
        [SerializeField] private GameObject _inGameMenu;
        public void StartGameClicked(GameObject menu)
        {
            GameManager.Instance.StartGame(menu);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void WinGame()
        {
            StartCoroutine(WinGameAsync(true));
        }
        public void LoseGame()
        {
            StartCoroutine(WinGameAsync(false));
        }
        
        private IEnumerator WinGameAsync(bool didWin)
        {
            yield return new WaitForSeconds(1f);
            if (didWin)
            {
                _inGameMenu.SetActive(false);
                _winMenu.SetActive(true);
            }
            else
            {
                _inGameMenu.SetActive(false);
                _loseMenu.SetActive(true);
            }
            
        }
        
    }
   
}