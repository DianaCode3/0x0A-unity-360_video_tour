using System;
using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;

public class FadeOut : MonoBehaviour
{
    public SpriteRenderer image;
    public GameObject initialVideo;
    private GameObject _currentVideo;
    private GameObject _nextVideo;
    private VideoPlayer _video;
    private int _idAnimation;

    private void Start()
    {
        // Start in black
        Color c = image.color;
        c.a = 1;
        image.color = c;
        
        // set initial video to avoid null references
        _currentVideo = initialVideo;
        _nextVideo = initialVideo;
        _video = _nextVideo.GetComponent<VideoPlayer>();
        
        EnableNextVideo();
    }

    public void FadeStart(GameObject currentVideo, GameObject nextVideo)
    {
        _currentVideo = currentVideo;
        _nextVideo = nextVideo;
        _video = _nextVideo.GetComponent<VideoPlayer>();

        LeanTween.value(image.gameObject, 0, 1, 1f).setOnUpdate((float val) =>
        {
            Color c = image.color;
            c.a = val;
            image.color = c;
        }).setOnComplete(EnableNextVideo);
    }

    private void EnableNextVideo()
    {
        _currentVideo.SetActive(false);
        _nextVideo.SetActive(true);
        CheckVideoLoading();
    }

    private void CheckVideoLoading()
    {
        if (_video.isPrepared)
            FadeFinished();
        else
            Invoke(nameof(CheckVideoLoading), 0.5f);
    }
    
    private void FadeFinished()
    {
        LeanTween.value(image.gameObject, 1, 0, 1f).setOnUpdate((float val) =>
        {
            Color c = image.color;
            c.a = val;
            image.color = c;
        });
    }
}
