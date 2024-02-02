
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeDuration = 240f;
    private float timer;
    private bool startedCounting = false;
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI separator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;
    private float flashTimer;
    private float flashDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        SetTextDisplay(false);
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
    }
    private void ResetTimer()
    {
        timer = 0;
        SetTextDisplay(true);
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
