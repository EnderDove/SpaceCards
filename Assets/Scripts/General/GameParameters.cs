using UnityEngine;
using System;

namespace Game
{
    public class GameParameters : MonoBehaviour
    {
        public static GameParameters gameParameters;

        public Dificulty ExternalDificulty;
        private float InternalDificulty;

        private float StartTime;

        public static float GetDifficulty()
        {
            gameParameters.InternalDificulty = ((int)gameParameters.ExternalDificulty) * ((Time.time - gameParameters.StartTime) / 1000 + 1);
            return gameParameters.InternalDificulty;
        }

        private void Awake()
        {
            if (gameParameters == null)
            {
                gameParameters = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            StartTime = Time.time;
        }
    }

    public enum Dificulty
    {
        Easy = 1,
        Medium = 2,
        Hard = 3,
        Hell = 5,
    }
}
