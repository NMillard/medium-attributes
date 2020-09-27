using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Medium.Attributes.Main {
    public class UnitTest1 {
        [Fact]
        public void ReadColumnProperties() {
            var transaction = new Transaction("10203123", DateTime.Now, DateTime.Now.AddDays(1), 10, 0);

            var properties = typeof(Transaction).GetProperties()
                .Where(prop => prop.GetCustomAttribute<CsvInfoAttribute>() is {})
                .Select(prop => {
                    var columnInfo = prop.GetCustomAttribute<CsvInfoAttribute>();

                    return new {
                        columnInfo.ColumnName,
                        columnInfo.ColumnIndex,
                        Value = prop.GetValue(transaction)
                    };
                })
                .ToArray();
        }
    }
}