using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCoins : MonoBehaviour
{
    public int numberOfCoins = 15;
    public GameObject coin;
    public Text score;
    public Text countdown;
    public Text endText;
    public float timeLeft = 20;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject obj = Instantiate(coin) as GameObject;
            obj.transform.position = new Vector2(Random.Range(-12,12),Random.Range(-12,12));
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Coins left:" + numberOfCoins.ToString();
        countdown.text = "Time left: " + timeLeft.ToString("0.0");

        
        if ( timeLeft < 0 )
        {
            endText.text = "Lost";
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }

        if(numberOfCoins == 0) {
            endText.text = "Won";
            timeLeft = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coin") numberOfCoins--;
    }
}
