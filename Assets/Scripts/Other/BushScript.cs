using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : Vegetation
{
    void Update()
    {
        BouncePlant(0.05f,3,10);
    }
}
