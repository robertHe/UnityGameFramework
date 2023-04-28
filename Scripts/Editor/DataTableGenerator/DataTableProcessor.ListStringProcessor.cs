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
        private sealed class ListStringProcessor : GenericDataProcessor<List<string>>
        {
            public override string TypeName
            {
                get
                {
                    return "ListString";
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
                    return "List<string>";
                }
            }

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "List<string>",
                };
            }

            public override List<string> Parse(string value)
            {
                string[] splitValue = value.Split(',');
                List<string> arr = new List<string>();
                foreach (var item in splitValue)
                {
                    arr.Add(item);
                }
                return arr;
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                List<string> intlist = Parse(value);
                foreach (var item in intlist)
                {
                    binaryWriter.Write(item);
                }
            }
        }
    }
}
