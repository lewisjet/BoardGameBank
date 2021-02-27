using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoardGameBank.Data;

namespace BoardGameBank.Serialisation
{
    public static class BGB_SimpleSerialiser
    {
        public static void Save(BGB_SaveFile saveFile, string path) => XMLSerialiser.Serialise(saveFile, path);
        public static void Save(List<BGB_Player> players, string path) => XMLSerialiser.Serialise(PackagePlayers(players), path);
        public static BGB_SaveFile Load(string path) => XMLSerialiser.Deserialise<BGB_SaveFile>(path);
        public static BGB_SaveFile PackagePlayers(List<BGB_Player> players)
        {
            var playersArray = new PlayerData[players.Count];
            for (int i = 0; i < playersArray.Length; i++)
            {
                playersArray[i] =
                    new PlayerData { money = players[i].Money, transactionRecords = players[i].TransactionRecords.ToArray() };
            }
            return new BGB_SaveFile(playersArray);
        }
        public static List<BGB_Player> UnpackSaveFile(BGB_SaveFile saveFile)
        {
            var ret = new List<BGB_Player>();
            foreach (var item in saveFile.playerData)
            {
                var newPlayer = new BGB_Player(item.money);
                foreach (var record in item.transactionRecords)
                {
                    newPlayer.AddTransactionRecord(record);
                }
                ret.Add(newPlayer);
            }
            return ret;
        }
    }
}