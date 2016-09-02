using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScan.Util
{
   public class ICMPPacket
    {
        private Byte my_type;
        private Byte my_subCode;
        private UInt16 my_checkSum;
        private UInt16 my_identifier;
        private UInt16 my_sequenceNumber;
        private Byte[] my_data;

        public UInt16 CheckSum
        {
            get
            {
                return my_checkSum;
            }

            set
            {
                my_checkSum = value;
            }
        }

        public int CountByte(Byte [] buffer)
        {
            Byte[] b_type = new Byte[1] { my_type };
            Byte[] b_code = new Byte[1] { my_subCode };
            Byte[] b_cksum = BitConverter.GetBytes(my_checkSum);
            Byte[] b_id = BitConverter.GetBytes(my_identifier);
            Byte[] b_seq = BitConverter.GetBytes(my_sequenceNumber);
            int i = 0;
            Array.Copy(b_type, 0, buffer, i, b_type.Length);
            i += b_type.Length;
            Array.Copy(b_code, 0, buffer, i,b_code.Length);
            i += b_code.Length;
            Array.Copy(b_cksum, 0, buffer, i, b_cksum.Length);
            i += b_cksum.Length;
            Array.Copy(b_id, 0, buffer, i, b_id.Length);
            i += b_id.Length;
            Array.Copy(b_seq, 0, buffer, i, b_seq.Length);
            i += b_seq.Length;
            Array.Copy(my_data, 0, buffer, i, my_data.Length);
            i += my_data.Length;
            return i;
        }



        public ICMPPacket(Byte type, Byte subCode, UInt16 checkSum, UInt16 identifier, UInt16 sequenceNumber, int dataSize)
        {
            my_type = type;
            my_subCode = subCode;
            my_checkSum = checkSum;
            my_identifier = identifier;
            my_sequenceNumber = sequenceNumber;
            my_data = new Byte[dataSize];

            for (int i = 0; i < dataSize; i++)
            {
                my_data[i] = (byte)'M';
            
            }
        }


        public static UInt16 SumOfCheck(UInt16[] buffer)
        {
            int cksum = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                cksum += (int)buffer[i];
            }

            //将cksum的高16位和低16位相加，取反后得到校验和
            cksum = (cksum >> 16) + (cksum & 0xffff);
            cksum += (cksum >> 16);

            return (UInt16)(~cksum);
        }


    }
}
