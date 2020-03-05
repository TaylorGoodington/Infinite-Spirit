using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInformation : MonoBehaviour
{
    public short modelId;
    public byte characterId;

    public ModelInformation(short objectModelId, byte id, GameObject model)
    {
        modelId = objectModelId;
        characterId = id;
    }
}