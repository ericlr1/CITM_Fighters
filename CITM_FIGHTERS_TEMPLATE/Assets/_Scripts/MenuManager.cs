using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacters()
    {
        SceneManager.LoadScene("SelectCharacter");
    }
    public void GameSceneFiona_Finn()
    {
        SceneManager.LoadScene("GameLevel Finn_Fiona");
    }
    public void GameSceneMaga_Simon()
    {
        SceneManager.LoadScene("GameLevel Maga_Simon");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Applicattion.quit();
        #endif
    }
}
