using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Echo : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] GameObject echoObject;
    [SerializeField] float scale, time;

    private void OnEnable()
    {
        PlayerController.locomotion += IntiateEcho;
    }

    void IntiateEcho()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GameObject clone =Instantiate(echoObject, parent);
            clone.transform.DOScale(scale, time).OnComplete(()=> Destroy(clone.gameObject));

        }

    }

    private void OnDisable()
    {
        PlayerController.locomotion -= IntiateEcho;
    }
}
