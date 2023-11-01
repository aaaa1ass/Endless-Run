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

    [SerializeField] GameObject rotatePrefab;

    [SerializeField] GameObject coinPrefab;
    [SerializeField] List<GameObject> coins;

    void Start()
    {
        percentage = GetComponent<Percentage>();

        CreateCoin();

        Debug.Log(Resources.Load<Mesh>("Magnet").name);

        coins[coins.Count - 1].GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>("Batter C Low");
        coins[coins.Count - 1].GetComponent<MeshRenderer>().material = Resources.Load<Material>("Magnet Material");
    }

    private void CreateCoin()
    {
        for(int i = 0; i < createCount; i++)
        {
            GameObject coin = Instantiate (coinPrefab);

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
        }
    }

    public void NewPosition()
    {
        ActiveCoin();

        RoadLine roadLine = (RoadLine)Random.Range(-1, 2);

        switch (roadLine)
        {
            case RoadLine.LEFT : coinPrefab.transform.localPosition = new Vector3(-positionX, 0, 0);
                break;
            case RoadLine.MIDDLE : coinPrefab.transform.localPosition = Vector3.zero;
                break;
            case RoadLine.RIGHT : coinPrefab.transform.localPosition = new Vector3(+positionX, 0, 0);
                break;
        }
    }
}
