using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

internal interface ISerializer
{
    void Read(BinReader reader);
    void Write(BinWriter writer);
}
public class BinSerializerManager
{
    /// <summary>
    /// 基本类型:
    /// </summary>
    public enum TypeD : int
    {
        Boolean, Char,
        SByte, Short, Int, Long,
        Byte, UShort, UInt, ULong,
        Float, Double, Decimal,
    }
    public enum LengthSize_e : Byte
    {
        Byte = 1, UShort = 2, UInt = 4, ULong = 8
    }
    public static Type[] TypeMapper =
    {
            typeof(bool),typeof(char),
            typeof(sbyte),typeof(short),typeof(int),typeof(long),
            typeof(byte),typeof(ushort),typeof(uint),typeof(ulong),
            typeof(float),typeof(double),typeof(decimal)
        };
    public static Dictionary<String, MethodInfo> WriteMethodInfos;
    public static Dictionary<String, MethodInfo> ReadMethodInfos;

    // 配置
    // 配置: 序列化字符串
    public static Encoding Encoding = Encoding.Unicode;  // 默认编码
    public static bool PreLength = false;  // 字符长度
    public static LengthSize_e PreLengthSize = LengthSize_e.UInt;  // 字符长度占用的字节数

    // 配置: 集合
    public static LengthSize_e PreCountSize = LengthSize_e.UInt;  // 集合长度占用的字节数。

    // 配置: 序列化字段
    public static bool IncludeFields = false;           // 包含字段
    public static bool IncludProperties = true;         // 包含属性
    public static bool IncludPeivateFields = true;      //包含私有字段
    public static bool IgnoreReadOnlyFields = true;     // 忽略只读字段
    public static bool IgnoreReadOnlyProperties = true; // 忽略只读属性
}
public class BinWriter : BinaryWriter
{
    #region 静态区
    public static Dictionary<String, MethodInfo> WriteMethodInfos;

    static BinWriter()
    {
        Type type = typeof(BinWriter);
        Type t;
        MethodInfo method;
        WriteMethodInfos = new Dictionary<String, MethodInfo>();
        // 添加 method;
        for (int i = 0; i < BinSerializerManager.TypeMapper.Length; i++)
        {
            t = BinSerializerManager.TypeMapper[i];
            method = type.GetMethod("Write", new Type[] { t });
            WriteMethodInfos.Add(t.Name, method);
        }
        // 注册 自定义字符串。
        t = typeof(String);
        method = type.GetMethod("Write", new Type[] { t });
        WriteMethodInfos.Add(t.Name, method);
        BinSerializerManager.WriteMethodInfos = WriteMethodInfos;
    }
    #endregion
    #region 构造函数
    private Encoding m_encoding;

    protected BinWriter() : base() { this.m_encoding = BinSerializerManager.Encoding; }
    public BinWriter(Stream output) : this(output, BinSerializerManager.Encoding) { }

    public BinWriter(Stream output, Encoding encoding) : this(output, encoding, false) { }

    public BinWriter(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen)
    {
        this.m_encoding = encoding;
    }
    #endregion


    // 默认 带长度前缀的编码。修改为顶长的编码
    public override void Write(String value)
    {
        byte[] bytes = m_encoding.GetBytes(value);
        Write(value.Length);
        Write(bytes, 0, bytes.Length);
    }
    private void Write(ICollection value)
    {
        if (value == null) return;
        // 获取子类型。
        Write(value.Count);
        foreach (var obj in value)
        {
            Write(obj);
        }
    }
    public void Write(Object obj)
    {
        if (obj == null) return;
        Type type = obj.GetType();// 类型
        Type sub;// 类型
        if (WriteMethodInfos.TryGetValue(type.Name, out MethodInfo method))
        {
            method.Invoke(this, new object[] { obj });
        }
        else
        {
            if (type.IsEnum)
            {
                sub = Enum.GetUnderlyingType(type);
                if (WriteMethodInfos.TryGetValue(sub.Name, out method))
                {
                    method.Invoke(this, new object[] { obj });
                }
                else
                {
                    throw new NotSupportedException("Enum非值类型，不支持只实例化：" + type.FullName);
                }
            }
            else if (type.IsArray)
            {
                this.Write((Array)obj);
            }
            else if (typeof(ICollection<>).IsAssignableFrom(type))
            {  // 判断是否是泛型集合 // 获取子类型。
                this.Write((ICollection)obj);
            }
            else if (typeof(ICollection).IsAssignableFrom(type))
            {  // 判断非泛型集合 不知道字段类型，不支持只实例化，编
                this.Write((ICollection)obj);
                //throw new NotSupportedException("非泛型集合 不知道字段类型，不支持只实例化");
            }
            else // object
            {
                // 获取字段 解析字段
                FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                foreach (FieldInfo fieldInfo in fieldInfos)
                {
                    Write(fieldInfo.GetValue(obj));
                }
            }
        }

    }
}
public class BinReader : BinaryReader
{
    #region 静态区
    public static Dictionary<String, MethodInfo> ReadMethodInfos;
    static BinReader()
    {
        Type type = typeof(BinReader);
        Type t;
        MethodInfo method;
        ReadMethodInfos = new Dictionary<String, MethodInfo>();
        // 添加 method;
        for (int i = 0; i < BinSerializerManager.TypeMapper.Length; i++)
        {
            t = BinSerializerManager.TypeMapper[i];
            method = type.GetMethod("Read" + t.Name);
            ReadMethodInfos.Add(t.Name, method);
        }
        // 注册 自定义字符串。
        t = typeof(String);
        method = type.GetMethod("Read" + "Str");
        ReadMethodInfos.Add(t.Name, method);
        BinSerializerManager.ReadMethodInfos = ReadMethodInfos;
    }
    #endregion
    #region 构造函数
    private Encoding m_encoding;

