using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/equipment")]
public class EquipmentData : ItemData
{
    public enum ToolType
    {
        Pickaxe,hoe,axe,wateringCan
    }

    public ToolType toolType;
}
