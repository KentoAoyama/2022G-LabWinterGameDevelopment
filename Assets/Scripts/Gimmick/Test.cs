using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Tooltip("シーン"), SceneName, SerializeField]
    string _scene;
    [Tooltip("InputManager"), InputName, SerializeField]
    string _input;
    [Tooltip("タグ名"), TagName, SerializeField]
    string _tag;
    [Tooltip("アクションイベントのフラグ")]
    bool _isOnAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _isOnAction = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isOnAction = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isOnAction = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isOnAction = false;
    }
}
