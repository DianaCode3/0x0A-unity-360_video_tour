using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
[RequireComponent(typeof(Image))]
public class HotspotManager : MonoBehaviour, IPointerClickHandler
{
    private FadeOut _fadeOut;
    public GameObject currentVideo;
    public GameObject nextVideo;

    void Start() => _fadeOut = FindObjectOfType<FadeOut>();

    public void OnPointerClick(PointerEventData eventData)
    {
        _fadeOut.FadeStart(currentVideo, nextVideo);
    }
}
