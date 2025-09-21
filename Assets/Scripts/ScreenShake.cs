using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [Header("Defaults")]
    public float defaultDuration = 0.2f;
    public float defaultMagnitude = 0.3f;

    Vector3 _originalPos;
    float _timeLeft;
    float _magnitude;

    void OnEnable() => _originalPos = transform.localPosition;

    void LateUpdate()
    {
        // 👇 Press Space to trigger shake
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shake(); // uses defaults
        }

        if (_timeLeft > 0f)
        {
            _timeLeft -= Time.unscaledDeltaTime; // works even if Time.timeScale = 0
            float t = Mathf.Clamp01(_timeLeft / Mathf.Max(0.0001f, defaultDuration));
            float fade = t * t; // quadratic ease-out for smoother stop
            Vector2 offset = Random.insideUnitCircle * _magnitude * fade;
            transform.localPosition = _originalPos + new Vector3(offset.x, offset.y, 0f);
        }
        else
        {
            transform.localPosition = _originalPos; // snap back
        }
    }

    public void Shake(float duration = -1f, float magnitude = -1f)
    {
        if (duration <= 0f) duration = defaultDuration;
        if (magnitude <= 0f) magnitude = defaultMagnitude;
        _timeLeft = duration;
        _magnitude = magnitude;
    }
}

