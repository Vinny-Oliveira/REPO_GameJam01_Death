using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Static and constant variables for time and scale
    // Scales
    [SerializeField]
    public static float MOVE_SCALE = 2.5f; // Scaler considering the size of the board and tiles

    // Tween durations
    [SerializeField]
    public static float MOVE_DURATION = .5f;
    [SerializeField]
    public static float ROTATION_DURATION = 0.25f;
    [SerializeField]
    public static float TWEEN_EXPAND_DURATION = 0.55f;
    [SerializeField]
    public static float TWEEN_BOB_DURATION = 1f;

    // Radius of tile expantion after movement
    [SerializeField]
    public static float RADIUS_TILES = 3f;

    // Message box duration
    [SerializeField]
    private const float MESSAGE_TIME = 1.5f;

    #endregion

    #region IN_GAME Variables
    // Booleans for game control
    public bool isMovable;
    public bool isGameOver;
    public bool isGamePaused;
    public bool isInMainMenu;

    // Game counters
    public int intInnocentsKilled;
    #endregion

    #region References for other objects
    // UI variables
    public GameObject pauseCanvas;
    public GameObject gameOverCanvas;
    public TextMeshProUGUI txtNPCKilledMsg;
    public TextMeshProUGUI txtNPCsKilledValue;
    public TextMeshProUGUI txtScoreInGameValue;

    // Collision detector
    public BoxCaster collisionChecker;

    #endregion

    #region SCENES
    public Scene mainMenu;
    public Scene Level_1;

    #endregion

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isInMainMenu && !isGameOver) {
            CheckPauseState();
        }
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
        Vector3 target = inMovingObj.transform.position + inDirection * MOVE_SCALE;
        inMovingObj.transform.DOMove(target, MOVE_DURATION).SetEase(inEase).OnComplete(MakeObjectsMovable);
    }

    /// <summary>
    /// Check if the player is close to obstacles and allow them to move again in the possible directions
    /// </summary>
    void MakeObjectsMovable() {
        collisionChecker.CheckForObstacles();
        isMovable = true;
    }

    /// <summary>
    /// After an NPC is killed, a feedback message appears for a few seconds
    /// </summary>
    /// <returns></returns>
    public IEnumerator DisplayNPCKilledMsg() {
        Debug.Log("You killed someone who was not supposed to die today!");
        intInnocentsKilled++;
        txtScoreInGameValue.text = intInnocentsKilled.ToString();
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
        gameOverCanvas.SetActive(true);
        txtNPCsKilledValue.text = intInnocentsKilled.ToString();
    }

    #region PAUSE MANAGEMENT

    /// <summary>
    /// When the Pause key is pressed, check if the game is being paused or unpaused
    /// </summary>
    public void CheckPauseState() {
        isGamePaused = !isGamePaused;

        if (isGamePaused) {
            PauseGame();
        } else {
            UnpauseGame();
        }
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        isGamePaused = true;
    }

    public void UnpauseGame() {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
        isGamePaused = false;
    }

    #endregion

    #region SCENE MANAGEMENT FUNCTIONS

    public void RestartLevel() {
        Time.timeScale = 1f;
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Survival_Level_1() {
        Time.timeScale = 1f;
        //isInMainMenu = false;
        SceneManager.LoadScene(Level_1.handle);
    }

    public void LoadMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu.handle);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
    #endregion
}
