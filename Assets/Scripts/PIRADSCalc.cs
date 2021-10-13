using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIRADSCalc : MonoBehaviour
{
    // Calculate PIRADS score assuming PZ data
    public static int calcPzPIRADS (int T2, int DWI, int DCE)
    {
        int PIRADS = -1; // Output int
        //Check if no DWI or DCE first:
        if (DCE == -1 && DWI == -1)
        {
            Debug.Log("Check staging??");
        }
         else if (DWI == -1)
        { 
            //Edge case of insuf DWI, and T2W = 3
            if (T2 == 3)
            {
                if (DCE == 0)
                {
                    PIRADS = 3;
                } else
                {
                    PIRADS = 4;
                }
            } else
            {
                PIRADS = T2;
            }
        }
        //Edge case of insuf DCE
        else if (DCE == -1 )
        {
            PIRADS = DWI;
        } 
        else if (DCE == -1 && DWI == -1)
        {
            Debug.Log("Check staging??");
        } 
        //Normal case, with distinction when DWI = 3
        else if (!(DCE == -1 || DWI == -1))
        {
            if (DWI == 3)
            {
                if (DCE == 0)
                {
                    PIRADS = 3;
                } else
                {
                    PIRADS = 4;
                }
            } else
            {
                PIRADS = DWI;
            }
        } 
        else
        {
            Debug.Log("Unknown condition, resetting to -1 output.");
        }
        return PIRADS;
    }

    public static int calcTzPIRADS (int T2, int DWI, int DCE)
    {
        int PIRADS = -1; // Output int
        //Check case where no DWI or DCE first
        if (DCE == -1 && DWI == -1)
        {
            Debug.Log("Check staging??");
        }
        else if (DWI == -1)
        {
            //Edge case of insuf DWI, and T2W = 3, same as PZ readout
            if (T2 == 3)
            {
                if (DCE == 0)
                {
                    PIRADS = 3;
                }
                else
                {
                    PIRADS = 4;
                }
            }
            else
            {
                PIRADS = T2;
            }
        } 
        else if (DCE == -1)
        {
            //Test TZ DCE exceptions in 2 T2 and 3 T2
            if (T2 == 2)
            {
                if (DWI <= 3)
                {
                    PIRADS = 2;
                } 
                else
                {
                    PIRADS = 3;
                }
            } 
            else if (T2 == 3)
            {
                if (DWI == 5)
                {
                    PIRADS = 4;
                } 
                else
                {
                    PIRADS = 3;
                }
            }
            else
            {
                PIRADS = T2;
            }
        }

        //With all data known, handle exceptions on 2 and 3 T2W
        else if (!(DCE == -1 && DWI == -1))
        {
            if (T2 == 2)
            {
                if (DWI >= 3)
                {
                    PIRADS = 2;
                } 
                else
                {
                    PIRADS = 3;
                }
            } 
            else if (T2 = 3)
            {
                if (DWI == 5)
                {
                    PIRADS = 4;
                }
                else
                {
                    PIRADS = 3;
                }
            }
            else
            {
                PIRADS = T2;
            }
        }
        else
        {
            Debug.Log("Unknown condition, resetting to -1 output.");
        }
    }
}
