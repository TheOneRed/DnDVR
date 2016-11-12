using CnControls;
using UnityEngine;

namespace CustomJoystick
{
    public class FourWayController : MonoBehaviour
    {
        private Vector3[] directionalVectors = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
		//private Vector3[] directionalVectors = { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };

        private Transform _mainCameraTransform;

        private void Awake()
        {
            _mainCameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            var movementVector = new Vector3(CnInputManager.GetAxis("Horizontal"), 0f, CnInputManager.GetAxis("Vertical"));
			//var movementVector = new Vector3(CnInputManager.GetAxis("Horizontal"), 1.0f, CnInputManager.GetAxis("Vertical"));
            if (movementVector.sqrMagnitude < 0.00001f) return;

            // Clamping
            Vector3 closestDirectionVector = directionalVectors[0];
            float closestDot = Vector3.Dot(movementVector, closestDirectionVector);
            for (int i = 1; i < directionalVectors.Length; i++)
            {
                float dot = Vector3.Dot(movementVector, directionalVectors[i]);
                if (dot < closestDot)
                {
                    closestDirectionVector = directionalVectors[i];
                    closestDot = dot;
                }
            }

            // closestDirectionVector is what we need
            //var transformedDirection = _mainCameraTransform.InverseTransformDirection(closestDirectionVector);
			var transformedDirection = _mainCameraTransform.TransformDirection(closestDirectionVector);
            //transformedDirection.y = 0f;
			//transformedDirection.z = 0f;
            //transformedDirection.Normalize();

			transform.position -= transformedDirection * Time.deltaTime;

        }
    }
}
