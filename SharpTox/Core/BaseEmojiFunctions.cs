using System;
using System.Runtime.InteropServices;

namespace SharpTox.Core
{
    public class BaseEmojiFunctions
    {
        const string dll = "base_emoji.dll";

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "bytes_to_emoji_string")]
        public static extern uint BytesToEmojiString(byte[] str, uint strLength, byte[] bytes, uint bytesLength);

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "emoji_string_to_bytes")]
        public static extern uint EmojiStringToBytes(byte[] bytes, uint bytesLength, byte[] str, uint strLength);
    }
}
