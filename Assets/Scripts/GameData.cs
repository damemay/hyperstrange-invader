using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/GameData")]
public class GameData : ScriptableObject
{
    public int playerHealthPoints;
    public int score;
    public bool won;
    public int enemyCount;
}
