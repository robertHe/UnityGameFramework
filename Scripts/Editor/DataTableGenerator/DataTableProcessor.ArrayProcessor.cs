//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

namespace UnityGameFramework.Editor.DataTableTools
{
    public sealed partial class DataTableProcessor
    {
        private sealed class ArrayProcessor : GenericDataProcessor<Array>
        {
            public override bool IsSystem
            {
                get
                {
                    return false;
                }
            }

            public override string LanguageKeyword
            {
                get
                {
                    return "Array";
                }
            }

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "Array",
                };
            }

            public override Array Parse(string value)
            {
                string[] splitedValue = value.Split('|');
                Array array = Array.CreateInstance(typeof(int), splitedValue.Length);
                for (int i = 0; i < splitedValue.Length; i++)
                {
                    array.SetValue(int.Parse(splitedValue[i].Trim()), i);
                }
                return array;
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                Array array = Parse(value);
                foreach (var item in array)
                {
                    binaryWriter.Write7BitEncodedInt32(int.Parse(item.ToString()));
                }
            }
        }
    }
}
