using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Renderer))]
    public class Resource : MonoBehaviour
    {
        public Sprite[] sprites = new Sprite[5];

        private void Spawn(ResourceType resource, ResourceStone stone)
        {
            gameObject.SetActive(true);
            GetComponent<Renderer>().material.mainTexture = sprites[(int)resource].texture;
        }
    }
}
