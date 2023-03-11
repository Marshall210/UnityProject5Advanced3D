using UnityEngine;

namespace EditorPart
{
    public class GameParameters : MonoBehaviour
    {
        public int level;
        // Add context menu method
        [ContextMenuItem("Randomize Level", "Randomize")]
        public int progress;

        private GameObject levelView;
        
        public void CreateLevelView()
        {
            if (levelView != null)
                DestroyImmediate(levelView);
        
            levelView = GameObject.CreatePrimitive(PrimitiveType.Cube);
            levelView.transform.localScale = Vector3.one * Random.Range(1f, 3f);
            levelView.transform.eulerAngles = Vector3.one * 45;
            levelView.transform.SetParent(transform);
        }

        // Add context menu
        [ContextMenu("Clean Parameters")]
        public void CleanParameters()
        {
            if (levelView != null)
                DestroyImmediate(levelView);

            level = 0;
            progress = 0;
        }
        
        private void Randomize()
        {
            progress = Random.Range(1, 100);
        }
    }
}
