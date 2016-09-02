using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using MScan.Util;

namespace MScan
{
    public partial class frmPing : Form
    {
        public frmPing()
        {
            InitializeComponent();
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            listBoxPing.Items.Clear();
            string host = txtBoxPing.Text;
            if (host == "")
            {
                MessageBox.Show("IP地址不能为空");
                return;
            }

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);

            socket.ReceiveTimeout = 2000;
            IPHostEntry iphostentry;
            try
            {
                iphostentry = Dns.GetHostEntry(host);
            }
            catch (Exception)
            {
                listBoxPing.Items.Add("无法识别主机!");
                return;
            }

            EndPoint hostpoint = (EndPoint)new IPEndPoint(iphostentry.AddressList[0], 0);

            int DataSize = 4;
            int PacketSize = DataSize + 8;
            const int Icmp_type = 8;

            ICMPPacket packet = new ICMPPacket(Icmp_type, 0, 0, 45, 0, DataSize);

            Byte[] Buffer = new Byte[PacketSize];
            int index = packet.CountByte(Buffer);

            if (index != PacketSize)
            {
                listBoxPing.Items.Add("报文错误!");
                return;
            }

            int CKsum_buffer_length = (int)Math.Ceiling((Double)index / 2);
            UInt16 [] CKsum_buffer = new UInt16[CKsum_buffer_length];
            int Icmp_header_buffer_index = 0;
            for (int i = 0; i < CKsum_buffer_length; i++)
            {
                CKsum_buffer[i] = BitConverter.ToUInt16(Buffer, Icmp_header_buffer_index);
                Icmp_header_buffer_index += 2;
            }

            packet.CheckSum = ICMPPacket.SumOfCheck(CKsum_buffer);
            Byte[] SendData = new Byte[PacketSize];
            index = packet.CountByte(SendData);

            if (index != PacketSize)
            {
                listBoxPing.Items.Add("报文出错");
                return;
            }

            int pingNum = 4;
            listBoxPing.Items.Add("正在ping  " + host + "  [" + iphostentry.AddressList[0].ToString() + "]");
            for (int i = 0; i < 4; i++)
            {
                int Nbytes = 0;
                int startTime = Environment.TickCount;
                try
                {
                    Nbytes = socket.SendTo(SendData, PacketSize, SocketFlags.None, hostpoint);
                }
                catch (Exception)
                {
                    listBoxPing.Items.Add("报文传送失败!");
                    return;
                }

                Byte[] ReceiveData = new Byte[256];
                Nbytes = 0;
                int TimeConsume = 0;
                while (true)
                {
                    try
                    {
                        Nbytes = socket.ReceiveFrom(ReceiveData, 256, SocketFlags.None, ref hostpoint);
                    }
                    catch (Exception)
                    {
                        listBoxPing.Items.Add("响应超时!");
                        break;
                    }

                    if (Nbytes>0)
                    {
                        TimeConsume = System.Environment.TickCount - startTime;

                        if (TimeConsume < 1)
                        {
                            listBoxPing.Items.Add("reply from:  " + iphostentry.AddressList[0].ToString() + "  Send:  " + (PacketSize + 20).ToString() + "  time<1ms;bytes Received  " + Nbytes.ToString());
                        }
                        else
                        {
                            listBoxPing.Items.Add("reply from:  " + iphostentry.AddressList[0].ToString() + "  Send:  " + (PacketSize + 20).ToString() + "  In  " + TimeConsume.ToString() + "ms;bytes Received  " + Nbytes.ToString());
                        }
                        break;
                    }
                }
            }

            socket.Close();

        }
    }
}
