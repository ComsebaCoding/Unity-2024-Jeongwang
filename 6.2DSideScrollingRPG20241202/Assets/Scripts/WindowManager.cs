using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    enum ItemType
    {
        Avatar,         // 아바타 아이템
        Equipment,      // 장비 아이템
        Consume,        // 소비 아이템
        Material,       // 재료 아이템
        Quest,          // 퀘스트 아이템
        
        Extra           // 기타 아이템
    }
    enum EquipSlot
    {
        // Weapon
        RightHand = 0,  // 오른손 (메인웨폰)
        LeftHand,       // 왼손 (서브웨폰)
        
        // Armors
        TopArmor = 11,  // 상의
        DownArmor,      // 하의
        Head,           // 머리
        Face,           // 얼굴(가면)
        Gloves,         // 장갑
        ArmGuard,       // 팔뚝 (건틀렛)
        Shoes,          // 신발
        
        // Accessory
        Necklace = 21,  // 목걸이
        EarRing,        // 귀걸이
        
        Bracelet,       // 팔찌
        Shoulder,       // 어깨보호대

        Rings1 = 31,
        Rings2,
        Rings3
    };

    // --- 스테이터스 창 관련 ---
    bool isStatusWindowOpen = false;
    GameObject StatusUI;
    void StatusWindowToggle()
    {
        isStatusWindowOpen = !isStatusWindowOpen;
        StatusUI.SetActive(isStatusWindowOpen);
    }

    // --- 인벤토리 관련 ---
    bool isInventoryWindowOpen = false;
    GameObject InventoryUI;
    List<uint> InventoryByItemID;
    void InventoryWindowToggle()
    {
        isInventoryWindowOpen = !isInventoryWindowOpen;
        StatusUI.SetActive(isInventoryWindowOpen);
    }

    // --- 장비창 관련 ---
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
