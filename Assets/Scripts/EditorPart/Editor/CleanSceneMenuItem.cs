using UnityEditor;
using UnityEngine;

namespace EditorPart.Editor
{
    // Create menu items
    public class CleanSceneMenuItem : MonoBehaviour
    {
        /// <summary>
        /// % – CTRL on Windows / CMD on OSX
        ///# – Shift
        ///& – Alt
        /// LEFT/RIGHT/UP/DOWN – Arrow keys
        /// F1…F2 – F keys
        /// HOME, END, PGUP, PGDN
        /// </summary>
        
        [MenuItem("Tools/Clean Scene %#a")]
        private static void NewMenuOption()
        {
            var sceneObjects = FindObjectsOfType<Transform>();

            foreach (var obj in sceneObjects)
            {
                if (!obj.GetComponent<Camera>())
                    DestroyImmediate(obj.gameObject);
            }
        }
        
        [MenuItem("Assets/Clean Scene")]
        private static void NewMenuOptionA()
        {
            var sceneObjects = FindObjectsOfType<Transform>();

            foreach (var obj in sceneObjects)
            {
                if (!obj.GetComponent<Camera>())
                    DestroyImmediate(obj.gameObject);
            }
        }
    }
}
