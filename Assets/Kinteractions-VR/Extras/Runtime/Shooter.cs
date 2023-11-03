using Kandooz.InteractionSystem.Interactions;
using UniRx;
using UnityEngine;

namespace Kandooz.InteractionSystem.Extras
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Rigidbody bulletPrefab;
        [SerializeField] private float shootingSpeed = 10;
        private InteractableBase interactable;
        void Awake()
        {
            interactable = GetComponentInParent<InteractableBase>();
            if(!interactable) return;
            interactable.OnActivated.Do(Shoot).Subscribe().AddTo(this);
        }
        public void Shoot(InteractorBase interactor)
        {
            var bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            bullet.velocity = transform.forward * shootingSpeed;
        }
    }
}