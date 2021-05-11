using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour
{
    // This can strange work on pc, but normal on Android
    public bool DisappearingOfSlime;
    public float AlfaForSlime=1;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = FindObjectOfType<Canvas>().transform;
        transform.position = new Vector2(Random.Range(-50, 2000), Random.Range(-60, 1200));
        Invoke("StartDisappearing", 4);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DisappearingOfSlime == true)
        {
            GetComponent<Image>().color = new Color(0.1f, 1, 0, AlfaForSlime -= 0.005f);
            if (AlfaForSlime <= 0)
                Destroy(gameObject);
        }
    }
    void StartDisappearing()
    {
        DisappearingOfSlime = true;
    }
}