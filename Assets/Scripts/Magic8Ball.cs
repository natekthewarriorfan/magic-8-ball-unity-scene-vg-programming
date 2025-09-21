using UnityEngine;
using TMPro;

public class Magic8Ball : MonoBehaviour
{
    // Reference to the UI Text (TextMeshProUGUI)
    public TextMeshProUGUI answerText;

    // Array of possible answers
    private string[] answers = {
        "Yes",
        "No",
        "Ask again later",
        "Outlook good",
        "Very doubtful",
        "Definitely",
        "Cannot predict now",
        "Signs point to yes",
        "Don't count on it",
        "It is certain"
    };

    void Update()
    {
        // Check if Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Pick a random index
            int index = Random.Range(0, answers.Length);

            // Update the UI text
            answerText.text = answers[index];
        }
    }
}

