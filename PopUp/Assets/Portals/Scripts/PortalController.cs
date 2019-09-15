using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{ 
    private Transform BoPortal;

    public void PortalCheck(bool In)
    {
        if (In)
        {
            BoPortal = transform.Find("PortalIn(Clone)");
            if (BoPortal != null)
            {
                //PORTALOFFEFFECT
                Destroy(BoPortal.gameObject, 0);
            }
            else
            {
                BoPortal = transform.Find("PortalInBullet(Clone)");
                if (BoPortal != null)
                {
                    //BULLETOFFEFFECT
                    Destroy(BoPortal.gameObject, 0);
                }
            }
        }
        else
        {
            BoPortal = transform.Find("PortalOut(Clone)");
            if (BoPortal != null)
            {
                //PORTALOFFEFFECT
                Destroy(BoPortal.gameObject, 0);
            }
            else
            {
                BoPortal = transform.Find("PortalOutBullet(Clone)");
                if (BoPortal != null)
                {
                    //BULLETOFFEFFECT
                    Destroy(BoPortal.gameObject, 0);
                }
            }
        }
    }
}
