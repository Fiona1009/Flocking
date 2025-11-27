using UnityEngine;
using System.Collections.Generic;

public class FishTank : MonoBehaviour
{
    [SerializeField]
    private Vector2 Size = new Vector2(16f, 9f);

    [SerializeField]
    private GameObject fishPrefab = null;

    [Range(0, 300)]
    [SerializeField]
    private int SpawningCount;

    [SerializeField]
    private Camera myCamera;

    private List<Fish> fisheslist = new List<Fish>();

    private void Start()
    {
        for (int i = 0; i < SpawningCount; i++)
        {
            Createfish(Vector3.zero);
        }
    }

    private void Createfish(Vector3 worldPosition)
    {
        GameObject fishInstance = Instantiate(fishPrefab, transform);
        fishInstance.gameObject.name = $"Fish {System.Guid.NewGuid()}";
        fishInstance.transform.position = worldPosition;
        // fishes[i] = fishInstance.GetComponent<Fish>();
        fisheslist.Add(fishInstance.GetComponent<Fish>());
    }

    private void LateUpdate()
    {
        // ** Add fish based on Player mouse ? **
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse position
            Vector3 mousePosition = Input.mousePosition;

            // Project into world
            mousePosition = myCamera.ScreenToWorldPoint(mousePosition);

            // Instantiate new fish
            Createfish(mousePosition);
        }

        // ** Remove fish **
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse position
            Vector3 mousePosition = Input.mousePosition;

            // Project into world
            mousePosition = myCamera.ScreenToWorldPoint(mousePosition);

            // Get list of fishes
            Collider2D[] fishesThatWillBeDestroyed = Physics2D.OverlapCircleAll(mousePosition, 1f);

            // Destroy
            for (int i = 0; 1 <= fishesThatWillBeDestroyed.Length; i++)
            {
                Collider2D fishThatWillBeDestroyed = fishesThatWillBeDestroyed[i];
                //      Fish removedFish = fishPrefab.GameObject.GetComponent<Fish>();

                // Remove from list
                        // Destroy(removedFish.gameObject); 
            }

        }


        // Loop around out of bound fishes.
        int fishesCount = fisheslist.Count;
        for (int i = 0; i < fishesCount; i++)
        {
            Fish fish = fisheslist[i];
            Vector3 position = fish.transform.localPosition;

            // Left border?
            if (position.x < -Size.x * 0.5f)
            {
                position.x += Size.x;
            }
            // Right border?
            else if (position.x > Size.x * 0.5f)
            {
                position.x -= Size.x;
            }

            // Top border?
            if (position.y > Size.y * 0.5f)
            {
                position.y -= Size.y;
            }
            // Bottom border?
            if (position.y <  -Size.y * 0.5f)
            {
                position.y += Size.y;
            }

            fish.transform.localPosition = position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, Size);
    }
}