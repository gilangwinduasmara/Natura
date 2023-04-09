using UnityEngine;

[System.Serializable]
public class Drop {
    public RawResource resource;
    public Vector2 amount;
    public float dropChance = 0.5f;
    public Drop(RawResource resource, Vector2 amount, float dropChance) {
        this.resource = resource;
        this.amount = amount;
        this.dropChance = dropChance;
    }

    public RawResource GetResource(){
        return resource;
    }
}