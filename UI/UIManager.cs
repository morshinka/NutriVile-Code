using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get; private set;}

    [Header("Inventory System")]
    [Header("Status Bar")]
    public Image toolEquipSlot;
    
    public GameObject inventoryPanel;

    public InventorySlot[] toolSlots;
    public HandInventorySlot toolHandSlot;

    public InventorySlot[] itemslots;
    public HandInventorySlot itemHandSlot;



    public Text itemName;
    public Text description;
    
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        RenderInventory();
        AssignSlotIndex();
    }

    public void AssignSlotIndex()
    {
        for(int i = 0; i < toolSlots.Length; i++)
        {
            toolSlots[i].AssignIndex(i);
            itemslots[i].AssignIndex(i);
        }
    }

    public void RenderInventory()
    {
        ItemData[] inventoryToolSlot = InventoryManager.Instance.tools;
        RenderInventoryPanel(inventoryToolSlot, toolSlots);

        ItemData[] inventoryItemSlot = InventoryManager.Instance.items;
        RenderInventoryPanel(inventoryItemSlot, itemslots);

        toolHandSlot.Display(InventoryManager.Instance.equippedTool);
        itemHandSlot.Display(InventoryManager.Instance.equippedItem);

        ItemData equippedTool = InventoryManager.Instance.equippedTool;

        if(equippedTool != null)
        {
            toolEquipSlot.sprite = equippedTool.thumbnail;
            toolEquipSlot.gameObject.SetActive(true);
            return;
        }

        toolEquipSlot.gameObject.SetActive(false);
    }

    public void RenderInventoryPanel(ItemData[] slots, InventorySlot[] uiSlot)
    {
        for(int i = 0; i < uiSlot.Length; i++)
        {
            uiSlot[i].Display(slots[i]);
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        RenderInventory();
    }

    public void DisplayItemInfo(ItemData item)
    {
        if(item == null)
        {
            itemName.text = "";
            description.text = "";
            return;
        }
        itemName.text = item.name;
        description.text = item.desciption;
    }

}
