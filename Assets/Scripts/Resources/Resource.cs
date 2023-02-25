using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Resource : MonoBehaviour
{
    public Sprite sprite;

    private void OnEnable()
    {
        GetComponent<Renderer>().material.mainTexture = sprite.texture;
    }
}
