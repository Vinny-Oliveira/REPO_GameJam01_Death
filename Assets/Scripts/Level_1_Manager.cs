using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_1_Manager : MonoBehaviour
{
    // UI variables
    public GameObject pauseCanvasRef;
    public GameObject gameOverCanvasRef;
    public TextMeshProUGUI txtNPCKilledMsgRef;
    public TextMeshProUGUI txtNPCsKilledValueRef;
    public TextMeshProUGUI txtScoreInGameValueRef;

    // Collision detector
    public BoxCaster collisionCheckerRef;

    // Start is called before the first frame update
    void Start()
    {
        // Reset control booleans
        GameManager.GetInstance().isInMainMenu = false;
        GameManager.GetInstance().isGameOver = false;
        GameManager.GetInstance().isGamePaused = false;

        // Reassing references to the Game Manager
        GameManager.GetInstance().pauseCanvas = pauseCanvasRef;
        GameManager.GetInstance().gameOverCanvas = gameOverCanvasRef;
        GameManager.GetInstance().txtNPCKilledMsg = txtNPCKilledMsgRef;
        GameManager.GetInstance().txtNPCsKilledValue = txtNPCsKilledValueRef;
        GameManager.GetInstance().txtScoreInGameValue = txtScoreInGameValueRef;
        GameManager.GetInstance().collisionChecker = collisionCheckerRef;
    }
}
