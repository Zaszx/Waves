using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Kazik,
    Kule,
    Semsiye,
    Oklava,
    Boru,

    Count,
}

public class Items
{
    public Dictionary<ItemType, Sprite> itemTypeToSpriteMap = new Dictionary<ItemType, Sprite>();
    public void Init()
    {
        itemTypeToSpriteMap[ItemType.Kazik] = Resources.Load<Sprite>("Textures/kazik");
        itemTypeToSpriteMap[ItemType.Kule] = Resources.Load<Sprite>("Textures/kazik");
        itemTypeToSpriteMap[ItemType.Semsiye] = Resources.Load<Sprite>("Textures/kazik");
        itemTypeToSpriteMap[ItemType.Oklava] = Resources.Load<Sprite>("Textures/kazik");
        itemTypeToSpriteMap[ItemType.Boru] = Resources.Load<Sprite>("Textures/kazik");
    }
}
