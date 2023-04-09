using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public float gatherRadius = 0.5f; // The radius at which the player can gather the resource
    public string resourceName = "Tree"; // The name of the resource

    public float health = 100f; // The health of the resource
    [SerializeField]
    public List<Drop> drops = new List<Drop>();
    
    public RawResource wood;
    private TextMesh label;


    void Start(){
        Debug.Log("Resource created");
        // set Tag to Resource
        gameObject.tag = "Resource";
        // add a text label
        // the Label is sibling of the Resource
        label = gameObject.AddComponent<TextMesh>();
        // label.text = resourceName;
    }

    // public Drop[] GetDrops()
    // {
    //     // Define what drops the resource has
    //     Drop[] drops = new Drop[1];
    //     Vector2 amount = new Vector2(1, 3);
    //     drops[0] = new Drop(wood, amount, 1f);
    //     return drops;
    // }

    public void DropResource(){
        // Get the drops from the resource
        Debug.Log("Drops: " + drops.Count);
        // Loop through the drops
        foreach (Drop drop in drops)
        {
            // Check if the drop should be dropped
            if (UnityEngine.Random.Range(0f, 1f) <= drop.dropChance)
            {
                // Get the amount of the drop
                int amount = UnityEngine.Random.Range((int)drop.amount.x, (int)drop.amount.y);
                // Drop the resource
                for (int i = 0; i < amount; i++)
                {
                    Debug.Log("Dropping " + drop.resource.resourceName);
                    // Instantiate the resource
                    RawResource resource = drop.GetResource();
                    GameObject resourceObject = Instantiate(resource.gameObject, transform.position, Quaternion.identity);
                    // Move the resource in a random position without force
                    resourceObject.transform.Translate(UnityEngine.Random.Range(-.8f, .8f), UnityEngine.Random.Range(-.8f, .8f), 0);
                    Debug.Log("Dropped " + drop.resource.resourceName);
                }
            }
        }
    }

    private Boolean IsPlayerCloseEnough()
    {
        // Check for any colliders in a circle around the resource
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, gatherRadius);

        // Loop through the colliders to see if any of them belong to the player
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                // The player is close enough to gather the resource
                return true;
            }
        }
        return false;
    }

    private Boolean IsMouseHovering()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider = Physics2D.OverlapPoint(mousePosition);
        if (collider != null && collider.CompareTag("Resource"))
        {
            return true;
        }
        return false;
    }

    

    protected void Gather()
    {
        // Define what happens when the resource is gathered
        // Debug.Log("Gathered " + resourceName);
        // Destroy(gameObject); // Destroy the resource object

        // Get the player object
        GameObject playerObject = GameObject.FindWithTag("Player");
        // Get the Player script from the player object
        Player player = playerObject.GetComponent<Player>();
        // Get the axe damage from the player
        float axeDamage = player.GetAxeDamage();
        // Reduce the health of the resource
        health -= axeDamage;
        // Check if the resource is dead
        if (health <= 0)
        {
            // Drop the resource
            DropResource();
            // Destroy the resource
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(IsPlayerCloseEnough() && IsMouseHovering()){
            // set the color of the resource to green
            GetComponent<SpriteRenderer>().color = Color.green;
            if (Input.GetMouseButtonDown(0))
            {
                Gather();
            }
        }else{
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
