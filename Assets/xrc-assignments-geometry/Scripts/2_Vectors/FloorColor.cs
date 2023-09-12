using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRC.Assignments.Geometry
{
    public class FloorColor : MonoBehaviour
    {
        [SerializeField]
        private Transform m_Target;
        private const float k_DistanceThreshold = 5.0f;
        private Renderer m_Renderer;

        void Start()
        {
            m_Renderer = GetComponent<Renderer>();
        }

        void Update()
        {
            Color color = CalculateColor(transform.position, m_Target.position, m_Target.forward, k_DistanceThreshold);
            m_Renderer.material.SetColor("_Color", color);
        }

        public static Color CalculateColor(Vector3 position, Vector3 targetPosition, Vector3 targetForward, float distanceThreshold = k_DistanceThreshold)
        {
            Color color = new Color(0.5f, 0.5f, 0.5f);
            
            // TODO - Modify the color value according to instructions
            // <solution>
            // Radial Color Effect
            float d = Vector3.Distance(position, targetPosition);
            float alpha = Mathf.Max((distanceThreshold - d) / distanceThreshold, 0);
            color.r = 1 - alpha;
            color.g = 0;
            color.b = alpha;
            
            // Directional Color Effect
            Vector3 v = position - targetPosition;
            v.y = 0;  // Remove the y-component
            targetForward.y = 0;  // Remove the y-component
            float dotProduct = Vector3.Dot(v.normalized, targetForward.normalized);

            // Check if the dot product is within the desired range
            if (dotProduct >= 0.9f)  // You can adjust this threshold
            {
                color.g = 1;  // Set green channel to 1 to make the tile yellow
            }
            // </solution>

            return color;
        }
    }
}