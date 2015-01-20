#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

namespace SharpTox.Core
{
    public class ToxDelegates
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackTypingChangeDelegate(IntPtr tox, int friendNumber, byte isTyping, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackUserStatusDelegate(IntPtr tox, int friendNumber, ToxUserStatus status, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackStatusMessageDelegate(IntPtr tox, int friendNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] newStatus, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackNameChangeDelegate(IntPtr tox, int friendNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] newName, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackFriendActionDelegate(IntPtr tox, int friendNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] action, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackFriendMessageDelegate(IntPtr tox, int friendNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] message, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackConnectionStatusDelegate(IntPtr tox, int friendNumber, byte status, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackFriendRequestDelegate(IntPtr tox, [MarshalAs(UnmanagedType.LPArray, SizeConst = ToxConstants.ClientIdSize)] byte[] publicKey, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] message, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackFileDataDelegate(IntPtr tox, int friendNumber, byte fileNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] data, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackFileControlDelegate(IntPtr tox, int friendNumber, byte receiveSend, byte fileNumber, byte controlType, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] data, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackFileSendRequestDelegate(IntPtr tox, int friendNumber, byte fileNumber, ulong fileSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] filename, ushort filenameLength, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackReadReceiptDelegate(IntPtr tox, int friendNumber, uint receipt, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CallbackPacketDelegate(IntPtr tox, int friendNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] data, uint length, IntPtr obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackAvatarInfoDelegate(IntPtr tox, int friendNumber, byte format, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = ToxConstants.ToxHashLength)] byte[] hash, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackAvatarDataDelegate(IntPtr tox, int friendNumber, byte format, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = ToxConstants.ToxHashLength)] byte[] hash, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, uint dataLength, IntPtr userData);




        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupMessageDelegate(IntPtr tox, int groupNumber, int peerNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] message, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupActionDelegate(IntPtr tox, int groupNumber, int peerNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] action, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupPrivateMessageDelegate(IntPtr tox, int groupNumber, uint peerNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] message, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupOpCertificateDelegate(IntPtr tox, int groupNumber, uint sourcePeerNumber, uint targetPeerNumber, ToxGroupOpCertificate cert, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupNickChangeDelegate(IntPtr tox, int groupNumber, uint peerNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] newNick, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupTopicChangeDelegate(IntPtr tox, int groupNumber, uint peerNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] topic, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupPeerJoinDelegate(IntPtr tox, int groupNumber, uint peerNumber, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupPeerExitDelegate(IntPtr tox, int groupNumber, uint peerNumber, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] partMessage, ushort length, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupSelfJoinDelegate(IntPtr tox, int groupNumber, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupPeerlistUpdateDelegate(IntPtr tox, int groupNumber, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupSelfTimeoutDelegate(IntPtr tox, int groupNumber, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackGroupRejectedDelegate(IntPtr tox, int groupNumber, ToxGroupJoinRejectedReason reason, IntPtr userData);
    }
}

#pragma warning restore 1591