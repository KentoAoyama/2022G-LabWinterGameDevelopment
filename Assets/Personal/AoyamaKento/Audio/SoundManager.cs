using UnityEngine;

public class SoundManager
{
    //シングルトン
    #region Singleton
    private static SoundManager _instance = new SoundManager();
    public static SoundManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private SoundManager(){}
    #endregion

    //メンバー変数
    #region Member Variables

    private SoundScriptableObject _soundScriptable;
    #endregion

    //プロパティ
    #region Properties

    public SoundScriptableObject SoundScriptable { get => _soundScriptable; set => _soundScriptable = value; }
    #endregion

    //パブリックメソッド
    #region Public Methods

    public void AudioPlay(SoundType soundType, int soundNumber)
    {
        switch (soundType)
        {
            case SoundType.SE:
                SoundPlay(_soundScriptable.SoundsData.Se, soundNumber);
                break;

            case SoundType.ME:
                SoundPlay(_soundScriptable.SoundsData.Me, soundNumber);
                break;

            case SoundType.BGM:
                SoundPlay(_soundScriptable.SoundsData.Bgm, soundNumber);
                break;
        }
    }

    #endregion

    //プライベートメソッド
    #region Private Methods

    private void SoundPlay(Sound[] sound, int soundNumber)
    {
        //該当するサンドがあるかチェック
        if (soundNumber >= sound.Length)
        {
            Debug.LogError("指定された番号に該当するサウンドはありません");
            return;
        }

        //オーディオのプレハブを生成
        Sound playSound = sound[soundNumber];
        GameObject audioObject = Object.Instantiate(_soundScriptable.AudioPrefab);
        AudioSource audioSource = audioObject.GetComponent<AudioSource>();

        //流すサウンドの設定を与える
        audioSource.clip = playSound.Clip;
        audioSource.volume = playSound.Volume;
        audioSource.loop = playSound.IsLoop;
        audioSource.Play();

        //ループするサウンドでなければ一定時間後にオブジェクトを削除
        if (!playSound.IsLoop)
        {
            Object.Destroy(audioObject, _soundScriptable.DestroyInterval);
        }
    }
    #endregion
}