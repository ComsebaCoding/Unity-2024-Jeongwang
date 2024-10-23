using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    /*
    Awake�� ��� ������Ʈ�� �ʱ�ȭ �ǰ� ���� ȣ��
    �ٸ� ��ũ��Ʈ�� ������ ������ �� ����
    Start �Լ� ������ Scene�� ��� ������Ʈ�� �ѹ��� ȣ���
    ��ũ��Ʈ Ȱ��ȭ ���ο� ���� ����
    ��ũ��Ʈ ��ü�� �ʱ�ȭ�� ������ ȣ��
    */

    /*
    Awake() -> OnEnable() -> Start() ->
    FixedUpdate() -> OnTrigger~~~() -> OnCollision~~~() ->
    OnMouse~~~() -> Update() -> �ִϸ��̼� -> LateUpdate() ->
    �� ������ -> ����� ������ -> UI ������ -> OnDisable() ->
    OnDestroy()
    */
    // �����ũ -> enable üũ -> ��ŸƮ -> Ʈ���� -> �ø��� -> ������Ʈ -> �׸�
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

    // public Enemy MeteorPrefab;      // ������ ���׿� ������ ����
    public List<Enemy> enemySpawnList; // �� ���� ����Ʈ

    float MeteorSpawnTimer = 0.0f;  // ���׿� ���� ��Ÿ�� Ÿ�̸�
    public float MeteorSpawnCoolTime = 3.0f; // ���׿� ���� ��Ÿ�� ����

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
        // ���̽��ھ ������ �������� ������ 0 �����Ͷ�
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreLabel.text = HighScore.ToString("D4");
    }

    // Update is called once per frame
    void Update()
    {
        // MeteorSpawnCoolTime�ʸ��� �߽ɿ��� 12 �Ÿ� ���� ��ġ�� ���׿� ����
        MeteorSpawnTimer += Time.deltaTime;
        if (MeteorSpawnTimer >= MeteorSpawnCoolTime)
        {
            MeteorSpawnTimer -= MeteorSpawnCoolTime;
            
            Enemy enemyPrefab = enemySpawnList[Random.Range(0, enemySpawnList.Count)];
            Vector2 ins_Pos = Random.insideUnitCircle.normalized * 12.0f;

            // �����ϰ� ���õ� �� �������� ������ ��ġ�� ��ġ
            Instantiate(enemyPrefab, ins_Pos, Quaternion.identity);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public GameObject GameOverUI;   // ���� ���� UI
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