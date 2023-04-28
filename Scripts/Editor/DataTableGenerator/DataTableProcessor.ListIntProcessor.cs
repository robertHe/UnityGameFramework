//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;
using System.IO;

namespace UnityGameFramework.Editor.DataTableTools
{
    public sealed partial class DataTableProcessor
    {
        private sealed class ListIntProcessor : GenericDataProcessor<List<int>>
        {
            public override string TypeName
            {
                get
                {
                    return "ListInt";
                }
            }

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
                    return "List<int>";
                }
            }

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "List<int>",
                };
            }

            public override List<int> Parse(string value)
            {
                string[] splitedValue = value.Split(';');
                List<int> arr = new List<int>();
                foreach (var item in splitedValue)
                {
                    arr.Add(int.Parse(item));
                }
                return arr;
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                binaryWriter.Write(value);
                //List<int> intlist = Parse(value);
                //foreach (var item in intlist)
                //{
                //    binaryWriter.Write7BitEncodedInt32(item);
                //}
            }
        }
    }
}
