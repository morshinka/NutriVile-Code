using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    [Header("Tools")]
    public ItemData[] tools = new ItemData[8];
    public ItemData equippedTool = null;

    [Header("Items")]
    public ItemData[] items = new ItemData[8];
    public ItemData equippedItem = null; 

    public void InventoryToHand(int slotIndex, InventorySlot.InventoryType inventoryType)
    {
        if(inventoryType == InventorySlot.InventoryType.Item)
        {
            (equippedItem, items[slotIndex]) = (items[slotIndex], equippedItem);
        }
        else
        {
            (equippedTool, tools[slotIndex]) = (tools[slotIndex], equippedTool);
        }

        UIManager.Instance.RenderInventory();

    }

    public void HandToInventory(InventorySlot.InventoryType inventoryType)
    {
        if(inventoryType == InventorySlot.InventoryType.Item)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i] == null)
                {
                    items[i] = equippedItem;
                    equippedItem = null;
                    break;
                }
            }
        }else{
            for(int i = 0; i < tools.Length; i++)
            {
                if(tools[i] == null)
                {
                    tools[i] = equippedTool;
                    equippedTool = null;
                    break;
                }
            }
        }
        UIManager.Instance.RenderInventory();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
