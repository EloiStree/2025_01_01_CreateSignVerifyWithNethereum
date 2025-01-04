public class EthMaskMono_PrivateKeyInInspector : EthMaskMono_AbstractPrivateKey
{
    [System.Serializable]
    public class DontSow
    {
        public string m_privateKey = "";
    }
    public DontSow m_dontShow;

    public override string GetPrivateKey()
    {
        return m_dontShow.m_privateKey;
    }
}
