using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    enum ItemType
    {
        Avatar,         // �ƹ�Ÿ ������
        Equipment,      // ��� ������
        Consume,        // �Һ� ������
        Material,       // ��� ������
        Quest,          // ����Ʈ ������
        
        Extra           // ��Ÿ ������
    }
    enum EquipSlot
    {
        // Weapon
        RightHand = 0,  // ������ (���ο���)
        LeftHand,       // �޼� (�������)
        
        // Armors
        TopArmor = 11,  // ����
        DownArmor,      // ����
        Head,           // �Ӹ�
        Face,           // ��(����)
        Gloves,         // �尩
        ArmGuard,       // �ȶ� (��Ʋ��)
        Shoes,          // �Ź�
        
        // Accessory
        Necklace = 21,  // �����
        EarRing,        // �Ͱ���
        
        Bracelet,       // ����
        Shoulder,       // �����ȣ��

        Rings1 = 31,
        Rings2,
        Rings3
    };

    // --- �������ͽ� â ���� ---
    bool isStatusWindowOpen = false;
    GameObject StatusUI;
    void StatusWindowToggle()
    {
        isStatusWindowOpen = !isStatusWindowOpen;
        StatusUI.SetActive(isStatusWindowOpen);
    }

    // --- �κ��丮 ���� ---
    bool isInventoryWindowOpen = false;
    GameObject InventoryUI;
    List<uint> InventoryByItemID;
    void InventoryWindowToggle()
    {
        isInventoryWindowOpen = !isInventoryWindowOpen;
        StatusUI.SetActive(isInventoryWindowOpen);
    }

    // --- ���â ���� ---
    bool isEquipWindowOpen = false;
    GameObject EquipmentUI;
    List<uint> EquipmentByItemID;
    void EquipmentWindowToggle()
    {
        isInventoryWindowOpen = !isInventoryWindowOpen;
        EquipmentUI.SetActive(isInventoryWindowOpen);
    }

    void Equipment(uint ID)
    {
        ItemType t = ItemType.Equipment; // t = FindItemByid(ID).type();
        if (t != ItemType.Equipment)
            return;
    }

    // Start is called before the first frame update
    void Start()
    {
        isStatusWindowOpen = false;
        StatusUI = GameObject.Find("Player Status");
        isInventoryWindowOpen = false;
        InventoryUI = GameObject.Find("Inventory");
        isEquipWindowOpen = false;
        EquipmentUI = GameObject.Find("Equipment");
    }

    // Update is called once per frame
    void Update()
    {      
        if (Input.GetKey(KeyCode.P))
        {
            StatusWindowToggle();
        }
        if (Input.GetKey(KeyCode.U))
        {
            EquipmentWindowToggle();
        }
        if (Input.GetKey(KeyCode.I))
        {
            InventoryWindowToggle();
        }
    }
}
