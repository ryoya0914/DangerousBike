using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;

    void Start()
    {

    }

    void OnEnable()
    {
        animator = GetComponent<Animator>();
        var info = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(info.nameHash, 0,0f);
    }

    public void FinishAnime()
    {
        PoolManager.ReleaseObject(this.gameObject);
    }
}
