using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private int _amount;

    public void AddMoney()
    {
        _amount++;

        Debug.Log($"������� �����: {_amount}");
    }
}
