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
        TopArmor = 11,       // ����
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

    bool equipwindow = false;
    GameObject equipmentUI;
    List<uint> EquipmentByItemID;

    bool inventory = false;
    GameObject inventoryUI;
    List<uint> InventoryByItemID;

    void InventoryOpen()
    {
        inventoryUI.SetActive(true);
        // �κ��丮 id�� ���� �̹��� ������Ʈ�� ����� �������
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
