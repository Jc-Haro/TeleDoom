using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMove : MonoBehaviour
{
    [SerializeField] private SniperMachine SM;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private List<GameObject> JumpP;

    private bool canJump = true;
    private void Start()
    {
        JumpP = GameObject.FindGameObjectWithTag("SniperJumpPoint").GetComponent<jumpPoints>().points;
    }

    public void Jump()
    {
        SM.SetAnimation(0);
        if(canJump && JumpP.Count > 0)
        {
            StartCoroutine(JumpFade());
        }
    }

    private IEnumerator JumpFade()
    {
        canJump = false;
        int random = Random.Range(0, JumpP.Count);
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.position = JumpP[random].transform.position;
        yield return new WaitForSeconds(0.25f);
        canJump = true;
        yield return null;
    }
}
