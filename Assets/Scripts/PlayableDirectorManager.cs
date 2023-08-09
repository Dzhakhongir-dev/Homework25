using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayableDirectorManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;

    public void PlayableDirectorPlay()
    {
        playableDirector.Play();
    }
}
