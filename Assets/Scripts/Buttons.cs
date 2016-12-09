using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons : MonoBehaviour
{
    GameObject bank;

    void Start()
    {
        bank = GameObject.Find("Globals");
    }
    public void ButtonShop_Clicked()
    {
        SceneManager.LoadScene("Shop");
    }
    public void ButtonMainMenu_Clicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ButtonLevel1_Clicked()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ButtonLevel2_Clicked()
    {
        SceneManager.LoadScene("Level2");
    }
    public void ButtonLevel3_Clicked()
    {
        SceneManager.LoadScene("Level3");
    }
    public void ButtonTrophyRoom_Clicked()
    {
        SceneManager.LoadScene("TrophyRoom");
    }
    public void ButtonLevelSelect_Clicked()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void ButtonExit_Clicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
    public void ButtonBuyAmmo()
    {
        if (bank.GetComponent<Globals>().money >= 10)
        {
            bank.GetComponent<Globals>().money -= 10;
            bank.GetComponent<Globals>().bullets += 10;
        }
    }
}
