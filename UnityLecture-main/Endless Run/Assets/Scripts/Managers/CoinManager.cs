using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Percentage))]
public class CoinManager : MonoBehaviour
{
    private Percentage percentage;

    [SerializeField] bool flag;
    [SerializeField] int itemCount;
    [SerializeField] int interval = 2;
    [SerializeField] int createCount = 20;
    [SerializeField] float positionX = 3.5f;

    [SerializeField] ItemManager itemManager;
    [SerializeField] GameObject rotatePrefab;

    [SerializeField] GameObject coinPrefab;
    [SerializeField] List<GameObject> coins;
    [SerializeField] Transform createPosition; 

    void Start()
    {
        percentage = GetComponent<Percentage>();

        itemManager = GameObject.Find("Item Manager").GetComponent<ItemManager>();

        //Debug.Log(itemManager.CloneItem().name);

        CreateCoin();
    }

    private void CreateCoin()
    {
        for(int i = 0; i < createCount; i++)
        {
            GameObject coin = Instantiate (coinPrefab);

            coin.transform.SetParent(createPosition);

            coin.transform.localPosition = new Vector3(coin.transform.position.x, coin.transform.position.y, interval * i);

            coins.Add(coin);
        }
    }

    public void ActiveCoin()
    {
        foreach (var element in coins)
        {
            element.transform.rotation = Quaternion.Euler
            (
               rotatePrefab.transform.rotation.eulerAngles.x,
               rotatePrefab.transform.rotation.eulerAngles.y,
               rotatePrefab.transform.rotation.eulerAngles.z
            );

            element.GetComponent<MeshRenderer>().enabled = true;
        }

        itemCount = percentage.Rand(50, out flag);

        if (flag == true)
        {         
            coins[itemCount].SetActive(false);            

            GameObject item = itemManager.CloneItem();

            item.transform.SetParent(createPosition);

            item.transform.position = coins[itemCount].transform.position;
        }
    }

    public void NewPosition()
    {
        ActiveCoin();

        createPosition.gameObject.SetActive(true);

        RoadLine roadLine = (RoadLine)Random.Range(-1, 2);

        switch (roadLine)
        {
            case RoadLine.LEFT : createPosition.localPosition = new Vector3(-positionX, 0, 0);
                break;
            case RoadLine.MIDDLE : createPosition.localPosition = Vector3.zero;
                break;
            case RoadLine.RIGHT : createPosition.localPosition = new Vector3(+positionX, 0, 0);
                break;
        }
    }
}
