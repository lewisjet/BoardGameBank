using System;
using System.Collections;
using System.Collections.Generic;

namespace BoardGameBank.Data
{
    [Serializable]
    public class BGB_SaveFile
    {
        public PlayerData[] playerData;
        public BGB_SaveFile(PlayerData[] playerData) => this.playerData = playerData;
    }

    [Serializable]
    public struct PlayerData
    {
        public decimal money;
        public TransactionRecord[] transactionRecords;
    }

    [Serializable]
    public struct TransactionRecord
    {
        public readonly decimal n;
        public readonly TransactionType transactionType;

        public TransactionRecord(decimal n, TransactionType type) => (this.n, transactionType) = (n, type);
    }

    public enum TransactionType
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}