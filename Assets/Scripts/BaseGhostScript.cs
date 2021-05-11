using UnityEngine;
using System.Collections;

public class BaseGhostScript : MonoBehaviour
{
    private GameObject Player;
    public int CounterOfHealth = 0;
    public bool PathFollowing = true, PointIsSetted = false, Death;
    public Transform PointOfPath;
    public Transform[] Boundaries;
    public MeshRenderer EnemyColor;
    public CapsuleCollider EnemyCollider;
    public float SpeedToPlayer,SpeedForPathFoliowing, Scaler;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(2, 7);
        if(i==5)
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            SpeedToPlayer = 0.02f;
            SpeedForPathFoliowing = 0.04f;
            CounterOfHealth = 80;
            EnemyColor.material.color = Color.yellow;
            StartCoroutine(PreparingToAttackPlayer(10));
        }
        else if (i==6)
        {
            SpeedToPlayer = 0.02f;
            SpeedForPathFoliowing = 0.04f;
            CounterOfHealth = 120;
            EnemyColor.material.color = Color.green;
            Invoke("Shot", 4);
            StartCoroutine(PreparingToAttackPlayer(10));
        }
        else
        {
            SpeedToPlayer = 0.02f;
            SpeedForPathFoliowing = 0.04f;
            CounterOfHealth = 120;
            StartCoroutine(PreparingToAttackPlayer(10));
        }

        Player = FindObjectOfType<CameraController>().gameObject;
        transform.parent = null;
        PointOfPath.transform.parent = null;
        Boundaries[0] = GameObject.Find("Boundaries1").transform;
        Boundaries[1] = GameObject.Find("Boundaries2").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Player.transform);
        if (PathFollowing == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, SpeedToPlayer);
            if(Vector3.Distance(transform.position, Player.transform.position) <= 1)
            {
                Player.GetComponent<CameraController>().DeathScreenEnable = true;
            }

        }
        else if (PathFollowing == true)
        {
            if (PointIsSetted == false)
            {
                SetPoint();
            }
            else if (PointIsSetted == true)
            {
                PathFinding();
            }
        }
        if (Death == true)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            if (transform.localScale.x <= 0)
                Destroy(this.gameObject);
        }
    }
    void PathFinding()
    {
        transform.position = Vector3.MoveTowards(transform.position, PointOfPath.position, 0.04f);
        if (Vector3.Distance(transform.position, PointOfPath.position) <= 1)
        {
            SetPoint();
        }
    }
    void SetPoint()
    {
        PointOfPath.position = new Vector3(Random.Range(Boundaries[0].position.x, Boundaries[1].position.x), Random.Range(Boundaries[0].position.y, Boundaries[1].position.y), Random.Range(Boundaries[0].position.z, Boundaries[1].position.z));
        PointIsSetted = true;
    }
    public void Shot()
    {
        Instantiate(Player.GetComponent<CameraController>().slime/*,transform.position = new Vector3(Random.Range(-50, 450), Random.Range(-60, 250),0)*/);
    }
    IEnumerator PreparingToAttackPlayer(float s)
    {
        yield return new WaitForSecondsRealtime(s);
        PathFollowing = false; 
        EnemyColor.material.color = Color.red;
        EnemyCollider.isTrigger = true;
    }

}