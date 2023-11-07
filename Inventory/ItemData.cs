using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/item")]
public class ItemData : ScriptableObject
{
    public string desciption;
    public Sprite thumbnail;
    public GameObject gameModel;
}
