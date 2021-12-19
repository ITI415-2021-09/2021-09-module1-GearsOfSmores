using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    private void Start()
    {


        basketList = new List<GameObject>();

        for (int i=0; i<numBaskets; i++)
        {
             GameObject tBasketGO = Instantiate<GameObject>(basketPrefab); // Set new temp GameObject as basketPrefab
                Vector3 pos = Vector3.zero; // set its pos to (0,0,0)
             pos.y = basketBottomY + (basketSpacingY * i); // sets its pos.Y to -14 + 0 for the first basket 
             tBasketGO.transform.position = pos; // Transform its position in scene
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // create a temp AppleArray that will return an array existing with Apple GameObjects

        foreach( GameObject tGO in tAppleArray)
        {
            Destroy(tGO); 
        }

        // Destoy one of the baskets

        int basketIndex = basketList.Count - 1; // Get the index of the last Basket in basketList

        GameObject tBasketGo = basketList[basketIndex]; // Get a reference to that Basket GameObject

        basketList.RemoveAt(basketIndex); // Remove the Basket from the list and destroy the GameObject

        Destroy(tBasketGo);

        if ( basketList.Count == 0)

        for (int i=0; i<numBaskets; i++)

        {
            SceneManager.LoadScene("Main-ApplePicker");
        }
    }
   
}
