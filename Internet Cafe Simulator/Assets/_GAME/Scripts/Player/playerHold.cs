using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerHold : MonoBehaviour
{
    [SerializeField] LayerMask holdLayer;

    bool isHold = false;
    GameObject holdObj;

    Tweener holdMoveStartTween;

    private void Start()
    {
        inputManager.Instance.action.Player.Interact.performed += onInteractPressed;
    }

    

    void onInteractPressed(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton())
        {
            if(!isHold)
            {
                Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * 0.5f, 0.6f, holdLayer);
                if (hit)
                {
                    hit.enabled = false; //collider kapatma

                    float holdSpeed = 2f;

                    holdMoveStartTween = hit.transform.DOMove(transform.position + transform.right * 0.6f, holdSpeed).SetSpeedBased(true).OnUpdate(() =>
                    {
                        holdMoveStartTween.ChangeEndValue(transform.position + transform.right * 0.6f, true);
                        holdSpeed += 0.2f;
                        holdMoveStartTween.timeScale = holdSpeed / 2; //giderek hizlanarak yaklastirir

                        if (Vector3.Distance(transform.position + transform.right * 0.6f, hit.transform.position) < 0.1f) //hedefe vardiysa
                        {
                            hit.transform.position = transform.position + transform.right * 0.6f;
                            holdMoveStartTween.Kill();
                        }
                    });

                    hit.transform.SetParent(transform, true);

                    holdObj = hit.gameObject;

                    isHold = true;
                }
            }
            else //grid sistemi yap (danis)
            {
                if (holdMoveStartTween != null) holdMoveStartTween.Kill();

                holdObj.GetComponent<Collider2D>().enabled = true; //collider acma

                holdObj.transform.SetParent(null, true);

                holdObj = null;
                isHold = false;
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + transform.right * 0.5f, 0.6f);
    }
}
