using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timelineDirector;

    public List<TimelineAsset> timelines;

    void Awake()
    {
        timelineDirector = GetComponent<PlayableDirector>();
    }

    public void Play(int index, DirectorWrapMode wrapMode)
    {
        timelineDirector.Play(timelines[index], wrapMode);
    }
}
