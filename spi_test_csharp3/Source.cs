using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTD2XX_NET;
using System.IO;

namespace spi_test_csharp3
{
    class Source
    {
            const uint BufferSize = 64000;
            const uint Packages = 1;
            byte[] tx_buffer = new byte[1];
            byte[] rx_buffer = new byte[1];
            byte[] tx_buffer_com = new byte[1];
            byte[] rx_buffer_com = new byte[1];
            byte[] tx_buffer1 = new byte[BufferSize];
            byte[] rx_buffer1 = new byte[BufferSize];
            byte[] rx_buffer2 = new byte[BufferSize * Packages];

            
            UInt32 options = 0; 
            UInt32 transferCount = 0;
            IntPtr ft232handle = IntPtr.Zero;
            UInt32 chan = 0;
            FT_DEVICE_LIST_INFO_NODE ftdevlist = new FT_DEVICE_LIST_INFO_NODE();
            FTDI.FT_STATUS FTstat = FTDI.FT_STATUS.FT_OK;
            
            public bool OpenFtdi()
            {
                libMPSSESPI.Cleanup_libMPSSE();
                libMPSSESPI.Init_libMPSSE();
                
                FTstat = libMPSSESPI.SPI_GetNumChannels(ref chan);
                if (FTstat != FTDI.FT_STATUS.FT_OK)
                {
                    libMPSSESPI.Cleanup_libMPSSE();
                }

                FTstat = libMPSSESPI.SPI_GetChannelInfo(0, ref ftdevlist);
                if (FTstat != FTDI.FT_STATUS.FT_OK)
                {
                    libMPSSESPI.Cleanup_libMPSSE();
                }

                FTstat = libMPSSESPI.SPI_OpenChannel(0, ref ft232handle);
                if (FTstat != FTDI.FT_STATUS.FT_OK)
                {
                    libMPSSESPI.Cleanup_libMPSSE();
                }

                if (ConfigureForMPSSE() != true)
                {
                    return false;
                }

               

                return true;
            }
            
             private bool ConfigureForMPSSE()
             {
                SPIChannelConfig channelConf = new SPIChannelConfig();

                channelConf.ClockRate = 30*1000000;
                channelConf.LatencyTimer = 1;
                channelConf.configOptions =(UInt32)(SPI_CONFIG_OPTION_MODE.MODE0) | (UInt32)(SPI_CONFIG_OPTION_CS.DBUS3) | (UInt32)(SPI_CONFIG_OPTION_CS_ACTIVE.LOW);
                channelConf.Pins = 0;

                FTstat = libMPSSESPI.SPI_InitChannel(ft232handle, ref channelConf);
                if (FTstat != FTDI.FT_STATUS.FT_OK)
                {
                    libMPSSESPI.Cleanup_libMPSSE();
                }

                 options = (UInt32)(SPI_TRANSFER_OPTIONS_SIZE_IN_.BYTES) | (UInt32)(SPI_TRANSFER_OPTIONS_CHIPSELECT_.ENABLE) | (UInt32)(SPI_TRANSFER_OPTIONS_CHIPSELECT_.DISABLE);
                 return true;
             }
            
           
            public byte[] loadImage()
            {

            for (int i = 1; i <= Packages; i++)
            {
                tx_buffer_com[0] = (byte)i;
              
                if (FTstat == FTDI.FT_STATUS.FT_OK)
                    FTstat = libMPSSESPI.SPI_ReadWrite(ft232handle, rx_buffer_com, tx_buffer_com, 1, ref transferCount, options);       

                if (FTstat == FTDI.FT_STATUS.FT_OK)
                    FTstat = libMPSSESPI.SPI_ReadWrite(ft232handle, rx_buffer1, tx_buffer1, BufferSize, ref transferCount, options);

                if (FTstat == FTDI.FT_STATUS.FT_OK)
                    for (int j = 0; j < BufferSize; j++)
                        rx_buffer2[(i - 1) * BufferSize + j] = rx_buffer1[j];
            }
         
            return rx_buffer2;
         }
            
            
        public void Close()
        {
            FTstat = libMPSSESPI.SPI_CloseChannel(ft232handle);
            if (FTstat == FTDI.FT_STATUS.FT_OK)
            {
                libMPSSESPI.Cleanup_libMPSSE();
            }
        }   
            

            
    }
}
