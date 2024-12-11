// C#의 모든 디파인은 소스코드의 맨 위에만 정의 가능하다.
// #define CHEATMODE // 치트모드라는 이름을 디파인한다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private GameObject player;

    private void Start()
    {
        // 오브젝트 이름으로 대상을 찾는 Find 함수
        // 이름이 같은 오브젝트가 여럿인 경우 가장 처음 검색된 Object 하나만을 반환
#if CHEATMODE
        player = GameObject.Find("Player");
#endif
        // 태그로 찾을 경우
        player = GameObject.FindWithTag("Player");
        // 태그가 같은 오브젝트가 여럿인 경우 가장 처음 검색된 Object 하나만을 반환
        
        // 같은 태그를 가진 Object 들을 배열 형태로 반환
        //GameObject[] GOTaglist = GameObject.FindGameObjectsWithTag("Tag");

        // 이 컴포넌트를 보유한 오브젝트 중 가장 처음 검색된 하나의 컴포넌트를 반환
        // GameObject.FindObjectOfType<컴포넌트이름>();
        //PlayerControl plctrl = GameObject.FindObjectOfType<PlayerControl>();
        // 컴포넌트 배열 형태로 반환
        //PlayerControl[] pclist = GameObject.FindObjectsOfType<PlayerControl>();
        
        // 활성화된 상위 오브젝트로 자식 오브젝트 찾기
        //GameObject childbyName = player.transform.Find("HideChild").gameObject;
        //GameObject childbyNumber = player.transform.GetChild(0).gameObject;
    }


    private void Update()
    {     
        if (Input.GetKeyDown("escape")) // if (Input.GetKey(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터 게임 플레이 정지
#elif CHEATMODE
        Debug.Log("치트모드가 에디터가 아닌데 켜졌다!");
#else
        Application.Quit(); // 어플리케이션 종료, 게임 런타임
#endif
    }
}
