using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class LoadManager : MonoBehaviour
{
    public VideoPlayer[] videos;
    public TMP_Text loadingText;
    public SpriteRenderer loadingBackGround;
    private int _idAnimation;

    private void Start()
    {
        foreach (var video in videos)
        {
            video.gameObject.SetActive(true);
        }
    }

    private void OnEnable() => ShowLoadingLine();

    private void ShowLoadingLine()
    {
        loadingText.fontStyle = FontStyles.Underline;
        _idAnimation = LeanTween.delayedCall(loadingText.gameObject, 1f, () => HideLoadingLine()).id;
        CheckLoadingVideos();
    }

    private void HideLoadingLine()
    {
        loadingText.fontStyle = FontStyles.Normal;
        _idAnimation = LeanTween.delayedCall(loadingText.gameObject, 1f, () => ShowLoadingLine()).id;
    }

    private void CheckLoadingVideos()
    {
        int readyVideos = 0;
        
        foreach (var video in videos)
        {
            if (video.isPrepared)
                readyVideos++;
        }

        if (readyVideos == 4)
        {
            for (int i = 1; i < videos.Length; i++)
                videos[i].gameObject.SetActive(false);

            LeanTween.cancel(_idAnimation);

            loadingText.gameObject.SetActive(false);
            
            LeanTween.value(loadingBackGround.gameObject, 1, 0, 1f).setOnUpdate((float val) =>
            {
                Color c = loadingBackGround.color;
                c.a = val;
                loadingBackGround.color = c;
            });
        }
    }
}
