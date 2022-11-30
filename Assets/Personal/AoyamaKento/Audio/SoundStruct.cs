using UnityEngine;

/// <summary>
/// サウンドをまとめる構造体
/// </summary>
[System.Serializable]
public struct Sounds
{
    public Sound[] Se;
    public Sound[] Me;
    public Sound[] Bgm;
}

/// <summary>
/// 再生するサウンドの設定
/// </summary>
[System.Serializable]
public struct Sound
{
    public AudioClip Clip;
    public float Volume;
    public bool IsLoop;
}