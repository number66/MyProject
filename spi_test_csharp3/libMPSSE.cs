using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FTD2XX_NET;

namespace spi_test_csharp3
{
    
    public enum SPI_CONFIG_OPTION_MODE
    {
        MODE0 = 0x00000000,
        MODE1 = 0x00000001,
        MODE2 = 0x00000002,
        MODE3 = 0x00000003
    }

    public enum SPI_CONFIG_OPTION_CS
    {
        DBUS3 = 0x00000000,
        DBUS4 = 0x00000004,
        DBUS5 = 0x00000008,
        DBUS6 = 0x0000000C,
        DBUS7 = 0x00000010,
    }
    /// 


    public enum SPI_CONFIG_OPTION_CS_ACTIVE
    {
        HIHG = 0x00000000,
        LOW = 0x00000020,
    }

    public enum SPI_TRANSFER_OPTIONS_SIZE_IN_
    {
        BYTES = 0x00000000,
        BITS = 0x00000001,
    }

    public enum SPI_TRANSFER_OPTIONS_CHIPSELECT_
    {
        ENABLE = 0x00000002,
        DISABLE = 0x00000004,
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct SPIChannelConfig
    {
       

        public UInt32 ClockRate;
        /// 
        public Byte LatencyTimer;
        /// 

        public UInt32 configOptions;
        /// 

        /// BIT7-0:Direction of thelines after SPI_InitChannel is called
        /// BIT16-8:Value of thelines after SPI_InitChannel is called
        /// BIT23-16:Direction of thelines after SPI_CloseChannel is called
        /// BIT32-24:Direction of thelines after SPI_InitChannel is called
        /// 

        public UInt32 Pins;
    

        private UInt16 Reserved;
    }

    

    [StructLayout(LayoutKind.Sequential)]
    public struct FT_DEVICE_LIST_INFO_NODE
    {
        public UInt32 Flags;
        public UInt32 Type;
        public UInt32 ID;
        public UInt32 LocId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] SerialNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] Description;
        public IntPtr ftHandle;
    }

    class libMPSSESPI
    {

        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Init_libMPSSE();

   
        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Cleanup_libMPSSE();

   

        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS FT_WriteGPIO(IntPtr fthandle, Byte dir, Byte value);

      
        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_GetNumChannels(ref UInt32 numChannels);

     
        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_OpenChannel(UInt32 index, ref IntPtr fthandle);


        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_CloseChannel(IntPtr fthandle);


        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_InitChannel(IntPtr fthandle, ref SPIChannelConfig config);

    

        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_GetChannelInfo(UInt32 index, ref FT_DEVICE_LIST_INFO_NODE chanInfo);

       

        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS FT_ReadGPIO(IntPtr fthandle, ref Byte value);

     
        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_Write(IntPtr ftHandle, ref Byte buffer, UInt32 sizeToTransfer, ref UInt32 sizeTransferred, UInt32 TransferOptions);

 
        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_Read(IntPtr fthandle, ref Byte buffer, UInt32 sizeToTransfer, ref UInt32 sizeTransferred, UInt32 transferOptions);

        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_ReadWrite(IntPtr fthandle, byte[] inbuffer, byte[] outbuffer,
            UInt32 sizeToTransfer, ref UInt32 sizeTransferred, UInt32 TransferOptions);

        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_IsBusy(IntPtr fthandle, ref bool state);


        [DllImport("libMPSSE.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern FTDI.FT_STATUS SPI_ChangeCS(IntPtr fthandle, UInt32 configOptions);
    }
}
