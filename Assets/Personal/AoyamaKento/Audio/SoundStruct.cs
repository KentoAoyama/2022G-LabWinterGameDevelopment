using UnityEngine;

/// <summary>
/// �T�E���h���܂Ƃ߂�\����
/// </summary>
[System.Serializable]
public struct Sounds
{
    public Sound[] Se;
    public Sound[] Me;
    public Sound[] Bgm;
}

/// <summary>
/// �Đ�����T�E���h�̐ݒ�
/// </summary>
[System.Serializable]
public struct Sound
{
    public AudioClip Clip;
    public float Volume;
    public bool IsLoop;
}