using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private bool disabled;

    [Header("Post Processing Profiles")]
    [SerializeField] private PostProcessVolume mainVolumeProfile;
    [SerializeField] private PostProcessVolume secondaryVolumeProfile;

    private void Awake()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
    }

    public void MainPostProcessing()
    {
        postProcessVolume.profile = mainVolumeProfile.profile;

    }

    public void SecondaryPostProccing()
    {
        postProcessVolume.profile = secondaryVolumeProfile.profile;

    }
}
