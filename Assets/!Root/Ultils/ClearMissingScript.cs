using UnityEditor;
using UnityEngine;

namespace Suhdo
{
    public class ClearMissingScript : MonoBehaviour
    {
        [MenuItem("Ultils/ClearMissingScriptsInObjectInScene")]
        static void RemoveMissingScripts()
        {
            foreach (GameObject gameObject in FindObjectsOfType<GameObject>(true))
            {
                foreach (var item in gameObject.GetComponentsInChildren<Component>())
                {
                    if (item == null)
                    {
                        GameObjectUtility.RemoveMonoBehavioursWithMissingScript(gameObject);
                    }
                }
            }
        }
    }
}