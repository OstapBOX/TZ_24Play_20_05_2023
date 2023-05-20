using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerCls;

    [SerializeField] private float roadSpeed;

    private int wallWidth = 5;
    private int maxWallHeight = 5;

    private GameState gameState = GameState.StartGame;
    private GameObject roadNull;    

    private void Start() {
        Application.targetFrameRate = 60;
        gameManagerCls = this;
        roadNull = GameObject.Find("RoadNull");
    }

    private void Update() {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && GetGameState() == GameState.StartGame) {             
            StartGame();
        }

        if(GetGameState() == GameState.PlayGame) {
            MoveRoad();
        }

    }

    private void StartGame() {
        SetGameState(GameState.PlayGame);
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
}
