using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   public GameObject onlineOfflinePanel;
    private void Start()
    {
        onlineOfflinePanel.SetActive(false);
    }
    public void ShowGameModePanel()
    {
        onlineOfflinePanel.SetActive(true);
    }

    public void Garage()
    {
        SceneManager.LoadScene("Garage");
    }
    public void StartOfflineGame()
    {
        SceneManager.LoadScene("GamePlaySceneOffline");
    }

    public void ToTheLobby()
    {
        SceneManager.LoadScene("LoadingScene");
    }


}
