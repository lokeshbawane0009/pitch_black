using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    [SerializeField] Transform doorTop, doorBot;
    [SerializeField] float offset =1.5f;
    [SerializeField] Ease ease;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            doorTop.DOLocalMoveY(doorTop.position.y + offset, 1f).SetEase(ease);
            doorBot.DOLocalMoveY(doorBot.position.y - offset, 1f).SetEase(ease);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            doorTop.DOLocalMoveY(0f, 1f);
            doorBot.DOLocalMoveY(0f, 1f);
        }
    }
}
