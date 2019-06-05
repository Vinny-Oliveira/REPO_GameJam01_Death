using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_Manager : MonoBehaviour
{
    // Buttons to be reassigned
    public Button playGame_MainPanel_Btn;
    public Button quitGame_ExitPanel_Btn;

    // Start is called before the first frame update
    void Start()
    {
        // Reset control variables
        GameManager.GetInstance().isInMainMenu = true;
        GameManager.GetInstance().isGameOver = false;
        GameManager.GetInstance().isGamePaused = false;

        // Reassign buttons of the panels
        playGame_MainPanel_Btn.onClick.AddListener(GameManager.GetInstance().LoadLevel01);
        quitGame_ExitPanel_Btn.onClick.AddListener(GameManager.GetInstance().QuitGame);
    }
}
