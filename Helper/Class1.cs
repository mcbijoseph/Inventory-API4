﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace Helper
{
    public class ObjectToTable {
    }

    public class ObjectToTable<T> : DataTable
    {
        public ObjectToTable(T list) : base()
        {
            var properties = typeof(T).GetProperties();
            
            foreach (PropertyInfo info in properties)
            {
                this.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }


            object[] values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(list);
            }
            this.Rows.Add(values);
        }

        public ObjectToTable(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();
            
            foreach (PropertyInfo info in properties)
            {
                this.Columns.Add(new DataColumn(info.Name)); //, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    if (properties[i].PropertyType.IsGenericType && properties[i].PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        values[i] = null;
                    else
                        values[i] = properties[i].GetValue(entity);

                }

                this.Rows.Add(values);
            }
        }
    }
    public static class SqlTableParameter
    {

        public static SqlParameter DotnetPiperExtentionMethod<T>(string parName, T entity)
        {

            return new SqlParameter
            {
                SqlDbType = SqlDbType.Structured,
                ParameterName = parName,
                Value = new ObjectToTable<T>(entity),
                TypeName = "dbo.TypeName"
            };
        }

        public static SqlParameter DotnetPiperExtentionMethod<T>(string parName, IEnumerable<T> entity)
        {
            return new SqlParameter
            {
                SqlDbType = SqlDbType.Structured,
                ParameterName = parName,
                Value = new ObjectToTable<T>(entity),
                TypeName = "dbo.TypeName"
            };
        }
    }
}
