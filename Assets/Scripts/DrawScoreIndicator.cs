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
            int numDigits = Mathf.CeilToInt(Mathf.Log10(playerStats.pointCount));
            while (numDigits > digits.Count)
            {
                var digit = Instantiate(
                    digitPrefab,
                    digitOffset * digits.Count,
                    Quaternion.identity,
                    transform
                );
                digits.Add(digit);
            }

            int remaining = playerStats.pointCount;
            for (int d = 0; d < numDigits; d++)
            {
                var digit = digits[d];
                var spriteRenderer = digit.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = digitSprites[remaining % 10];
                remaining /= 10;
            }

            playerStats.pointsDirty = false;
        }
    }
}