using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    /*
    Awake는 모든 오브젝트가 초기화 되고 나서 호출
    다른 스크립트와 연결을 보장할 수 있음
    Start 함수 이전에 Scene의 모든 컴포넌트에 한번씩 호출됨
    스크립트 활성화 여부와 관계 없이
    스크립트 개체가 초기화될 때에도 호출
    */

    /*
    Awake() -> OnEnable() -> Start() ->
    FixedUpdate() -> OnTrigger~~~() -> OnCollision~~~() ->
    OnMouse~~~() -> Update() -> 애니메이션 -> LateUpdate() ->
    씬 렌더링 -> 기즈모 렌더링 -> UI 렌더링 -> OnDisable() ->
    OnDestroy()
    */
    // 어웨이크 -> enable 체크 -> 스타트 -> 트리거 -> 컬리젼 -> 업데이트 -> 그림
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private AudioSource audioSource;
    public AudioClip LoseSound;
    public AudioClip ClickSound;
    public AudioClip CountSound;

    public Player player;

    // public Enemy MeteorPrefab;      // 생성할 메테오 프리팹 파일
    public List<Enemy> enemySpawnList; // 적 스폰 리스트

    float MeteorSpawnTimer = 0.0f;  // 메테오 생성 쿨타임 타이머
    public float MeteorSpawnCoolTime = 3.0f; // 메테오 생성 쿨타임 지정

    public static int Score;
    public Text ScoreLabel;
    public static int HighScore = 0;
    public Text HighScoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        GameOverUI.SetActive(false);
        Time.timeScale = 1.0f;
        Score = 0;
        // 하이스코어값 있으면 가져오고 없으면 0 가져와라
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreLabel.text = HighScore.ToString("D4");
    }

    // Update is called once per frame
    void Update()
    {
        // MeteorSpawnCoolTime초마다 중심에서 12 거리 랜덤 위치에 메테오 생성
        MeteorSpawnTimer += Time.deltaTime;
        if (MeteorSpawnTimer >= MeteorSpawnCoolTime)
        {
            MeteorSpawnTimer -= MeteorSpawnCoolTime;
            
            Enemy enemyPrefab = enemySpawnList[Random.Range(0, enemySpawnList.Count)];
            Vector2 ins_Pos = Random.insideUnitCircle.normalized * 12.0f;

            // 랜덤하게 선택된 적 프리팹을 지정한 위치에 설치
            Instantiate(enemyPrefab, ins_Pos, Quaternion.identity);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public GameObject GameOverUI;   // 게임 오버 UI
    public void GameOver()
    {
        audioSource.PlayOneShot(LoseSound);
        Time.timeScale = 0.0f;
        if (Score > HighScore)
            PlayerPrefs.SetInt("HighScore", Score);
        GameOverUI.SetActive(true);
    }

    // Getter
    public void PlayOneShot(AudioClip audioclip)
    {
        if (audioSource != null && audioclip != null)
            audioSource.PlayOneShot(audioclip);
    }
}