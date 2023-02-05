using UnityEngine;

namespace Game
{
    public abstract class ShipInput : MonoBehaviour
    {
        [field: Header("Ship Inputs")]

        [field: SerializeField] public Vector2 MovementInput { get; protected set; }
        [field: SerializeField] public Vector3 GazeLocationInput { get; protected set; }

        [field: SerializeField] public bool ShootInput { get; protected set; }
        [field: SerializeField] public bool BlockingInput { get; protected set; }
        [field: SerializeField] public bool DashInput { get; protected set; }

        public abstract void TickInput();
    }
}
