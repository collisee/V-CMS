using System;
using System.Collections;
using System.Reflection;
using MySql.Data.Types;

namespace VietNamNet.Framework.Biz
{
    public class PacketUtils
    {
        public static void CreateTable(Packet p, string tableName, object obj)
        {
            if ((tableName == null) && (p.RawData.Tables.Count == 0))
            {
                p.RawData.Tables.Add();
                foreach (
                    PropertyInfo property in
                        obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))// | BindingFlags.DeclaredOnly))
                {
                    if (property.CanRead)
                    {
                        if (property.PropertyType.IsEnum)
                        {
                            p.RawData.Tables[0].Columns.Add(property.Name, Type.GetType("System.Int32"));
                        }
                        else if (property.PropertyType.FullName.Equals("System.Guid"))
                        {
                            p.RawData.Tables[0].Columns.Add(property.Name, typeof (string));
                        }
                        else
                        {
                            p.RawData.Tables[0].Columns.Add(property.Name, property.PropertyType);
                        }
                    }
                }
            }
            else if ((tableName != null) && (p.RawData.Tables[tableName] == null))
            {
                p.RawData.Tables.Add(tableName);
                foreach (
                    PropertyInfo info2 in
                        obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))// | BindingFlags.DeclaredOnly))
                {
                    if (info2.CanRead)
                    {
                        if (info2.PropertyType.IsEnum)
                        {
                            p.RawData.Tables[tableName].Columns.Add(info2.Name, Type.GetType("System.Int32"));
                        }
                        else if (info2.PropertyType.FullName.Equals("System.Guid"))
                        {
                            p.RawData.Tables[tableName].Columns.Add(info2.Name, typeof (string));
                        }
                        else
                        {
                            p.RawData.Tables[tableName].Columns.Add(info2.Name, info2.PropertyType);
                        }
                    }
                }
            }
        }

        public static int GetRowCount(Packet p)
        {
            if (p.RawData.Tables.Count == 0)
            {
                return 0;
            }
            return p.RawData.Tables[0].Rows.Count;
        }

        public static int GetRowCount(Packet p, string tableName)
        {
            if (tableName == null)
            {
                return GetRowCount(p);
            }
            if (p.RawData.Tables[tableName] == null)
            {
                return 0;
            }
            return p.RawData.Tables[tableName].Rows.Count;
        }

        public static void SingleObjectTranslator(Packet p, object item, string tableName)
        {
            CreateTable(p, tableName, item);
            PropertyInfo[] properties =
                item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);// | BindingFlags.DeclaredOnly);
            int rowCount = GetRowCount(p, tableName);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead)
                {
                    if (property.PropertyType.IsEnum)
                    {
                        p.SetData(tableName, property.Name, rowCount, (int) property.GetValue(item, null));
                    }
                    else
                    {
                        p.SetData(tableName, property.Name, rowCount,
                                  (property.GetValue(item, null) == null) ? DBNull.Value : property.GetValue(item, null));
                    }
                }
            }
        }

        public static Packet TranslateFrom(object obj)
        {
            return TranslateFrom(obj, null);
        }

        public static Packet TranslateFrom(object obj, string tableName)
        {
            if (obj == null)
            {
                return new Packet();
            }
            if (tableName == null)
            {
                tableName = obj.GetType().FullName;
            }

            Packet p = new Packet();
            p.Type = obj.GetType();
            SingleObjectTranslator(p, obj, tableName);
            return p;
        }

        public static object TranslateTo(Packet p)
        {
            if (p.Type == null)
            {
                throw new Exception("Type of Packet is null");
            }
            return TranslateTo(p, p.Type, null);
        }

        public static object TranslateTo(Packet p, string tableName)
        {
            if (p.Type == null)
            {
                throw new Exception("Packet.Type is not set");
            }
            return TranslateTo(p, p.Type, tableName);
        }

        public static object TranslateTo(Packet p, Type type)
        {
            return TranslateTo(p, type, null);
        }

        public static object TranslateTo(Packet p, Type type, string tableName)
        {
            int rowCount = GetRowCount(p, tableName);
            if (rowCount == 0)
            {
                return null;
            }
            PropertyInfo[] properties =
                type.GetProperties(BindingFlags.Public | BindingFlags.Instance);// | BindingFlags.DeclaredOnly);
            if (rowCount > 1)
            {
                ArrayList list = new ArrayList();
                for (int i = 0; i < rowCount; i++)
                {
                    object objItem = Activator.CreateInstance(type);
                    foreach (PropertyInfo info in properties)
                    {
                        object objData = p.GetData(tableName, info.Name, i);
                        if (info.CanWrite)
                        {
                            if (info.PropertyType.IsEnum)
                            {
                                info.SetValue(objItem, Enum.ToObject(info.PropertyType, int.Parse(objData.ToString())),
                                              null);
                            }
                            else if (objData != null && objData.GetType() == typeof (MySqlDateTime))
                            {
                                info.SetValue(objItem, ((MySqlDateTime) objData).Value, null);
                            }
                            else if (objData != null && objData.GetType() == typeof (uint))
                            {
                                info.SetValue(objItem, int.Parse(objData.ToString()), null);
                            }
                            else
                            {
                                info.SetValue(objItem, objData, null);
                            }
                        }
                    }
                    list.Add(objItem);
                }
                return list;
            }

            object objReturn = Activator.CreateInstance(type);
            foreach (PropertyInfo info2 in properties)
            {
                object objData = p.GetData(tableName, info2.Name);
                if (info2.CanWrite)
                {
                    if (info2.PropertyType.IsEnum)
                    {
                        info2.SetValue(objReturn, Enum.ToObject(info2.PropertyType, int.Parse(objData.ToString())), null);
                    }
                    else if (objData != null && objData.GetType() == typeof (MySqlDateTime))
                    {
                        info2.SetValue(objReturn, ((MySqlDateTime) objData).Value, null);
                    }
                    else if (objData != null && objData.GetType() == typeof (uint))
                    {
                        info2.SetValue(objReturn, int.Parse(objData.ToString()), null);
                    }
                    else
                    {
                        info2.SetValue(objReturn, objData, null);
                    }
                }
            }
            return objReturn;
        }
    }
}