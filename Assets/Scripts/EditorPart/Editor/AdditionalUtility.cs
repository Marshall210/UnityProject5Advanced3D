using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorPart.Editor
{
    public class AdditionalUtility : EditorWindow
    {
        private GameObject pattern;
        private int heightCount;
        private int widthCount;
        private float distance;
        private readonly List<Transform> cubes = new List<Transform>();
        
        
        [MenuItem("Tools/Create Objects Grid")]
        static void Init()
        {
            CreateWindow<AdditionalUtility>("Additional Tools");
        }

        void OnGUI()
        {
            // Setup view of fields
            pattern = (GameObject) EditorGUILayout.ObjectField("Pattern Object", pattern, typeof(GameObject), true, new GUILayoutOption[0]{});
            heightCount = EditorGUILayout.IntField("Height count", heightCount);
            widthCount = EditorGUILayout.IntField("Width count", widthCount);
            distance = EditorGUILayout.FloatField("Distance", distance);
            // Correct fields
            CorrectFields();
            
            // Setup buttons
            
            if (GUILayout.Button("Generate"))
            {
                GenerateCubes();
            }
            
            if (GUILayout.Button("Clear"))
            {
                RemoveCubes();
            }
        }

        private void CorrectFields()
        {
            if (heightCount < 0)
                heightCount = 0;
            
            if (widthCount < 0)
                widthCount = 0;
            
            if (distance < 0)
                distance = 0;
        }

        private void GenerateCubes()
        {
            RemoveCubes();

            for (var i = 0; i < heightCount; i++)
            {
                for (int j = 0; j < widthCount; j++)
                {
                    var cube = pattern != null ? 
                        Instantiate(pattern) : 
                        GameObject.CreatePrimitive(PrimitiveType.Cube);
                    
                    cube.transform.localScale = Vector3.one * 0.3f;
                    cube.transform.position = new Vector3(j * distance, i * distance, 0);
                    cubes.Add(cube.transform);
                }
            }

            foreach (var cube in cubes)
            {
                cube.transform.position -= new Vector3(widthCount * distance / 2, 
                    heightCount * distance / 2, 0);
            }
        }

        private void RemoveCubes()
        {
            foreach (var cube in cubes)
            {
                DestroyImmediate(cube.gameObject);
            }
            
            cubes.Clear();
        }

        // Invoke when window close
        private void OnDestroy()
        {
            RemoveCubes();
        }
    }
}
