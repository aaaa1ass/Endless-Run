using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item, IItem
{
    private void Update()
    {
        transform.Translate(Vector3.down * GameManager.instance.speed * Time.deltaTime);
    }
    public void Use()
    {
        effect.Play();
        Debug.Log("Coin");
    }
}
