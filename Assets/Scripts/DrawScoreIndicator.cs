using System.Collections.Generic;
using UnityEngine;

public class DrawScoreIndicator : MonoBehaviour
{
    PlayerStats playerStats;
    public GameObject digitPrefab;
    public Vector3 digitOffset;
    public Sprite[] digitSprites = new Sprite[10];

    public List<GameObject> digits = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        digits.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.pointsDirty)
        {
            int remaining = playerStats.pointCount;
            int numDigits = 0;

            do
            {
                numDigits++;
                while (numDigits > digits.Count)
                {
                    var d = Instantiate(
                        digitPrefab,
                        transform.position + digitOffset * digits.Count,
                        Quaternion.identity,
                        transform
                    );
                    digits.Add(d);
                }

                var digit = digits[numDigits-1];
                var spriteRenderer = digit.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = digitSprites[remaining % 10];
                remaining /= 10;
            } while (remaining > 0);

            playerStats.pointsDirty = false;
        }
    }
}