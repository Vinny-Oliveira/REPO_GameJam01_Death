using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Static and constant variables for time and scale
    // Scales
    [SerializeField]
    public static float BOARD_SCALE = 0.5f; // Scaler for the size of the board
    [SerializeField]
    public static float TILE_SCALE = 5f; // Scaler for the size of the board tiles
    [SerializeField]
    public static float TWEEN_TILE_Y_SCALE = 0.5f;

    // Tween durations
    [SerializeField]
    public static float MOVE_DURATION = .5f;
    [SerializeField]
    public static float ROTATION_DURATION = 0.25f;
    [SerializeField]
    public static float TWEEN_EXPAND_DURATION = 0.55f;
    [SerializeField]
    public static float TWEEN_BOB_DURATION = 1f;

    // Limits for random number calculations
    [SerializeField]
    public static float RAND_WAIT_TIME_MIN = 0.5f;
    [SerializeField]
    public static float RAND_WAIT_TIME_MAX = 1.5f;
    [SerializeField]
    public static float RAND_TWEEN_SCALE_MIN = 4f;
    [SerializeField]
    public static float RAND_TWEEN_SCALE_MAX = 4.5f;
    [SerializeField]
    public static float RAND_TWEEN_TIME_MIN = 0.1f;
    [SerializeField]
    public static float RAND_TWEEN_TIME_MAX = 0.5f;

    // Radius of tile expantion after movement
    [SerializeField]
    public static float RADIUS_TILES = 3f;

    // Message box duration
    [SerializeField]
    private const float MESSAGE_TIME = 1.5f;

    #endregion

    // Booleans for game control
    public bool isMovable;
    public bool isGameOver;
    public bool isGamePaused;

    // Game counters
    private int intInnocentsKilled;

    // UI variables
    public GameObject gameOver_Pn;
    public TextMeshProUGUI txtNPCKilledMsg;
    //public TextMeshProUGUI txtNPCsKilledLabel;
    public TextMeshProUGUI txtNPCsKilledValue;
    
    #region LAZY_SINGLETON
    private static GameManager instance;

    public static GameManager GetInstance() {
        if (instance != null) {
            return instance;
        } else {
            return null;
        }
    }

    private void Awake() {

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private void Start()
    {
        isMovable = false;
        isGameOver = false;
        intInnocentsKilled = 0;
    }

    /// <summary>
    /// Tween to make game objects move in a certain direction
    /// </summary>
    /// <param name="inMovingObj"></param>
    /// <param name="inDirection"></param>
    /// <param name="inEase"></param>
    public void MovementTween(GameObject inMovingObj, Vector3 inDirection, Ease inEase)
    {
        isMovable = false; // Keep objects from moving while the tween is in progress
        Vector3 target = inMovingObj.transform.position + inDirection * TILE_SCALE * BOARD_SCALE;
        inMovingObj.transform.DOMove(target, MOVE_DURATION).SetEase(inEase).OnComplete(MakeObjectsMovable);
    }

    /// <summary>
    /// Allow the player to move again
    /// </summary>
    void MakeObjectsMovable() {
        isMovable = true;
    }

    /// <summary>
    /// After an NPC is killed, a feedback message appears for a few seconds
    /// </summary>
    /// <returns></returns>
    public IEnumerator DisplayNPCKilledMsg() {
        Debug.Log("You killed someone who was not supposed to die today!");
        intInnocentsKilled++;
        txtNPCKilledMsg.gameObject.SetActive(true);
        yield return new WaitForSeconds(MESSAGE_TIME);
        txtNPCKilledMsg.gameObject.SetActive(false);
    }

    /// <summary>
    /// Game over if the target is killed
    /// </summary>
    public void TriggerGameOver() {
        Time.timeScale = 0f;
        isGameOver = true;
        gameOver_Pn.SetActive(true);
        txtNPCsKilledValue.text = intInnocentsKilled.ToString();
    }

    #region PAUSE MANAGEMENT

    /// <summary>
    /// When the Pause key is pressed, check if the game is being paused or unpaused
    /// </summary>
    private void CheckPauseState() {
        isGamePaused = !isGamePaused;

        if (isGamePaused) {
            PauseGame();
        } else {
            UnpauseGame();
        }
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        //pausePanel.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame() {
        Time.timeScale = 1f;
        //pausePanel.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
        isGamePaused = false;
    }

    #endregion

    #region SCENE MANAGEMENT FUNCTIONS

    public void RestartLevel() {
        Time.timeScale = 1f;
        isGameOver = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //public void Survival_Level_1() {
    //    Time.timeScale = 1f;
    //    isInMainMenu = false;
    //    SceneManager.LoadScene(survLevel1.handle);
    //}

    //public void Collector_Level_1() {
    //    Time.timeScale = 1f;
    //    isInMainMenu = false;
    //    SceneManager.LoadScene(collectLevel1.handle);
    //}

    //public void LoadMainMenu() {
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene(mainMenu.handle);
    //}

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
    #endregion
}
