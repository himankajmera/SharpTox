using System;

namespace SharpTox.Core
{
    public class ToxGroupInviteKey
    {
        private byte[] _key;

        public byte[] Bytes
        {
            get { return _key; }
        }

        public ToxGroupInviteKey(byte[] key)
        {
            _key = key;
        }

        public override string ToString()
        {
            return ToxTools.HexBinToString(_key);
        }
    }
}
