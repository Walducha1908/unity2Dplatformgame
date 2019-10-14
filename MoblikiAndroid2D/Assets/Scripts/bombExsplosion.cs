using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExsplosion : MonoBehaviour
{
    public void bum()
    {
        this.gameObject.SetActive(false);

        GameObject toKill = GameObject.Find("/spikesv3(Clone)");
        if(toKill != null)
            Destroy(toKill.gameObject);

        toKill = GameObject.Find("/spikesv3(Clone)");
        if (toKill != null)
            Destroy(toKill.gameObject);


        toKill = GameObject.Find("/spikesv2(Clone)");
        if (toKill != null)
            Destroy(toKill.gameObject);

        toKill = GameObject.Find("/spikesv2(Clone)");
        if (toKill != null)
            Destroy(toKill.gameObject);

        toKill = GameObject.Find("/spikes(Clone)");
        if (toKill != null)
            Destroy(toKill.gameObject);

        toKill = GameObject.Find("/spikes(Clone)");
        if (toKill != null)
            Destroy(toKill.gameObject);
    }
}
