using System;
using UnityEngine;

namespace Game
{
    public abstract class Ship : MonoBehaviour
    {
        [HideInInspector] public GameObject ship;
        [HideInInspector] public Transform shipTransform;
        [HideInInspector] public Rigidbody2D shipRigidbody;

        [HideInInspector] public ShipInput shipInput;
        [HideInInspector] public BulletLauncher[] bulletLaunchers;

        [SerializeField] public float shipHealthValue;


        private void Start()
        {
            shipRigidbody = GetComponent<Rigidbody2D>();
            shipTransform = GetComponent<Transform>();
            shipInput = GetComponent<ShipInput>();
            bulletLaunchers = GetComponentsInChildren<BulletLauncher>();
        }

        protected virtual void HandleLocomotion(Vector2 MovementInput, Vector2 gazeLocationInput)
        {

        }

        protected virtual void HandleDash(bool dashInput)
        {

        }

        protected virtual void HandleBlocking(bool blockingInput)
        {

        }

        protected virtual void HandleDeath() { }

        private void Update()
        {
            shipInput.TickInput();
            HandleLocomotion(shipInput.MovementInput, shipInput.GazeLocationInput);
            HandleDash(shipInput.DashInput);
            HandleBlocking(shipInput.BlockingInput);
            foreach (BulletLauncher bulletLauncher in bulletLaunchers)
                bulletLauncher.Shoot(shipInput.ShootInput);
        }
    }
}
