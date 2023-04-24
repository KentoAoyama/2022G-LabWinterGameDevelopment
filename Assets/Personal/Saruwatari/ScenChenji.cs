using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ScenChenji : MonoBehaviour
{
    [SerializeField] Slider titleLogo;
    [SerializeField] Button strat;
    [SerializeField] Button opushon;
    [SerializeField] Button help;
    [SerializeField] Button credit;
    [SerializeField] Image creditgamenn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            // DOTween.To() を使って連続的に変化させる
            DOTween.To(() => titleLogo.value, // 連続的に変化させる対象の値
                x => titleLogo.value = x, // 変化させた値 x をどう処理するかを書く
                (float)0 / (float)100, // x をどの値まで変化させるか指示する
                2f);   // 何秒かけて変化させるか指示する
            StartCoroutine(Strat());
        }
    }

    private IEnumerator Strat()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.1f);
            titleLogo.gameObject.SetActive(false);
            strat.gameObject.SetActive(true);
            //opushon.gameObject.SetActive(true);
            help.gameObject.SetActive(true);
            credit.gameObject.SetActive(true);

        }

    }

    public void LoadSceme(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Credit()
    {
        creditgamenn.gameObject.SetActive(true);
    }
}
