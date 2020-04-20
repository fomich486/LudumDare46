using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New sound data", menuName = "sound data", order = 51)]
public class AudioData : ScriptableObject
{
    public AudioClip explosion;
    public AudioClip chop;
    public AudioClip pickUp;
    public AudioClip wateringCam;
    public AudioClip treeDestroyed;
    public AudioClip throwItem;
}
