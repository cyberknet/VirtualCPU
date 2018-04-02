using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Virtualization.Operations;
using Virtualization.Parsing;

namespace Virtualization.Visualization
{
    public partial class Form1 : Form
    {
        private const int KILOBYTE = 1024;
        private const int MEMORY_SIZE = 64 * KILOBYTE;
        Processor processor = new Processor(MEMORY_SIZE); // 64KB
        

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < processor.Registers.Count; i++)
            {
                var item = RegisterView.Items.Add(((RegisterType) i).ToString());
                item.SubItems.Add("");
            }

            //InitializeMemory();
            InitializeSyntaxHilighting();

            // load firmware from embedded resource
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Virtualization.Visualization.Firmware.asm";
            string firmware = string.Empty;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                firmware = reader.ReadToEnd();
            }
            syntaxDocument1.Lines = firmware.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);

            if (firmware != string.Empty)
            {
                var compiler = new Compiler();
                var compiledFirmware = compiler.Compile(firmware);
                Array.Copy(compiledFirmware, processor.PhysicalMemory, compiledFirmware.Length);
            }
            // parse firmware source
            // compile firmware source

            DisplayRegisters();
            DisplayFlags();
            DisplayMemory();
            hexBox1.Select(processor.InstructionPointer, 1);
        }

        private void InitializeSyntaxHilighting()
        {

        }

        private void InitializeMemory()
        {
            UInt32 offset = 0;

            offset = AddFirmwareStepMoveImmediate(RegisterType.A, 1, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.B, 2, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.C, 3, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.D, 4, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.E, 5, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.F, 6, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.G, 7, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.H, 8, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.I, 9, offset);
            offset = AddFirmwareStepMoveImmediate(RegisterType.J, Operation.SIZE_OPCODE + OperationParameter.SIZE_VALUE, offset);
            offset = AddFirmwareStepJump(RegisterType.J, offset);
            offset = AddFirmwareStepIncrement(RegisterType.J, 2, offset); // instruction should be skipped
            offset = AddFirmwareStepMoveImmediate(RegisterType.J, 10, offset);
        }

        #region Firmware generation methods
        private UInt32 AddFirmwareStepIncrement(RegisterType register, UInt32 value, UInt32 offset)
        {
            return AddFirmwareStepOpCode(OperationCode.Increment, register, value, offset);
        }
        private UInt32 AddFirmwareStepMoveImmediate(RegisterType register, UInt32 value, UInt32 offset)
        {
            return AddFirmwareStepOpCode(OperationCode.MoveImmediate, register, value, offset);
        }
        private UInt32 AddFirmwareStepJump(RegisterType register, UInt32 offset)
        {
            return AddFirmwareStepOpCode(OperationCode.Jump, register, offset);
        }
        #endregion

        private UInt32 AddFirmwareStepOpCode(OperationCode operationCode, RegisterType register, UInt32 offset)
        {
            offset = AddFirmwareOperationCode(operationCode, offset);
            offset = AddFirmwareRegister(register, offset);

            return offset;
        }
        private UInt32 AddFirmwareStepOpCode(OperationCode operationCode, RegisterType register, UInt32 value, UInt32 offset)
        {
            offset = AddFirmwareOperationCode(operationCode, offset);
            offset = AddFirmwareRegister(register, offset);
            offset = AddFirmwareValue(value, offset);

            return offset;
        }

        private UInt32 AddFirmwareOperationCode(OperationCode opCode, UInt32 offset)
        {
            processor.PhysicalMemory[offset] = (byte)opCode;
            offset += Operation.SIZE_OPCODE;
            return offset;
        }

        private UInt32 AddFirmwareRegister(RegisterType register, UInt32 offset)
        {
            processor.PhysicalMemory[offset] = (byte) (int) register;
            offset += OperationParameter.SIZE_REGISTER;
            return offset;
        }

        private UInt32 AddFirmwareValue(UInt32 value, UInt32 offset)
        {
            var bytes = BitConverter.GetBytes(value);
            for (UInt32 i = 0; i < bytes.Length; i++)
                processor.PhysicalMemory[offset + i] = bytes[i];
            offset += OperationParameter.SIZE_VALUE;
            return offset;
        }

        private UInt32 AddFirmwareAddress(UInt64 value, UInt32 offset)
        {
            var bytes = BitConverter.GetBytes(value);
            for (UInt32 i = 0; i < bytes.Length; i++)
                processor.PhysicalMemory[offset + i] = bytes[i];
            offset += OperationParameter.SIZE_MEMORY;
            return offset;
        }

        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] hexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', count: lineLength - Environment.NewLine.Length)+ Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            var result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = hexChars[(i >> 28) & 0xF];
                line[1] = hexChars[(i >> 24) & 0xF];
                line[2] = hexChars[(i >> 20) & 0xF];
                line[3] = hexChars[(i >> 16) & 0xF];
                line[4] = hexChars[(i >> 12) & 0xF];
                line[5] = hexChars[(i >> 8) & 0xF];
                line[6] = hexChars[(i >> 4) & 0xF];
                line[7] = hexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = hexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = hexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '.' : (char) b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }

        private void NextClock_Click(object sender, EventArgs e)
        {
            processor.ProcessNextInstruction();
            DisplayRegisters();
            DisplayFlags();
            hexBox1.Select(processor.InstructionPointer, 1);
        }

        private void DisplayFlags()
        {
            ZeroFlag.Text = processor.ZeroFlag ? "True" : "False";
            SignFlag.Text = processor.SignFlag ? "True" : "False";
        }

        private void DisplayRegisters()
        {
            for (int i = 0; i < processor.Registers.Count; i++)
            {
                RegisterType register = (RegisterType) i;
                foreach (ListViewItem itm in RegisterView.Items)
                {
                    if (itm.Text == register.ToString())
                    {
                        itm.SubItems[1].Text = processor.Registers[i].ToString();
                    }
                }
            }
        }

        private void DisplayMemory()
        {
            var byteProvider = new Be.Windows.Forms.DynamicByteProvider(processor.PhysicalMemory);
            hexBox1.ByteProvider = byteProvider;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
