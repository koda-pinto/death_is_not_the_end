using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void startGame()
    {
        SceneManager.LoadSceneAsync("Dev-scene");
    }

    public void StartOptions()
    {
        SceneManager.LoadSceneAsync("OptionsMenu");
    }

    public void StartTitlePage()
    {
        SceneManager.LoadSceneAsync("TitlePage");
    }

}
