public struct STRUCT_EthMaskPrivateKey : IEthMaskPrivateKeyHolderGet
{
    public string m_privateKey;
    
    public string GetPrivateKey()
    {
        return m_privateKey;
    }

    public void GetPrivateKey(out string privateKey)
    {
        privateKey = this.m_privateKey;
    }
}