    public BinReader(Stream input) : this(input, BinSerializerManager.Encoding, false) { }

    public BinReader(Stream input, Encoding encoding) : this(input, encoding, false) { }

    public BinReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
        m_encoding = encoding;
    }
    #endregion
    // 默认 带长度前缀的编码。修改为顶长的编码
    public string ReadStr()
    {
        int length = ReadInt32();
        byte[] bytes = new byte[length * 2];

        Read(bytes, 0, bytes.Length);
        string str = m_encoding.GetString(bytes, 0, bytes.Length);
        return str;
    }

    public Array ReadArray(Type type)
    {
        // 获取子类型。
        Type sub = type.GetElementType();
        int length = ReadInt32();

        Array arr = Array.CreateInstance(sub, length);
        for (uint i = 0; i < length; i++)
        {
            arr.SetValue(ReadObject(sub), i);
        }
        return arr;
    }
    public object ReadList(Type t)
    {
        // 创建List<int>的实例  
        object value = Activator.CreateInstance(t);
        // 获取List<T>.Add方法的MethodInfo  
        MethodInfo addMethod = t.GetMethod("Add");
        uint length = ReadUInt32();

        Type[] types = t.GetGenericArguments();
        object[] values;
        for (uint i = 0; i < length; i++)
        {
            values = new object[types.Length];
            for (uint j = 0; j < types.Length; j++)
            {
                values[j] = ReadObject(types[j]);
            }
            addMethod.Invoke(value, values);
        }
        return value;
    }
    public T Read<T>(byte[] array)
    {
        return (T)ReadObject(typeof(T));
    }
    public object ReadObject(Type type)
    {

        // 获取字段
        Type sub;// 类型
        object value;
        try
        {
            if (ReadMethodInfos.TryGetValue(type.Name, out MethodInfo method))
            {
                value = method.Invoke(this, null);
            }
            else
            {
                if (typeof(ISerializer).IsAssignableFrom(type))
                {
                    // 外部创建实例
                    value = Activator.CreateInstance(type);
                    ISerializer serializer = (ISerializer)value;
                    serializer.Read(this);
                }
                else if (type.IsEnum)
                {
                    sub = Enum.GetUnderlyingType(type);
                    if (ReadMethodInfos.TryGetValue(sub.Name, out method))
                    {
                        value = method.Invoke(this, null);
                    }
                    else
                    {
                        throw new NotSupportedException("Enum非值类型，不支持只实例化：" + type.FullName);
                    }
                }
                else if (type.IsArray)
                {
                    value = this.ReadArray(type);
                }
                else if (typeof(ICollection<>).IsAssignableFrom(type))
                {  // 判断是否是泛型集合
                    value = this.ReadList(type);
                }
                else if (typeof(ICollection).IsAssignableFrom(type))
                {  // 判断非泛型集合 不知道字段类型，不支持只实例化，编
                    value = this.ReadList(type);
                    //throw new NotSupportedException("非泛型集合 不知道字段类型，不支持只实例化");
                }
                else
                {
                    value = Activator.CreateInstance(type);
                    FieldInfo[] fieldInfos = type.GetFields();
                    foreach (FieldInfo fieldInfo in fieldInfos)
                    {
                        fieldInfo.SetValue(value, ReadObject(fieldInfo.FieldType));
                    }
                }
            }
        }
        catch (EndOfStreamException)
        {
            value = null;
        }
        return value;
    }
}

/// </summary>
/// 忽略字段或者属性:
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class IgnoreAttribute : Attribute
{
    public IgnoreAttribute() { }
}

/// <summary>
/// 定长数组或者变长定义
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class SizeConstAttribute : Attribute
{
    bool IsSizeConst;
    uint Size;  // IsSizeConst=true,标识数组或者集合的length。为 flase，标识Count存储所占的字节数。
    Type SubType; // 对于非泛型集合 需要传递子类型。

    public SizeConstAttribute(uint Size, bool isSizeConst = true, Type SubType = null)
    {
        this.IsSizeConst = isSizeConst;
        this.Size = Size;
        this.SubType = SubType;
    }
}
