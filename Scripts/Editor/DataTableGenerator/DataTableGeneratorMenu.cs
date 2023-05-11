//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.IO;
using GameFramework;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.DataTableTools
{
    public sealed class DataTableGeneratorMenu
    {
        private const string DataTablePath = "Assets/GameMain/DataTables";
        private const string DataTableBinaryPath = "Assets/GameMain/DataTables/Binary";

        [MenuItem("Assets/DataTables/Generate All DataTables",false, 31)]
        private static void GenerateAllDataTables()
        {
            DirectoryInfo directory = new DirectoryInfo(DataTablePath);

            foreach (FileInfo file in directory.GetFiles()) 
            {
                if (file.Name.Contains("CmsFinddiffPicValueTest02") || file.Name.Contains("CmsFinddiffDdaOptionalList") || file.Name.Contains("CmsFinddiffPicValueTest03") || file.Name.Contains("ConfigCiyPalette"))
                {
                    continue;
                }
                if (file.Extension == ".txt")
                {
                    string dataTableName = Path.GetFileNameWithoutExtension(file.Name);
                    GenerateDataTable(dataTableName);
                }
            }

            AssetDatabase.Refresh();
        }
        
        /// <summary>
        /// Change importer of the currently selected .psd files.
        /// </summary>
        [MenuItem("Assets/DataTables/Generate DataTables", false, 30)]
        private static void GenerateDataTables()
        {
            foreach (Object obj in Selection.objects)
            {
                string path = AssetDatabase.GetAssetPath(obj);
                string ext = Path.GetExtension(path);
                if (ext == ".txt")
                {
                    string dataTableName = Path.GetFileNameWithoutExtension(path);
                    GenerateDataTable(dataTableName);
                }
            }
            AssetDatabase.Refresh();
        }

        private static void GenerateDataTable(string dataTableName)
        {
            DataTableProcessor dataTableProcessor = DataTableGenerator.CreateDataTableProcessor(dataTableName);
            if (!DataTableGenerator.CheckRawData(dataTableProcessor, dataTableName))
            {
                Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTableName));
                return;
            }

            DataTableGenerator.GenerateDataFile(dataTableProcessor, dataTableName);
            DataTableGenerator.GenerateCodeFile(dataTableProcessor, dataTableName);
            if (dataTableName == "UIForm")
            {
                DataTableGenerator.GenerateUIFormEnumFile(dataTableProcessor, dataTableName);
            }
        }
    }
}
