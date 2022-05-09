using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectController : MonoBehaviour
{
    public static CoinCollectController instance;

    public void PopCoins(Vector3 position, int coinCount)
    {
        float groundY = position.y - 0.4f;
        for(int i = 1; i <= coinCount; i++)
        {
            GameObject coinGameObject = Instantiate(GameAssets.Instance.pfCoin, position + new Vector3(Random.Range(-0.2f, 0.2f), 0, 0), Quaternion.identity);
            Rigidbody2D rb = coinGameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-0.75f, 0.75f), 1f));
        }
    }

    public void CollectAllCoins()
    {

    }
}
