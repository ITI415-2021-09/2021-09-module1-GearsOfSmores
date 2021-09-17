using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject basketPrefab;
    public int nnumBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    private void Start()
    {
        for (int i=0; i<nnumBaskets; i++)
        {
             GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
                Vector3 pos = Vector3.zero;
             pos.y = basketBottomY + (basketSpacingY * i);
             tBasketGO.transform.position = pos;
        }
    }
}
