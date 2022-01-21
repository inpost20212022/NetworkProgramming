using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;

namespace ModbusMaster1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String ipAddr = "127.0.0.1";
            int port = 1502;

            TcpClient tcpClient = new TcpClient();
            tcpClient.BeginConnect(ipAddr, port, null, null);

            //tworzymy Modbus Master
            ModbusIpMaster master = ModbusIpMaster.CreateIp(tcpClient);

            ushort startRef = 0; ushort noOfRefs = 5;
            bool[] arrCoils = master.ReadCoils(startRef, noOfRefs);
            Console.WriteLine(arrCoils);

            //zapis do Coils
            master.WriteMultipleCoils(startRef, new bool[] { true, false, true, false, true });

            bool[] arrInputs = master.ReadInputs(startRef, noOfRefs);
            Console.WriteLine(arrInputs);

            ushort[] arrIR =  master.ReadInputRegisters(startRef, noOfRefs);
            Console.WriteLine(arrIR);
            //master.WriteSingleRegister((ushort)(startRef + (ushort)4), 123);
            
            master.WriteMultipleRegisters(startRef, new ushort[] { 99, 100, 101 });
            arrIR = master.ReadHoldingRegisters(startRef, 3);
            Console.WriteLine(arrIR[0]);
        }
    }
}
