using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private int _amount;

    public void AddMoney()
    {
        _amount++;

        Debug.Log($"Собрано монет: {_amount}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            AddMoney();
            Destroy(collision.gameObject);
        }
    }
}
