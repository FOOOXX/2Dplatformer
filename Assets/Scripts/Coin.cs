using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            FindObjectOfType<CoinCounter>().AddOne();
            Destroy(gameObject);
        }
    }
}
