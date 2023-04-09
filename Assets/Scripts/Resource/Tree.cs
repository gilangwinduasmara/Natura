// extends Resource.cs

// Path: Assets\Scripts\Reource.cs\Tree.cs

// Compare this snippet from Assets\Scripts\Resource.cs:

using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class Tree : Resource
{
    new void Gather()
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
            // Destroy the resource
            Destroy(gameObject);
        }
    }
}