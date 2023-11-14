using UnityEngine;

namespace AdventurePuzzleKit.SafeSystem
{
    public class SafeTrigger : MonoBehaviour
    {
        [Header("Safe Model Object")]
        [SerializeField] private SafeItem safeModel = null;

        [Header("Player Tag")]
        [SerializeField] private const string playerTag = "Player";

        private bool canUse;

        private void Update()
        {
            ShowSafeInput();
        }

        void ShowSafeInput()
        {
            if (canUse && Input.GetKeyDown(AKInputManager.instance.triggerInteractKey))
            {
                safeModel.ShowSafeLock();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                canUse = true;
                AKUIManager.instance.EnableInteractPrompt(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                canUse = false;
                AKUIManager.instance.EnableInteractPrompt(false);
            }
        }
    }
}
