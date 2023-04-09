using UnityEngine;

public class RawResource : MonoBehaviour
{
    public string resourceName = "Wood";

    // assign gameobject based on resource name

    public GameObject resource;

    public RawResource()
    {
        // Debug.Log("New Raw Resource created");
        // // assign gameobject based on resource name
        // resource = GameObject.Find("Wood").gameObject;
        // // Debug.Log("Raw Resource created");
        // // check if resource is null
        // if (resource.gameObject == null)
        // {
        //     Debug.Log("Resource is null");
        // }else {
        //     Debug.Log("Resource is not null");
        //     Debug.Log("Object name: " + resource.gameObject.name);
        // }
    
    }

    public GameObject GetResource()
    {
        if(resource == null){
            throw new System.Exception("Resource is null");
        }
        return resource;
    }

    void Update(){
        // check if nearby player
        // if yes, move towards player
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (player != null)
        {
             if (Vector2.Distance(player.transform.position, transform.position) < 1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.1f);
            }
        }
    }

}