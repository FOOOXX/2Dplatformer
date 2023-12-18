using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            player.TryGetComponent<CoinCounter>(out CoinCounter coinCounter);

            coinCounter.AddMoney();

            Destroy(gameObject);
        }
    }
}
