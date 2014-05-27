﻿#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

namespace SharpTox
{
    public static class ToxAvFunctions
    {
        const string dll = "libtoxav-0";

        #region Functions
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern void toxav_kill(IntPtr toxav);
        public static void Kill(IntPtr toxav)
        {
            toxav_kill(toxav);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toxav_new(IntPtr tox, int max_calls);
        public static IntPtr New(IntPtr tox, int max_calls)
        {
            return toxav_new(tox, max_calls);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int toxav_prepare_audio_frame(IntPtr tox, int call_index, byte[] dest, int dest_max, ushort[] frame, int frame_size);
        public static int PrepareAudioFrame(IntPtr tox, int call_index, byte[] dest, int dest_max, ushort[] frame, int frame_size)
        {
            return toxav_prepare_audio_frame(tox, call_index, dest, dest_max, frame, frame_size);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_call(IntPtr toxav, ref int call_index, int friend_number, ToxAvCallType call_type, int ringing_seconds);
        public static ToxAvError Call(IntPtr toxav, ref int call_index, int friend_number, ToxAvCallType call_type, int ringing_seconds)
        {
            return toxav_call(toxav, ref call_index, friend_number, call_type, ringing_seconds);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_hangup(IntPtr toxav, int call_index);
        public static ToxAvError Hangup(IntPtr toxav, int call_index)
        {
            return toxav_hangup(toxav, call_index);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_answer(IntPtr toxav, int call_index, ToxAvCallType call_type);
        public static ToxAvError Answer(IntPtr toxav, int call_index, ToxAvCallType call_type)
        {
            return toxav_answer(toxav, call_index, call_type);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_reject(IntPtr toxav, int call_index, string reason);
        public static ToxAvError Reject(IntPtr toxav, int call_index, string reason)
        {
            return toxav_reject(toxav, call_index, reason);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_cancel(IntPtr toxav, int call_index, int friend_number, string reason);
        public static ToxAvError Cancel(IntPtr toxav, int call_index, int friend_number, string reason)
        {
            return toxav_cancel(toxav, call_index, friend_number, reason);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_stop_call(IntPtr toxav, int call_index);
        public static ToxAvError StopCall(IntPtr toxav, int call_index)
        {
            return toxav_stop_call(toxav, call_index);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_prepare_transmission(IntPtr toxav, int call_index, ref ToxAvCodecSettings settings, int video_supported);
        public static ToxAvError PrepareTransmission(IntPtr toxav, int call_index, ToxAvCodecSettings settings,  bool video_supported)
        {
            return toxav_prepare_transmission(toxav, call_index, ref settings, video_supported ? 1 : 0);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_kill_transmission(IntPtr toxav, int call_index);
        public static ToxAvError KillTransmission(IntPtr toxav, int call_index)
        {
            return toxav_kill_transmission(toxav, call_index);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_recv_video(IntPtr toxav, int call_index, IntPtr output);
        public static ToxAvError ReceiveVideo(IntPtr toxav, int call_index, IntPtr output)
        {
            return toxav_recv_video(toxav, call_index, output);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int toxav_recv_audio(IntPtr toxav, int call_index, int frame_size, [Out] short[] dest);
        public static int ReceiveAudio(IntPtr toxav, int call_index, int frame_size, short[] dest)
        {
            return toxav_recv_audio(toxav, call_index, frame_size, dest);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_send_video(IntPtr toxav, int call_index, IntPtr input);
        public static ToxAvError SendVideo(IntPtr toxav, int call_index, IntPtr input)
        {
            return toxav_send_video(toxav, call_index, input);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvError toxav_send_audio(IntPtr toxav, int call_index, byte[] frame, int frame_size);
        public static ToxAvError SendAudio(IntPtr toxav, int call_index, ref byte[] frame, int frame_size)
        {
            return toxav_send_audio(toxav, call_index, frame, frame_size);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern ToxAvCallType toxav_get_peer_transmission_type(IntPtr toxav, int call_index, int friend_number);
        public static ToxAvCallType GetPeerTransmissionType(IntPtr toxav, int call_index, int friend_number)
        {
            return toxav_get_peer_transmission_type(toxav, call_index, friend_number);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int toxav_get_peer_id(IntPtr toxav, int call_index, int friend_number);
        public static int GetPeerID(IntPtr toxav, int call_index, int peer)
        {
            return toxav_get_peer_id(toxav, call_index, peer);
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int toxav_capability_supported(IntPtr toxav, int call_index, ToxAvCapabilities capability);
        public static bool CapabilitySupported(IntPtr toxav, int call_index, ToxAvCapabilities capability)
        {
            return toxav_capability_supported(toxav, call_index, capability) == 1;
        }

        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toxav_get_tox(IntPtr toxav);
        public static IntPtr GetTox(IntPtr toxav)
        {
            return toxav_get_tox(toxav);
        }
        #endregion

        #region Callbacks
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr toxav_register_callstate_callback(ToxAvDelegates.CallstateCallback callback, ToxAvCallbackID id, IntPtr userdata);
        public static IntPtr RegisterCallstateCallback(ToxAvDelegates.CallstateCallback callback, ToxAvCallbackID id)
        {
            return toxav_register_callstate_callback(callback, id, IntPtr.Zero);
        }
        #endregion
    }
}

#pragma warning restore 1591