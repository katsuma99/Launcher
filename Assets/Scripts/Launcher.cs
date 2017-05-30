using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject item;

    [SerializeField, Range(0, 10)]
    public int power = 1;

    [SerializeField, Range(-90, 90)]
    public int rotation = 0;

    [SerializeField, Range(-90, 90)]
    public float torquePower = 0;

    public void Fire()
    {
        Transform newItem = Object.Instantiate(item, transform.position, Quaternion.identity, transform).transform;
        LaunchUtil.LaunchItem(ref newItem, power, transform.up, rotation, torquePower);
    }

}

