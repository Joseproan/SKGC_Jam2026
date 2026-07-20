using UnityEngine;

[System.Serializable]
public class Music
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
}

[System.Serializable]
public class SFX
{
    public string name;
    public AudioClip[] clips;
    [Range(0f, 1f)] public float volume = 1f;
    [Range(0.5f, 2f)] public float minPitch = 1f;
    [Range(0.5f, 2f)] public float maxPitch = 1f;
}

[System.Serializable]
public class SFXCategory
{
    public string categoryName;
    public SFX[] sounds;
}