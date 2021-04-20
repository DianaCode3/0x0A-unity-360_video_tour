using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
[RequireComponent(typeof(Image))]
public class HotspotManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
 
    private Image _image;
    public GameObject currentVideo;
    public GameObject nextVideo;
 
    void Start() => _image = GetComponent<Image> ();
    
    public void OnPointerEnter(PointerEventData eventData) 
    {
        _image.color = Color.gray;
        Debug.Log("perfecto");
    }
 
    public void OnPointerExit(PointerEventData eventData) 
    {
        _image.color = Color.white;
    }
 
    public void OnPointerClick(PointerEventData eventData) 
    {
    
        _image.color = Color.blue;
        currentVideo.SetActive(false);
        nextVideo.SetActive(true);
        
    }
}
