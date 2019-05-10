using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Static and constant variables for time and scale
    [SerializeField]
    public static float SCALER = 2.5f; // Scaler for the size of the board tiles
    [SerializeField]
    public static float MOVE_DURATION = .5f;
    [SerializeField]
    public static float ROTATION_DURATION = 0.25f;
    [SerializeField]
    private const float MESSAGE_TIME = 1.5f;

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
        Vector3 target = inMovingObj.transform.position + inDirection * SCALER;
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
