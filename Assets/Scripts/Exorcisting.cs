using UnityEngine;
using UnityEngine.UI;

public class Exorcisting : MonoBehaviour
{
    public Transform CrosspointStart, CrosspointEnd;
    public Vector2 aim;
    public int i = 0, ScoreCounter;
    public bool IsCrossMoving, IsCrossReturning;
    public Text YourScoreCounter, MaxScoreCounter, YourScoreCounterAfterDeath;
    public GameObject Cross;
    public void FixedUpdate()
    {
        aim = new Vector2(Screen.width / 2, Screen.height / 2);
        var ray = Camera.main.ScreenPointToRay(aim);
        RaycastHit hit; 
        if (Physics.Raycast(ray, out hit, 1000))
        {

            var Hitted = hit.transform;
            var HittedEnemy = Hitted.gameObject.GetComponent<BaseGhostScript>();
            if (HittedEnemy != null)
            {
                HittedEnemy.CounterOfHealth -= 1;
                if (HittedEnemy.CounterOfHealth <= 0)
                {
                    Hitted.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    YourScoreCounter.text = ++ScoreCounter + "";
                    HittedEnemy.Death = true;
                }
            }
        }
    }
}
