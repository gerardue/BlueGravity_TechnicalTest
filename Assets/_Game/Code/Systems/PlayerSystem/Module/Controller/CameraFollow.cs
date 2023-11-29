using UnityEngine;

namespace Game.Systems.PlayerSystem.Controller
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform mainCamera;
        [SerializeField]
        private Transform target;      
        [SerializeField]
        private float smoothTime = 0.3f;      
        [SerializeField]
        private Vector3 offset = new Vector3(0, 0, -10);  
        
        [SerializeField]
        private Vector2 minLimits = new Vector2(-5, -5);  // Minimum limits for camera position
        [SerializeField]
        private Vector2 maxLimits = new Vector2(5, 5); 

        private Vector3 velocity = Vector3.zero;

        void LateUpdate()
        {
            // Calculate the target position with the offset
            Vector3 targetPosition = target.position + offset;

            // Smoothly move the camera towards the target position
            mainCamera.position = Vector3.SmoothDamp(mainCamera.position, targetPosition, ref velocity, smoothTime);
            
            float clampedX = Mathf.Clamp(mainCamera.position.x, minLimits.x, maxLimits.x);
            float clampedY = Mathf.Clamp(mainCamera.position.y, minLimits.y, maxLimits.y);
            mainCamera.position = new Vector3(clampedX, clampedY, mainCamera.position.z);
        }
    }
}