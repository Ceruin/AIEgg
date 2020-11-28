using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Egg : MonoBehaviour
{
    [SerializeField] private float power = 6;
    [SerializeField] private MoveDir moveDirection = MoveDir.Forward;

    // https://chao-island.com/wiki/Actions

    private enum Characteristics
    {
        //Evolution,
        //Alignment,
        //Intelligence,
        //Health,
        //Happiness,
        //Hunger,
        //Loneliness,
        //Age,
        //Color,
        //Shiny,
        //Outfits
    }

    private enum MovementType
    {
        //Sit,
        //Idle,
        //Crawl,
        //Walk,
        //Run,
        //Swim,
        //Fly,
        //Follow
    }

    private enum Action
    {
        Move,
        //Eat,
        //Play,
        //Breed,
        //Evolve,
        //Sleep,
    }

    private enum MoveDir
    {
        Forward,
        Left,
        Right,
        Backwards
    }

    private Rigidbody rb;
    private GameObject target;
    private NavMeshAgent agent;
    private Console console;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = FindObjectOfType<Voreable>().gameObject;
        agent = GetComponent<NavMeshAgent>();
        console = FindObjectOfType<Console>();

        StartCoroutine(PathToPoint());
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    IEnumerator PathToPoint()
    {
        while (true)
        {
            Vector3 point;
            float range = 10.0f;
            RandomPointOnNavMesh randomPointOnNavMesh = new RandomPointOnNavMesh();
            randomPointOnNavMesh.RandomPoint(transform.position, range, out point);
            if (target != null) agent.destination = point;
            PrintToConsoleAndGUI(point);

            yield return new WaitForSeconds(5);
        }
    }

    private void PrintToConsoleAndGUI<T>(T whatever)
    {
        print(whatever.ToString());
        console.UpdateGUI(whatever.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        {
            agent.destination = Vector3.zero;
            Destroy(target);
        }
    }
}

public class RandomPointOnNavMesh
{
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
