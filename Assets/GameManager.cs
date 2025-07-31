using UnityEngine;
public enum Level { None, Normal, Hard, Expert };
public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab = null;
    [Space]
    public GameObject NormalLevel = null;
    public GameObject HardLevel = null;
    public GameObject ExpertLevel = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        GameObject player = Instantiate(PlayerPrefab, transform);
        player.transform.position = new Vector3(0, 0, 0);
    }
}