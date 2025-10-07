using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;      // for Slider and legacy Text
using TMPro;               // for TextMeshProUGUI

public class Magic8Ball : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Text component that shows the answer")]
    public TextMeshProUGUI answerTMP;   // drag your AnswerText (TMP) here
    public Text answerText;             // or use this if you use old UI Text

    [Header("Answer Pools")]
    [TextArea]
    public List<string> positiveAnswers = new List<string>()
    {
        "Definitely", "Yes", "Absolutely", "It is certain", "Count on it"
    };

    [TextArea]
    public List<string> negativeAnswers = new List<string>()
    {
        "No", "Very doubtful", "Not likely", "Don't count on it", "Nope"
    };

    [Header("Optimism (0–100%)")]
    [Range(0, 100)]
    public int optimismPercent = 50; // default midpoint if no slider present

    [Header("Optional: Hook a Slider (0..1)")]
    public Slider optimismSlider; // if set, we read value from this (0..1)

    System.Random rng;  // simple RNG
    void Awake() { rng = new System.Random(); }

    void Update()
    {
        // press Space to ask the ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowRandomAnswer();
        }

        // if a Slider is assigned, keep optimismPercent synced with it
        if (optimismSlider)
        {
            optimismPercent = Mathf.RoundToInt(optimismSlider.value * 100f);
        }
    }

    public void ShowRandomAnswer()
    {
        // decide which list to pull from based on optimismPercent
        int roll = rng.Next(0, 100);  // 0..99
        bool choosePositive = roll < optimismPercent;

        string answer = choosePositive
            ? PickRandom(positiveAnswers)
            : PickRandom(negativeAnswers);

        // write to whichever text you’re using
        if (answerTMP) answerTMP.text = answer;
        if (answerText) answerText.text = answer;
    }

    string PickRandom(List<string> list)
    {
        if (list == null || list.Count == 0) return "(no answers in list)";
        int i = rng.Next(0, list.Count);
        return list[i];
    }
}
