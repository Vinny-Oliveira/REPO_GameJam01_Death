using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level_1_Manager : MonoBehaviour
{
    // UI variables to be reassigned
    public GameObject pauseCanvasRef;
    public GameObject gameOverCanvasRef;
    public TextMeshProUGUI txtNPCKilledMsgRef;
    public TextMeshProUGUI txtNPCsKilledValueRef;
    public TextMeshProUGUI txtScoreInGameValueRef;

    // Collision detector to reassign
    public BoxCaster collisionCheckerRef;

    // Buttons to be reassigned
    public Button pauseBtn;
    public Button resumeBtn;
    public Button quitGamePausePanel_Btn;
    public Button backMainMenuPausePanel_Btn;
    public Button backMainMenuEndPanel_Btn;
    public Button restartLvBtn;
    public Button quitGameEndPanel_Btn;

    // Start is called before the first frame update
    void Start()
    {
        // Reset control variables
        GameManager.GetInstance().isInMainMenu = false;
        GameManager.GetInstance().isGameOver = false;
        GameManager.GetInstance().isGamePaused = false;
        GameManager.GetInstance().intInnocentsKilled = 0;

        // Reassing references to the Game Manager
        GameManager.GetInstance().pauseCanvas = pauseCanvasRef;
        GameManager.GetInstance().gameOverCanvas = gameOverCanvasRef;
        GameManager.GetInstance().txtNPCKilledMsg = txtNPCKilledMsgRef;
        GameManager.GetInstance().txtNPCsKilledValue = txtNPCsKilledValueRef;
        GameManager.GetInstance().txtScoreInGameValue = txtScoreInGameValueRef;
        GameManager.GetInstance().collisionChecker = collisionCheckerRef;

        // Reassign buttons of the panels
        pauseBtn.onClick.AddListener(GameManager.GetInstance().PauseGame);
        resumeBtn.onClick.AddListener(GameManager.GetInstance().UnpauseGame);
        quitGamePausePanel_Btn.onClick.AddListener(GameManager.GetInstance().QuitGame);
        backMainMenuPausePanel_Btn.onClick.AddListener(GameManager.GetInstance().LoadMainMenu);
        backMainMenuEndPanel_Btn.onClick.AddListener(GameManager.GetInstance().LoadMainMenu);
        restartLvBtn.onClick.AddListener(GameManager.GetInstance().RestartLevel);
        quitGameEndPanel_Btn.onClick.AddListener(GameManager.GetInstance().QuitGame);
    }
}
