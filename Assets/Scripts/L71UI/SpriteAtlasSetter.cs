using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpriteAtlasSetter : MonoBehaviour
{
    public SpriteAtlas atlas; // Link to atlas
    
    private void Awake()
    {
        var image = GetComponent<Image>(); // Get image
        image.sprite = atlas.GetSprite(image.sprite.name); // Change image to image from atlas
    }
}
