using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private int _amount;

    public void AddOne()
    {
        _amount++;

        Debug.Log($"������� �����: {_amount}");
    }
}
