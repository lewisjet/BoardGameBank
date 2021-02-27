using BoardGameBank.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Core")]
public class BGBUnityCore : ScriptableObject
{
    public const string PATHEXTENTION = "/SaveFile.x1savefile";
    public List<BGB_Player> players;
    public BGB_Player currentPlayer;
}
