using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLauncher : Launcher
{
    [SerializeField, Range(0, 5)]
    public Vector2 translateRange = new Vector2(1, 1);

    [SerializeField, Range(0, 10)]
    public int powerPlusRange = 10;

    [SerializeField, Range(0, 90)]
    public int rotateRange = 30;

    [SerializeField, Range(0, 90)]
    public float torqueRange = 1;

    public new void Fire()
    {

        Vector2 pos;
        float pow, rot, torPow;
        RandomParameter(out pos, out pow, out rot, out torPow);

        Transform newItem = Object.Instantiate(item, pos, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))), transform).transform;
        LaunchUtil.LaunchItem(ref newItem, pow, transform.up, rot, torPow);
    }

    private void RandomParameter(out Vector2 pos, out float pow, out float rot, out float torPow)
    {
        Vector2 minPosition = (Vector2)transform.position - translateRange * 0.5f;
        Vector2 maxPosition = (Vector2)transform.position + translateRange * 0.5f;
        pos = new Vector2(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y));

        pow = Random.Range(power, power + powerPlusRange);

        int rev = Random.Range(-1f, 1f) < 0 ? -1 : 1;
        rot = rotation + Random.Range(0, rotateRange) * rev;

        rev = Random.Range(-1f, 1f) < 0 ? -1 : 1;
        torPow = torquePower + Random.Range(0, torqueRange) * rev;
    }
}
