using UnityEngine;

public class DepositArea : MonoBehaviour
{
    private static int tomatoCount = 0;
    private static int infectedCount = 0;
    private int ratio1;
    private int ratio2;

    private void OnTriggerEnter(Collider collision)
    {
        Harvest harvest = collision.GetComponent<Harvest>();

        if (harvest == null)
            return;

        tomatoCount += harvest.tomatoesCarried;
        infectedCount += harvest.infectedCarried;

        int gcd = GCD(tomatoCount, infectedCount);

        harvest.tomatoesCarried = 0;
        harvest.infectedCarried = 0;

        DepositUIManager.Instance.tomatoesCollected.text = $"Tomatoes Collected: {tomatoCount}";
        DepositUIManager.Instance.infectedCollected.text = $"Infected Collected: {infectedCount}";
        DepositUIManager.Instance.ratio.text = $"Ratio {tomatoCount/gcd}/{infectedCount/gcd}";
    }

    private int GCD(int x, int y)
    {
        while (y != 0)
        {
            int temp = y;
            y = x%y;
            x = temp;
        }
        return x;
    }
}
