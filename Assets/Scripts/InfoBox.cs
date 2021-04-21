using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour, IPointerClickHandler
{
    public GameObject infoObject;
    public GameObject infoTextObject;
    private Image _infoBackgound;
    private TextMeshProUGUI _infoText;

    private void Start()
    {
        _infoBackgound = infoObject.GetComponent<Image>();
        _infoText = infoTextObject.GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (infoObject.activeSelf)
            infoObject.SetActive(false);
        else
        {
            Color col1 = _infoBackgound.color;
            col1.a = 0;
            _infoBackgound.color = col1;
            
            Color col2 = _infoText.color;
            col2.a = 0;
            _infoText.color = col2;

            infoObject.SetActive(true);

            LeanTween.value(infoObject, 0, 1, 0.6f).setOnUpdate((float val) =>
            {
                Color c = _infoBackgound.color;
                c.a = val;
                _infoBackgound.color = c;
            });
            
            LeanTween.value(infoTextObject, 0, 1, 0.6f).setOnUpdate((float val) =>
            {
                Color c = _infoText.color;
                c.a = val;
                _infoText.color = c;
            });
        }
    }
}
