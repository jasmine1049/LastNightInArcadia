using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(SORole))]
public class RoleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SORole role = (SORole)target;
        if (GUILayout.Button("Rename File"))
        {
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(role), role.Index.ToString() + "_" + role.Name);
        }
    }
}
