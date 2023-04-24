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

            // DOTween.To() ���g���ĘA���I�ɕω�������
            DOTween.To(() => titleLogo.value, // �A���I�ɕω�������Ώۂ̒l
                x => titleLogo.value = x, // �ω��������l x ���ǂ��������邩������
                (float)0 / (float)100, // x ���ǂ̒l�܂ŕω������邩�w������
                2f);   // ���b�����ĕω������邩�w������
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
