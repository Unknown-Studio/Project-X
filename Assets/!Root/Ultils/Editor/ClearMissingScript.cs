#if  UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Suhdo.Ultils
{
    public class ClearMissingScript : MonoBehaviour
    {
        [MenuItem("Ultils/Clear Missing Scripts In Object On Scene")]
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
#endif
