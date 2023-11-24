using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinachPassiveItem : PassiveItem
{
   protected override void ApplyModifier() {
    if (player != null) {
        player.currentMight *= 1 + passiveItemData.Multipler / 100f;
    } else {
        Debug.LogWarning("PlayerStats não encontrado!");
    }
}

}
