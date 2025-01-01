using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI ammoText;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time >= 1)
            timerText.text = Time.time.ToString("#,#");
    }
}
