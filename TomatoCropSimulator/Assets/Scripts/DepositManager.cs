using UnityEngine;
using TMPro;

public class DepositUIManager : MonoBehaviour
{
    public static DepositUIManager Instance;

    public TMP_Text tomatoesCollected;
    public TMP_Text infectedCollected;
    public TMP_Text ratio;

    private void Awake()
    {
        Instance = this;
    }
}
