using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CameraHandler : MonoBehaviour
    {
        private CameraMovement cameraMovement;
        private Transform cameraTransfrom;

        private void Start ()
        {
            cameraTransfrom = transform;
            cameraMovement = GetComponent<CameraMovement>();
        }

        public void Tick(Player attachedPlayer, Vector2 gazeLocation, float delta)
        {
            cameraMovement.HandleCameraMovement(attachedPlayer, gazeLocation, cameraTransfrom, delta);
        }
    }
}