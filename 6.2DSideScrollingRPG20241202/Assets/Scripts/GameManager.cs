// C#�� ��� �������� �ҽ��ڵ��� �� ������ ���� �����ϴ�.
// #define CHEATMODE // ġƮ����� �̸��� �������Ѵ�.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� ����
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private GameObject player;

    private void Start()
    {
        // ������Ʈ �̸����� ����� ã�� Find �Լ�
        // �̸��� ���� ������Ʈ�� ������ ��� ���� ó�� �˻��� Object �ϳ����� ��ȯ
#if CHEATMODE
        player = GameObject.Find("Player");
#endif
        // �±׷� ã�� ���
        player = GameObject.FindWithTag("Player");
        // �±װ� ���� ������Ʈ�� ������ ��� ���� ó�� �˻��� Object �ϳ����� ��ȯ
        
        // ���� �±׸� ���� Object ���� �迭 ���·� ��ȯ
        //GameObject[] GOTaglist = GameObject.FindGameObjectsWithTag("Tag");

        // �� ������Ʈ�� ������ ������Ʈ �� ���� ó�� �˻��� �ϳ��� ������Ʈ�� ��ȯ
        // GameObject.FindObjectOfType<������Ʈ�̸�>();
        //PlayerControl plctrl = GameObject.FindObjectOfType<PlayerControl>();
        // ������Ʈ �迭 ���·� ��ȯ
        //PlayerControl[] pclist = GameObject.FindObjectsOfType<PlayerControl>();
        
        // Ȱ��ȭ�� ���� ������Ʈ�� �ڽ� ������Ʈ ã��
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
        UnityEditor.EditorApplication.isPlaying = false; // ������ ���� �÷��� ����
#elif CHEATMODE
        Debug.Log("ġƮ��尡 �����Ͱ� �ƴѵ� ������!");
#else
        Application.Quit(); // ���ø����̼� ����, ���� ��Ÿ��
#endif
    }
}
