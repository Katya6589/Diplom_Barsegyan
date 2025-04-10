using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharterSkinInformation", menuName = "Shop/CharterSkinInformation")]

public class CharterSkinInformation : Information_shop
{
    [field: SerializeField] public CharterSkin SkinType { get; private set; }
}
