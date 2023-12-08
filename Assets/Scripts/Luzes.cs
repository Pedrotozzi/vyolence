using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Luzes : MonoBehaviour
{
    public Light2D Luz;
    public float tempoluz;
    public float tempoluz2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rotina());
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator rotina()
    {
       while (true)
       {
         ///lica e desliga
         yield return null;
        
         yield return new WaitForSeconds(tempoluz);
         Luz.enabled = false;
         yield return new WaitForSeconds(tempoluz2);
         Luz.enabled = true;
       }
}
    



}
