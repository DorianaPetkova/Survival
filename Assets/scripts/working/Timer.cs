
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    private float timeDuration = 180f;

    private float timer;
    public GameObject rectangle;
    private bool startedCounting = false;
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI separator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    private float flashTimer;
    private float flashDuration = 1f;
    // Start is called before the first frame update

    private static Timer instance;
    void Start()
    {
        rectangle.SetActive(false);
        if (instance != null && instance != this)
        {
            // Destroy this new instance, as there can only be one
            Destroy(gameObject);
            return;
        }
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        // Set this instance as the singleton
        instance = this;

        // Make sure this instance persists between scenes
        DontDestroyOnLoad(gameObject);
        if (startedCounting == true)
            SetTextDisplay(true);
        else
            SetTextDisplay(false);

    }
    private void CheckAndActivateStars()
    {
        float currentTime = timer;

        // Check and activate stars based on current time
        if (currentTime < 60f)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            Debug.Log("three");
        }
        else if (currentTime < 120f)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            Debug.Log("two");
        }
        else if (currentTime < 180f)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            Debug.Log("one");
        }
        else
        {
            // Time is above 180 seconds, deactivate all stars
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }
    private void StopTimer()
    {

        SetTextDisplay(false);
        startedCounting = false;

    }
    public void HideStars()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        if (Shake.isShaking && Shake.shakeTimeRemaining <= 0 && !startedCounting)
        {
            Debug.Log($"{Shake.isShaking}");
            Debug.Log($"{Shake.shakeTimeRemaining}");
            Debug.Log($"{startedCounting}");
            SetTextDisplay(true);
            startedCounting = true;
            rectangle.SetActive(true);
        }

        if (startedCounting && timer < timeDuration)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else if (startedCounting)
        {
            Flash();
        }
        if (SceneManager.GetActiveScene().buildIndex == 29)
        {
            CheckAndActivateStars();
            Debug.Log("checked");
            StopTimer();
            mainMenu.clue1 = false;
            mainMenu.clue2 = false;
            Ebutton.clue4 = false;
            Shake.clue3 = false;
        }
        if (SceneManager.GetActiveScene().buildIndex == 27)
        {
            StopTimer();
            ResetTimer();
            HideStars();
            mainMenu.clue1 = false;
            mainMenu.clue2 = false;
            Ebutton.clue4 = false;
            Shake.clue3 = false;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ResetTimer();
            HideStars();
        }
    }
    public void ResetTimer()
    {
        timer = 0;
        SetTextDisplay(false);
        startedCounting = false;
        rectangle.SetActive(false);
        Shake.isShaking = false;
        AudioManager.quake = false;
        AudioManager.Squake = false;
        AudioManager.el = false;
        GameController.sceneVisited = false;
        GameController.sceneVisited1 = false;
        GameController.sceneVisited2 = false;
        GameController.sceneVisited3 = false;
        Ebutton.gotit = false;

    }
    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();

    }
    private void Flash()
    {
        if (timer != timeDuration)
        {
            timer = timeDuration;
            UpdateTimerDisplay(timer);
        }
        if (flashTimer <= 0)
        {
            flashTimer = flashDuration;
        }
        else if (flashTimer >= flashDuration / 2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }

    }
    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }
}
