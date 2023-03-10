using UnityEditor;
using UnityEngine;

namespace EditorPart.Editor
{
    [CustomEditor(typeof(GameParameters))]
    public class GameParametersEditor : UnityEditor.Editor
    {
        public Texture2D cleanImage;
        
        public override void OnInspectorGUI()
        {
            // DrawDefaultInspector(); // Draw default inspector view
            // return;
            
            // Find target script
            GameParameters myTarget = (GameParameters)target;

            // Add fields view
            myTarget.level = EditorGUILayout.IntField("Level", myTarget.level);
            myTarget.progress = EditorGUILayout.IntField("Progress", myTarget.progress);
            EditorGUILayout.Separator(); // Add space
            
            var score = myTarget.level * myTarget.progress;
            // Add help box
            EditorGUILayout.HelpBox("Calculated score", MessageType.Info);
            // Add 
            EditorGUILayout.LabelField("Score", score.ToString());

            EditorGUILayout.Separator();
            
            // Create button
            if (GUILayout.Button("Create Level View"))
            {
                myTarget.CreateLevelView(); // Invoke when button clicked
            }
            
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Reset button");
            if (GUILayout.Button(cleanImage, GUIStyle.none))
            {
                myTarget.CleanParameters();
            }
        }
    }
}
