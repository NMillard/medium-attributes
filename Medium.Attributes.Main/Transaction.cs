using System;

namespace Medium.Attributes.Main {
    public class Transaction {
        public Transaction(
            string account,
            DateTime transactionDate,
            DateTime valueDate,
            double debitAmount,
            double creditAmount
        ) {
            Id = Guid.NewGuid();
            Account = account;
            TransactionDate = transactionDate;
            ValueDate = valueDate;
            DebitAmount = debitAmount;
            CreditAmount = creditAmount;
        }

        public Guid Id { get; }
        
        [CsvInfo("account", 0)]
        public string Account { get; }
        
        [CsvInfo("transaction_date", 1)]
        public DateTime TransactionDate { get; }
        
        [CsvInfo("value_date", 2)]
        public DateTime ValueDate { get; }
        
        [CsvInfo("debit", 3)]
        public double DebitAmount { get; }
        
        [CsvInfo("credit", 4)]
        public double CreditAmount { get; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CsvInfoAttribute : Attribute {
        private readonly ValueTransformationOption transformationOption;

        public CsvInfoAttribute(
            string columnName,
            int columnIndex,
            ValueTransformationOption transformationOption = ValueTransformationOption.NoTransformation
        ) {
            this.transformationOption = transformationOption;
            ColumnName = columnName;
            ColumnIndex = columnIndex;
        }

        public string ColumnName { get; }
        public int ColumnIndex { get; }
    }

    public enum ValueTransformationOption {
        NoTransformation,
        DateAsDDMMYYYY,
        SurroundWithQuotes,
    }
}