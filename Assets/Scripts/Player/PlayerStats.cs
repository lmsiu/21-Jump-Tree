using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Lets it be created from the menu
[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStat/PlayerData")]
public class PlayerStats : ScriptableObject
{
    public int MAX_LIFE;
    public int currentLifeCount;

    public void resetLife(){
        currentLifeCount = MAX_LIFE;
    }
}
