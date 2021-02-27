using System.Collections;
using System.Collections.Generic;

namespace BoardGameBank.Data
{
    public class BGB_Player
    {
        public decimal Money { get; private set; } = 0;
        public List<TransactionRecord> TransactionRecords { get; private set; } = new List<TransactionRecord>();

        public BGB_Player(decimal money) => Money = money;
        public void AddTransaction(decimal moneyDifference,TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.Add:
                    Money += moneyDifference;
                    break;
                case TransactionType.Subtract:
                    Money -= moneyDifference;
                    break;
                case TransactionType.Multiply:
                    Money *= moneyDifference;
                    break;
                case TransactionType.Divide:
                    Money /= moneyDifference;
                    break;
                default:
                    break;
            }
            AddTransactionRecord(CreateTransactionRecord(moneyDifference, transactionType));
        }
        public void AddTransactionRecord(TransactionRecord transactionRecord)
        {
            TransactionRecords.Reverse();
            TransactionRecords.Add(transactionRecord);
            TransactionRecords.Reverse();

            if(TransactionRecords.Count > 5) 
            {
                while (TransactionRecords.Count > 5)
                {
                    TransactionRecords.RemoveAt(TransactionRecords.Count - 1);
                }
            }
        }
        public static TransactionRecord CreateTransactionRecord(decimal multiplier, TransactionType type) =>
            new TransactionRecord(multiplier,type);
    }
}