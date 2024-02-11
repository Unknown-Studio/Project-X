using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suhdo
{
    public class Parallax : MonoBehaviour
    {
        Transform cam;
        Vector3 camStartPosition;
        float distance;

        GameObject[] backgrounds;
        Material[] materials;
        float[] backgroundSpeed;

        float farthestBackground;

        [Range(0.01f, 0.05f)]
        public float parallaxSpeed;

        void Start()
        {
            cam = Camera.main.transform;
            camStartPosition = cam.position;

            int backcount = transform.childCount;
            materials = new Material[backcount];
            backgroundSpeed = new float[backcount];
            backgrounds = new GameObject[backcount];
            for (int i = 0; i < backcount; i++)
            {
                backgrounds[i] = transform.GetChild(i).gameObject;
                materials[i] = backgrounds[i].GetComponent<Renderer>().material;

            }
            BackSpeedCalculate(backcount);
        }

        void BackSpeedCalculate(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (backgrounds[i].transform.position.z-cam.position.z>farthestBackground)
                {
                    farthestBackground = backgrounds[i].transform.position.z - cam.position.z;
                }
            }
            for (int i = 0; i < count; i++)
            {
                backgroundSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z)/farthestBackground;   
            }
        }

        private void LateUpdate()
        {
            distance = cam.position.x - camStartPosition.x;
            transform.position = new Vector3(cam.position.x, transform.position.y, 0);
            for (int i = 0; i < backgrounds.Length; i++)
            {
                float speed = backgroundSpeed[i] * parallaxSpeed;
                materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
            }
        }
    }
}
