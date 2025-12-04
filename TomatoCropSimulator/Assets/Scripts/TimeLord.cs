using UnityEngine;
using TMPro;

public class TimeLord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    private float currentTime = 0f;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        textMesh.text = currentTime.ToString("0.00");
    }
}
