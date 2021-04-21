using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour, IPointerClickHandler
{
    private Image _image;
    public RectTransform infoBackgound;
    public RectTransform infoText;

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (infoBackgound.gameObject.activeSelf)
            infoBackgound.gameObject.SetActive(false);
        else
        {
            infoBackgound.gameObject.SetActive(true);
            infoBackgound.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            LeanTween.alpha(infoBackgound, 1f, 0.7f).setEase(LeanTweenType.linear);
        }
    }
}
