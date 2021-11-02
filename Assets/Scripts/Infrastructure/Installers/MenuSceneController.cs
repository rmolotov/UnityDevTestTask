using Menu.Models;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

namespace Infrastructure.Installers
{
    public class MenuSceneController
    {
        public int UserScore { get; set; }
        public GameObject cardPrefab;
        public MenuSceneController(int initUserScore)
        {
            UserScore = initUserScore;
        }

        public void LoadScene(string sceneName)
        {
            //SceneManager.LoadSceneAsync(sceneName);
            Debug.Log("loading scene " + sceneName);
        }
    }
}