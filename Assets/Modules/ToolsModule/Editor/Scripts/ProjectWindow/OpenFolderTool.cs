using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace GRV.ToolsModule
{
    public static class OpenFolderTool
    {
        [OnOpenAsset(1)]
        public static bool OnOpenAsset(int instanceId)
        {
            Event e = Event.current;
            if (e == null || !e.shift)
                return false;
            
            Object obj = EditorUtility.InstanceIDToObject(instanceId);
            string path = AssetDatabase.GetAssetPath(obj);
            if (AssetDatabase.IsValidFolder(path))
            {
                EditorUtility.RevealInFinder(path);
            }

            return true;
        }
    }
}

