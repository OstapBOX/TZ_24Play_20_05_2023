using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerCls;

    [SerializeField] private float roadSpeed;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private ParticleSystem warpEffect;
    [SerializeField] private ParticleSystem trail;

    private CinemachineTransposer transposer;
    private Vector3 gameCameraPosition = new Vector3(4.2f, 8.6f, -10.88f);
    private float smoothCameraMovement = 2f;

    private GameState gameState;
    private GameObject roadNull;
   

    private int wallWidth = 5;
    private int maxWallHeight = 5;

    private void Start() {
        Application.targetFrameRate = 60;
        gameManagerCls = this;
        roadNull = GameObject.Find("RoadNull");
        transposer = GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
        
    }

    private void Update() {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && GetGameState() == GameState.StartGame) {             
            StartGame();
        }

        if(GetGameState() == GameState.PlayGame) {
            MoveRoad();
            transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, gameCameraPosition, smoothCameraMovement * Time.deltaTime);
        }
    }

    private void StartGame() {
        SetGameState(GameState.PlayGame);
        startScreen.SetActive(false);
        restartButton.SetActive(true);
        warpEffect.Play();
        trail.Play();
    }

    public void GameOver() {
        SetGameState(GameState.GameOver);
        restartButton.SetActive(false);
        StartCoroutine(ShowGameOverScreen());
        warpEffect.Stop();
        trail.Pause();
    }

    private IEnumerator ShowGameOverScreen() {
        yield return new WaitForSeconds(1f);
        gameOverScreen.SetActive(true);
    }

    private void MoveRoad() {
        roadNull.transform.position -= new Vector3(0f, 0f, Time.deltaTime * roadSpeed);
    }

    public void SetGameState(GameState _gameState) {
        gameState = _gameState;
    }

    public GameState GetGameState() {
        return gameState;
    }

    public int GetWallWidth() {
        return wallWidth;
    }

    public int GetWallHeight() {
        return maxWallHeight;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
