using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDapperApi.DML
{
    public class DMLGenerator
    {
        public static string CreateInsertStatement(object Entity, bool skipPrimaryKey = false)
        {
            var insertStatement = "";
            var sbProperties = new StringBuilder();
            var entityName = Entity.GetType().Name;
            var sbColumns = new StringBuilder();
            sbColumns.Append("INSERT INTO " + entityName + " (");
            sbProperties.Append(" VALUES (");
            var columnId = 0;
            foreach (var propertyInfo in Entity.GetType().GetProperties())
            {
                if (columnId != 0)
                {
                    sbColumns.Append(propertyInfo.Name + ",");
                    sbProperties.Append("@" + propertyInfo.Name + ",");
                }
                columnId++;
            }
            insertStatement = sbColumns.ToString().Substring(0, sbColumns.ToString().Length - 1) + ")" +
                sbProperties.ToString().Substring(0, sbProperties.ToString().Length - 1) + ")";
            return insertStatement;
        }
        public static string UpdateInsertStatement(object Entity, bool skipPrimaryKey = false)
        {
            var insertStatement = "";
            var sbProperties = new StringBuilder();
            var entityName = Entity.GetType().Name;
            var sbColumns = new StringBuilder();
            sbColumns.Append("INSERT INTO " + entityName + " (");
            sbProperties.Append(" VALUES (");
            var columnId = 0;
            foreach (var propertyInfo in Entity.GetType().GetProperties())
            {
                if (columnId != 0)
                {
                    sbColumns.Append(propertyInfo.Name + ",");
                    sbProperties.Append("@" + propertyInfo.Name + ",");
                }
                columnId++;
            }
            insertStatement = sbColumns.ToString().Substring(0, sbColumns.ToString().Length - 1) + ")" +
                sbProperties.ToString().Substring(0, sbProperties.ToString().Length - 1) + ")";
            return insertStatement;
        }
    }
}
