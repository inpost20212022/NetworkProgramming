using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;

namespace ModbusSlave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String ipAddr = "127.0.0.1";
            int port = 1502;

            // Listener dla połączeń przychodzących
            TcpListener listener = new TcpListener(IPAddress.Parse(ipAddr), port);
            // Utworzenie "urządzenia" typu slave
            ModbusTcpSlave slave = ModbusTcpSlave.CreateTcp(1, listener);
            slave.ModbusSlaveRequestReceived += Slave_ModbusSlaveRequestReceived;
            slave.Listen();

            slave.DataStore.InputDiscretes[1] = true;
            slave.DataStore.InputDiscretes[2] = true;
            slave.DataStore.InputDiscretes[3] = true;

            slave.DataStore.InputRegisters[1] = 101;
            slave.DataStore.InputRegisters[2] = 102;
            slave.DataStore.InputRegisters[3] = 103;

            slave.DataStore.CoilDiscretes[1] = true;
            slave.DataStore.CoilDiscretes[2] = true;
            slave.DataStore.CoilDiscretes[3] = true;

            slave.DataStore.HoldingRegisters[1] = 123;
            slave.DataStore.HoldingRegisters[2] = 124;
            slave.DataStore.HoldingRegisters[3] = 125;

            Console.WriteLine("Modbus slave started...");
            Console.ReadLine();
        }

        private static void Slave_ModbusSlaveRequestReceived(object sender, 
            ModbusSlaveRequestEventArgs e)
        {
            ModbusTcpSlave slave = (ModbusTcpSlave)sender;
            Console.WriteLine("==================================================");
            Console.WriteLine("Command: {0}", e.Message.FunctionCode);

            for (int i = 1; i <=5; i++)
            {
                Console.WriteLine($"InputDiscretes[{i}] = {slave.DataStore.InputDiscretes[i]}");
            }
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"InputRegisters[{i}] = {slave.DataStore.InputRegisters[i]}");
            }
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"CoilDiscretes[{i}] = {slave.DataStore.CoilDiscretes[i]}");
            }
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"HoldingRegisters[{i}] = {slave.DataStore.HoldingRegisters[i]}");
            }
            
        }
    }
}
