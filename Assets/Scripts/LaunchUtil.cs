using UnityEngine;

public static class LaunchUtil
{
    /// <summary>
    /// 発射するitemに力を加える
    /// </summary>
    /// <param name="item">発射するもの</param>
    /// <param name="vector">発射する方向</param>
    /// <param name="rotation">vectorを基準に回転する角度</param>
    /// <param name="power">発射の勢い</param>
    /// <param name="torquePower">itemの回転</param>
    public static void LaunchItem(ref Transform item, float power, Vector2 vector, float rotation = 0, float torquePower = 0)
    {
        //発射方向を設定
        Vector2 launchVector = Quaternion.Euler(0, 0, rotation) * vector.normalized;

        //Rigidbody取り出す
        Rigidbody2D r = item.gameObject.GetComponent<Rigidbody2D>();
        if (r == null)
        {
            r = item.gameObject.AddComponent<Rigidbody2D>();
        }

        //力を加える
        r.AddForce(launchVector * power, ForceMode2D.Impulse);

        //回転を加える
        r.AddTorque(torquePower, ForceMode2D.Impulse);
    }
}
