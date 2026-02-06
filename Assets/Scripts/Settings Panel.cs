using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]GameObject settingMenu;
    
    public void PauseGame()
    {
        settingMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        settingMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
      
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1.0f;
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1.0f;
    }

    public void LevelFour()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1.0f;
    }

    public void LevelFive()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1.0f;
    }

    public void LevelSix()
    {
        SceneManager.LoadScene(7);
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void Levels()
    {
        SceneManager.LoadScene(1);
    }
}
