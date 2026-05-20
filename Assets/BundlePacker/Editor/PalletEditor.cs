using BundlePacker.Core;
using UnityEditor;
using UnityEngine;
namespace BundlePacker.Editor
{
    [CustomEditor(typeof(Pallet), true)]
    public class PalletEditor : UnityEditor.Editor
    {
        private static BuildTarget m_targetPlatform = BuildTarget.NoTarget;
        public void OnEnable()
        {
            m_targetPlatform = EditorUserBuildSettings.activeBuildTarget;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            m_targetPlatform = (BuildTarget)EditorGUILayout.EnumPopup("Platform:", m_targetPlatform);

            if (GUILayout.Button("Build"))
            {
                BundleBuilder.BuildPallet(target as Pallet, m_targetPlatform);
            }
        }
    }
}