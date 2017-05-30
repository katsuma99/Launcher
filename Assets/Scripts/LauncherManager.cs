using UnityEngine;

public class LauncherManager : MonoBehaviour
{
    public int mItemCountMax = 10;
    public float mTimeOut = 1;
    float mTimeElapsed = 0;

    void Update()
    {
        mTimeElapsed += Time.deltaTime;
        if (mTimeElapsed >= mTimeOut)
        {
            foreach (Transform launcher in transform)
            {
                launcher.GetComponent<Launcher>().Fire();
                if (launcher.childCount > mItemCountMax)
                {
                    Destroy(launcher.GetChild(0).gameObject);
                }
            }
            mTimeElapsed = 0.0f;
        }
    }
}
