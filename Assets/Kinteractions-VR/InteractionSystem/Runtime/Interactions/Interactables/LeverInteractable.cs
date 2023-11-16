using UnityEngine;
using UnityEngine.UIElements;

namespace Kandooz.InteractionSystem.Interactions
{
    public class LeverInteractable : ConstrainedInteractableBase
    {
        [SerializeField] private bool limited;
        [SerializeField] private float limit = 30;
        [SerializeField] private float center = 0;
        protected override void Activate(){}
        protected override void StartHover(){}
        protected override void EndHover(){}
        private void Update()
        {
            if (!IsSelected) return;
            var direction = CurrentInteractor.transform.position-transform.position;
            direction = Vector3.ProjectOnPlane(direction, -transform.right).normalized;
            var angle = -Vector3.SignedAngle(direction, transform.up, transform.right);
            if (limited)
            {
                if (angle > limit / 2)
                {
                    angle = limit / 2;
                    //var radLimit = limit / 2 * Mathf.Deg2Rad;
                    // direction = new Vector3(0, Mathf.Cos(radLimit),-Mathf.Sin(radLimit));
                    // direction = transform.TransformDirection(direction);
                }

                if (angle < -limit / 2)
                {
                    angle = -limit / 2;
                    //var radLimit = -limit / 2 * Mathf.Deg2Rad;
                    // direction = new Vector3(0, Mathf.Cos(radLimit),-Mathf.Sin(radLimit));
                    // direction = transform.TransformDirection(direction);
                }
            }

            Debug.DrawLine(transform.position, direction * 10 + transform.position);
            interactableObject.transform.localRotation= Quaternion.Euler(angle,0,0);
            
        }

    }
}