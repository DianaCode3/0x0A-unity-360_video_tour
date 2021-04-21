using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
[RequireComponent(typeof(Image))]
public class HotspotManager : MonoBehaviour, IPointerClickHandler {
 
    private Image _image;
    private FadeOut _fadeOut;
    public GameObject currentVideo;
    public GameObject nextVideo;

    void Start()
    {
        _image = GetComponent<Image>();
        _fadeOut = FindObjectOfType<FadeOut>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _image.color = Color.gray;
        _fadeOut.FadeStart(currentVideo, nextVideo);
    }
}
