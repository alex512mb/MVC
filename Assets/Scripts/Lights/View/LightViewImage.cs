using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LightViewImage : MonoBehaviour, ILightView
{
    [SerializeField] private Color activeColor = Color.white;

    private Image attachedImage;
    private Color primaryColor;

    private void Awake()
    {
        attachedImage = GetComponent<Image>();
        primaryColor = attachedImage.color;
    }
    public void SetActive(bool active)
    {
        attachedImage.color = active ? activeColor : primaryColor;
    }
}
