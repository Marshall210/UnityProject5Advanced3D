using UnityEditor;
using UnityEngine;

namespace EditorPart.Editor
{
    [CustomEditor(typeof(Transform))]
    public class TransformEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector(); // Draw default inspector view

            // Find target script
            Transform myTarget = (Transform)target;

            var distanceToCenter = Vector3.Distance(Vector3.zero, myTarget.position);
            
            // Add help box
            EditorGUILayout.HelpBox("Distance To Center", MessageType.Info);
            // Add 
            EditorGUILayout.LabelField("Distance", distanceToCenter.ToString());
        }
    }
}
