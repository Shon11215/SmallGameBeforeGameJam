using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxHp = 100;
    public int currHp = 100;
    void Start()
    {
        currHp = maxHp;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
