using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Suhdo.Ultils
{
    public class SliceSprites : EditorWindow
    {
        private Vector2 scrollPosition;
        private int sliceWidth = 64;
        private int sliceHeight = 64;
        private Object[] spriteSheets;

        [MenuItem("Tools/SliceSpritesWindow")]
        static void Init()
        {
            SliceSprites window = (SliceSprites)EditorWindow.GetWindow(typeof(SliceSprites));
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Label("Sprite Slicing Settings", EditorStyles.boldLabel);

            // Add fields for slice width and height
            sliceWidth = EditorGUILayout.IntField("Slice Width:", sliceWidth);
            sliceHeight = EditorGUILayout.IntField("Slice Height:", sliceHeight);

            GUILayout.Space(10);

            // Add button to open file selection window
            if (GUILayout.Button("Select Images to Slice"))
            {
                string path = EditorUtility.OpenFolderPanel("Select Folder with Images", "", "");
                if (!string.IsNullOrEmpty(path))
                {
                    // Load all textures from the selected folder
                    spriteSheets = Resources.LoadAll(path, typeof(Texture2D));
                    Debug.Log("spriteSheets path: " + path);
                }
                else
                {
                    Debug.LogWarning("No folder selected.");
                }
            }

            GUILayout.Space(10);

            // Add button to perform slicing
            if (GUILayout.Button("Slice Selected Images"))
            {
                if (spriteSheets != null && spriteSheets.Length > 0)
                {
                    Slice();
                    Debug.Log("Done Slicing!");
                }
                else
                {
                    Debug.LogWarning("No images selected for slicing.");
                }
            }

            GUILayout.Space(10);

            Event evt = Event.current;

            // Check for drag-and-drop
            if (evt.type == EventType.DragUpdated || evt.type == EventType.DragPerform)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                // Handle dropped objects
                foreach (var draggedObject in DragAndDrop.objectReferences)
                {
                    // Check if the object is not already in the array
                    if (!Array.Exists(spriteSheets, obj => obj == draggedObject))
                    {
                        Array.Resize(ref spriteSheets, spriteSheets.Length + 1);
                        spriteSheets[spriteSheets.Length - 1] = draggedObject;
                    }
                }

                Repaint();
                evt.Use();
            }

            GUILayout.Space(10);

            // Display selected images
            GUILayout.Label("Selected Images:", EditorStyles.boldLabel);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            if (spriteSheets != null)
            {
                foreach (var spriteSheet in spriteSheets)
                {
                    GUILayout.Label(spriteSheet.ToString());
                }
            }

            GUILayout.EndScrollView();
        }

        void Slice()
        {
            for (int z = 0; z < spriteSheets.Length; z++)
            {
                Debug.Log("SpriteSheets[" + z + "]: " + spriteSheets[z]);

                string path = AssetDatabase.GetAssetPath(spriteSheets[z]);
                TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
                ti.isReadable = true;
                ti.spriteImportMode = SpriteImportMode.Multiple;

                List<SpriteMetaData> newData = new List<SpriteMetaData>();

                Texture2D spriteSheet = spriteSheets[z] as Texture2D;

                for (int i = 0; i < spriteSheet.width; i += sliceWidth)
                {
                    for (int j = spriteSheet.height; j > 0; j -= sliceHeight)
                    {
                        SpriteMetaData smd = new SpriteMetaData();
                        smd.pivot = new Vector2(0.5f, 0.5f);
                        smd.alignment = 9;
                        smd.name = (spriteSheet.height - j) / sliceHeight + ", " + i / sliceWidth;
                        smd.rect = new Rect(i, j - sliceHeight, sliceWidth, sliceHeight);

                        newData.Add(smd);
                    }
                }

                ti.spritesheet = newData.ToArray();
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }

            Debug.Log("Done Slicing!");
        }
    }
}
