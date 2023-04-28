//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace UnityGameFramework.Editor.DataTableTools
{
    public sealed partial class DataTableProcessor
    {
        private sealed class ArrayListProcessor : GenericDataProcessor<ArrayList>
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
                    return "ArrayList";
                }
            }

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "ArrayList",
                };
            }

            public override ArrayList Parse(string value)
            {
                string[] splitedValue = value.Split('|');
                ArrayList array = new ArrayList();
                foreach (var item in splitedValue)
                {
                    array.Add(item);
                }
                return array;
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                binaryWriter.Write(value);
            }
        }
    }
}
