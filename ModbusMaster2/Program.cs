using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;

namespace ModbusMaster2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModbusClient modbusClient = new ModbusClient("127.0.0.1", 1502);

            //poniżej konfiguracja dla Modbus RTU
            //ModbusClient modbusClient = new ModbusClient("COM3");
            //modbusClient.UnitIdentifier = 1;
            //modbusClient.Baudrate = 9600;
            //modbusClient.StopBits = System.IO.Ports.StopBits.One;
            //modbusClient.Parity = System.IO.Ports.Parity.Even;
            //modbusClient.ConnectionTimeout = 5000;

            modbusClient.Connect();

            modbusClient.WriteMultipleCoils(9, new bool[] { true, false, true, false, true, false });
            bool[] arrCoils = modbusClient.ReadCoils(9, 6);
            for (int i = 0; i < arrCoils.Length; i++)
            {
                Console.WriteLine($"offset {i} = {arrCoils[i]}");
            }

            int[] arrHR = modbusClient.ReadHoldingRegisters(0, 3);

            

            modbusClient.Disconnect();
        }
    }
}
