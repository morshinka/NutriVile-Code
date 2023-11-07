using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get; private set;}

    [Header("Inventory System")]
    public GameObject inventoryPanel;
    public InventorySlot[] toolSlots;
    public InventorySlot[] itemlots;

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
    }

    public void RenderInventory()
    {
        ItemData[] inventoryToolSlot = InventoryManager.Instance.tools;
        RenderInventoryPanel(inventoryToolSlot, toolSlots);

        ItemData[] inventoryItemSlot = InventoryManager.Instance.items;
        RenderInventoryPanel(inventoryItemSlot, itemlots);
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
