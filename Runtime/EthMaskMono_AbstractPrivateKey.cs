using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public abstract class EthMaskMono_AbstractPrivateKey : MonoBehaviour, IEthMaskPrivateKeyHolderGet
{
    public abstract string GetPrivateKey();
    public void GetPrivateKey(out string privateKey) { 
    
        privateKey = GetPrivateKey();
    }

    public void GetPublicAddress(out string publicAddress) { 
    
        MetaMaskSignUtility.GetPublicAddressFromPrivateKey(GetPrivateKey(), out publicAddress);
    }
}

