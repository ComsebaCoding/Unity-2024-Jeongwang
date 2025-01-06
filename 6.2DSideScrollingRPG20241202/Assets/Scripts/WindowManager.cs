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
        TopArmor = 11,       // 상의
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

    bool equipwindow = false;
    GameObject equipmentUI;
    List<uint> EquipmentByItemID;

    bool inventory = false;
    GameObject inventoryUI;
    List<uint> InventoryByItemID;

    void InventoryOpen()
    {
        inventoryUI.SetActive(true);
        // 인벤토리 id에 따라 이미지 오브젝트를 만들어 출력하자
    }
    void InventoryClose()
    {
        inventoryUI.SetActive(false);
    }
    
    void EquipmentOpen()
    {

    }

    void EquipmentClose()
    {

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.I))
        {
            if (inventory) InventoryOpen(); else InventoryClose();
        }
    }
}
