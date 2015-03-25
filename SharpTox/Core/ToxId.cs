using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace SharpTox.Core
{
    public class ToxId
    {
        private byte[] _id;

        public ToxKey PublicKey
        {
            get
            {
                byte[] key = new byte[ToxConstants.PublicKeySize];
                Array.Copy(_id, 0, key, 0, ToxConstants.PublicKeySize);

                return new ToxKey(ToxKeyType.Public, key);
            }
        }

        public byte[] Bytes
        {
            get
            {
                return _id;
            }
        }

        public uint Nospam
        {
            get
            {
                byte[] nospam = new byte[4];
                Array.Copy(_id, 32, nospam, 0, 4);

                return BitConverter.ToUInt32(nospam, 0);
            }
        }

        public ushort Checksum
        {
            get
            {
                byte[] checksum = new byte[2];
                Array.Copy(_id, 36, checksum, 0, 2);

                return BitConverter.ToUInt16(checksum, 0);
            }
        }

        public ToxId(string id)
            : this(ToxTools.StringToHexBin(id))
        {
        }

        public ToxId(byte[] id)
        {
            _id = id;

            if (CalcChecksum(_id, 36) != Checksum)
                throw new Exception("This Tox ID is invalid");
        }

        public static bool operator ==(ToxId id1, ToxId id2)
        {
            if (object.ReferenceEquals(id1, id2))
                return true;

            if ((object)id1 == null ^ (object)id2 == null)
                return false;

            return (id1._id.SequenceEqual(id2._id));
        }

        public static bool operator !=(ToxId id1, ToxId id2)
        {
            return !(id1 == id2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            ToxId id = obj as ToxId;
            if ((object)id == null)
                return false;

            return this == id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return ToxTools.HexBinToString(_id);
        }

        public string ToEmojiString()
        {
            byte[] bytes = new byte[ToxConstants.AddressSize * 4];

            int length = (int)BaseEmojiFunctions.BytesToEmojiString(bytes, (uint)bytes.Length, _id, (uint)_id.Length);
            if (length == 0)
                return string.Empty;

            return Encoding.UTF8.GetString(bytes, 0, length);
        }

        public static ToxId FromEmojiString(string str)
        {
            byte[] bytes = new byte[ToxConstants.AddressSize];
            byte[] stringBytes = Encoding.UTF8.GetBytes(str);

            int length = (int)BaseEmojiFunctions.EmojiStringToBytes(bytes, (uint)bytes.Length, stringBytes, (uint)stringBytes.Length);
            if (length != bytes.Length)
                return null;

            return new ToxId(bytes);
        }

        public static bool IsValid(string id)
        {
            return IsValid(ToxTools.StringToHexBin(id));
        }

        public static bool IsValid(byte[] id)
        {
            try
            {
                byte[] checksum = new byte[2];
                ushort check;

                Array.Copy(id, 36, checksum, 0, 2);
                check = BitConverter.ToUInt16(checksum, 0);

                return CalcChecksum(id, 36) != check;
            }
            catch
            {
                return false;
            }
        }

        private static ushort CalcChecksum(byte[] address, int length)
        {
            byte[] checksum = new byte[2];

            for (uint i = 0; i < length; i++)
                checksum[i % 2] ^= address[i];

            return BitConverter.ToUInt16(checksum, 0);
        }
    }
}
