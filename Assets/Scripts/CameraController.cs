using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    [SerializeField]
    public GameObject cameraContainer, ObjectsWhatMustBeActiveOnDie, slime;
    public GameObject[] ToolForExorcism;
    private Quaternion rot;
    public Image DeathScreen;
    public float AlfaForDeathScreen;
    public bool DeathScreenEnable, StartLevel, Dead, DisappearingOfSlime;
    public Text YouDieText;
    public string[] DyingText;
    private Exorcisting ExorcitingScript;
    [SerializeField]
    private Button RestartLevel;//вставте любой компонент из канваса


    private void Start()
    {
        Debug.Log(PlayerPrefsSafe.GetInt("ChosedWeapon"));
        ExorcitingScript = FindObjectOfType<Exorcisting>();
        //cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        //transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();
        AlfaForDeathScreen = DeathScreen.color.a;
        ToolForExorcism[PlayerPrefsSafe.GetInt("ChosedWeapon") - 1].SetActive(true);
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }
    private void FixedUpdate()
    {
        if (StartLevel == true)
        {
            DeathScreen.color = new Color(0, 0, 0, AlfaForDeathScreen -= 0.02f);
            if (AlfaForDeathScreen <=0)
            {
                StartLevel = false;
            }
        }
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
        Dying();
    }
    /*public void Shotted()
    {
        //Instantiate(slime, transform.parent = null, SlimePosition);
        SlimePosition.position = new Vector2(Random.Range(-50,450), Random.Range(-60,250));
        DisappearingOfSlime=true;
    }*/
    public void Dying()
    {
        if (DeathScreenEnable == true && AlfaForDeathScreen <= 3)
        {
            DeathScreen.color = new Color(0, 0, 0, AlfaForDeathScreen += 0.03f);
            if (AlfaForDeathScreen >= 2.2 && Dead == false)
            {
                ObjectsWhatMustBeActiveOnDie.SetActive(true);
                //YouDieText.gameObject.SetActive(true);
                YouDieText.text = DyingText[Random.Range(0, DyingText.Length)] + " ";
                if (PlayerPrefsSafe.HasKey("MaxScore") == true)
                {
                    if(PlayerPrefsSafe.GetInt("MaxScore") <= ExorcitingScript.ScoreCounter)
                    {
                        PlayerPrefsSafe.SetInt("MaxScore", ExorcitingScript.ScoreCounter);
                    }
                }
                else if (PlayerPrefsSafe.HasKey("MaxScore") == false)
                {
                    PlayerPrefsSafe.SetInt("MaxScore", ExorcitingScript.ScoreCounter);
                }
                //RestartLevel.gameObject.SetActive(true);
                //ExorcitingScript.YourScoreCounterAfterDeath.gameObject.SetActive(true);
                //ExorcitingScript.MaxScoreCounter.gameObject.SetActive(true);
                //ExorcitingScript.YourScoreCounter.gameObject.SetActive(false);

                ExorcitingScript.MaxScoreCounter.text = "" + PlayerPrefsSafe.GetInt("MaxScore");
                ExorcitingScript.YourScoreCounterAfterDeath.text = "" + ExorcitingScript.ScoreCounter;
                Dead = true;
                Debug.Log("Saved");
            }
        }
    }
}