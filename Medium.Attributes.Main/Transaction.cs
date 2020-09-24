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
            Account = account;
            TransactionDate = transactionDate;
            ValueDate = valueDate;
            DebitAmount = debitAmount;
            CreditAmount = creditAmount;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        
        [CsvStorage("account", 4)]
        public string Account { get; }
        
        [CsvStorage("transaction_date", 4)]
        public DateTime TransactionDate { get; }
        
        [CsvStorage("value_date", 4)]
        public DateTime ValueDate { get; }
        
        [CsvStorage("debit", 4)]
        public double DebitAmount { get; }
        
        [CsvStorage("credit", 4)]
        public double CreditAmount { get; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CsvStorageAttribute : Attribute {
        private readonly ValueTransformationOption transformationOption;

        public CsvStorageAttribute(
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