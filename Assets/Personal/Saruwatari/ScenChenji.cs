using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenChenji : MonoBehaviour
{
    [SerializeField] Image titleLogo;
    [SerializeField] Button strat;
    [SerializeField] Button opushon;
    [SerializeField] Button help;
    [SerializeField] Button credit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            titleLogo.gameObject.SetActive(false);
            strat.gameObject.SetActive(true);
            opushon.gameObject.SetActive(true);
            help.gameObject.SetActive(true);
            credit.gameObject.SetActive(true);
        }
    }

    public void LoadSceme(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
