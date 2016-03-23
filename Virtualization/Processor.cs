using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtualization.Operations;

namespace Virtualization
{
    public class Processor
    {
        public List<Instruction> Stack { get; set; }
        public List<UInt32> Registers { get; set; }
        public byte[] PhysicalMemory { get; set; }
        public UInt32 Clock { get; set; }
        public bool SignFlag
        {
            get { return flags[(int)CpuFlags.Sign]; }
            set { flags[(int)CpuFlags.Sign] = value; }
        }
        public bool ZeroFlag
        {
            get { return flags[(int)CpuFlags.Zero]; }
            set { flags[(int)CpuFlags.Zero] = value; }
        }

        public UInt32 StackPointer
        {
            get { return Registers[(int)RegisterType.StackPointer]; }
            set { Registers[(int)RegisterType.StackPointer] = value; }
        }

        public UInt32 InstructionPointer
        {
            get { return Registers[(int)RegisterType.InstructionPointer]; }
            set { Registers[(int)RegisterType.InstructionPointer] = value; }
        }

        private readonly BitArray flags = new BitArray((int)CpuFlags.Zero + 1, false);
     
        public Processor(Int64 memorySize)
        {
            Stack = new List<Instruction>();
            Registers = new List<UInt32>();
            int maxRegisters = 0;
            foreach (RegisterType register in Enum.GetValues(typeof(RegisterType)))
            {
                Registers.Add(0);
                maxRegisters += 1;
            }


            PhysicalMemory = new byte[memorySize];
        }
        
        private Instruction LoadInstruction(long memoryAddress)
        {
            var instruction = new Instruction();
            UInt32 opCode = PhysicalMemory[memoryAddress];
            
            var operation = Instruction.OperationCodes.FirstOrDefault(oc => (int)oc.OperationCode == opCode);
            instruction.Operation = operation;

            UInt32 offset = Operation.SIZE_OPCODE;
            for(int i = 0; i < instruction.Operation.Parameters.Count; i++)
            {
                switch(instruction.Operation.Parameters[i].ParameterType)
                {
                    case ParameterType.Address:
                        instruction.Parameters.Add(new OperationParameter
                        {
                            ParameterType = ParameterType.Address,
                            Address = memoryAddress + offset
                        });
                        offset += OperationParameter.SIZE_MEMORY;
                        break;
                    case ParameterType.Value:
                        instruction.Parameters.Add(new OperationParameter
                        {
                            ParameterType = ParameterType.Address,
                            Value = BitConverter.ToUInt32(PhysicalMemory, (int)(memoryAddress + offset))
                        });
                        offset += OperationParameter.SIZE_VALUE;
                        break;
                    case ParameterType.Register:
                        instruction.Parameters.Add(new OperationParameter
                        {
                            ParameterType = ParameterType.Register,
                            Register = (RegisterType) PhysicalMemory[memoryAddress + offset]
                        });
                        offset += OperationParameter.SIZE_REGISTER;
                        break;
                }
            }

            InstructionPointer += offset;
            
            return instruction;
        }

        public void ProcessNextInstruction()
        {
            var instruction = LoadInstruction(InstructionPointer);
            
            switch(instruction.Operation.OperationCode)
            {
                case OperationCode.NoOperation:
                    NoOperation();
                    break;
                case OperationCode.Increment:
                    Increment(instruction.Parameters[0].Register);
                    break;
                case OperationCode.AddImmediate:
                    AddImmediate(instruction.Parameters[0].Register, instruction.Parameters[1].Value);
                    break;
                case OperationCode.AddRegister:
                    AddRegister(instruction.Parameters[0].Register, instruction.Parameters[1].Register);
                    break;
                case OperationCode.PushRegister:
                    PushRegister(instruction.Parameters[0].Address, instruction.Parameters[1].Address);
                    break;
                case OperationCode.PushImmediate:
                    PushImmediate(instruction.Parameters[0].Address, instruction.Parameters[1].Value);
                    break;
                case OperationCode.MoveImmediate:
                    MoveImmediate(instruction.Parameters[0].Register, instruction.Parameters[1].Value);
                    break;
                case OperationCode.MoveRegister:
                    MoveRegister(instruction.Parameters[0].Register, instruction.Parameters[2].Register);
                    break;
                case OperationCode.MoveMemoryToRegister:
                    MoveMemoryToRegister(instruction.Parameters[0].Address, instruction.Parameters[1].Register);
                    break;
                case OperationCode.MoveRegisterToMemory:
                    MoveRegisterToMemory(instruction.Parameters[0].Register, instruction.Parameters[1].Address);
                    break;
                case OperationCode.MoveMemoryToMemory:
                    MoveMemoryToMemory(instruction.Parameters[0].Address, instruction.Parameters[1].Address);
                    break;
                case OperationCode.Jump:
                    Jump(instruction.Parameters[0].Address);
                    break;
                case OperationCode.CompareImmediate:
                    CompareImmediate(instruction.Parameters[0].Register, instruction.Parameters[1].Value);
                    break;
                case OperationCode.CompareRegister:
                    CompareRegister(instruction.Parameters[0].Register, instruction.Parameters[2].Register);
                    break;
                case OperationCode.JumpLessThan:
                    JumpLessThan(instruction.Parameters[0].Address, instruction.Parameters[1].Value);
                    break;
                case OperationCode.JumpGreaterThan:
                    JumpGreaterThan(instruction.Parameters[0].Address, instruction.Parameters[1].Value);
                    break;
                case OperationCode.JumpZero:
                    JumpZero(instruction.Parameters[0].Address, instruction.Parameters[1].Value);
                    break;
                case OperationCode.JumpNonZero:
                    JumpNonZero(instruction.Parameters[0].Address, instruction.Parameters[1].Value);
                    break;
                case OperationCode.Call:
                    Call(instruction.Parameters[1].Value);
                    break;
                case OperationCode.CallMemory:
                    CallMemory(instruction.Parameters[0].Address, instruction.Parameters[1].Value);
                    break;
                case OperationCode.Return:
                    Return(instruction.Parameters[0].Address, instruction.Parameters[1].Value);
                    break;
                case OperationCode.Allocate:
                    Allocate(instruction.Parameters[1].Value);
                    break;
                case OperationCode.Sleep:
                    Sleep(instruction.Parameters[0].Value);
                    break;
                case OperationCode.Exit:
                    Exit();
                    break;
                case OperationCode.Free:
                    FreeMemory(instruction.Parameters[0].Register);
                    break;
                case OperationCode.Map:
                    MapSharedMemory(instruction.Parameters[0].Address, instruction.Parameters[1].Address);
                    break;
                case OperationCode.SignalEvent:
                    SignalEvent(instruction.Parameters[0].Register);
                    break;
                case OperationCode.WaitEvent:
                    WaitEvent(instruction.Parameters[0].Register);
                    break;
                case OperationCode.Input:
                    Input(instruction.Parameters[0].Register);
                    break;
                case OperationCode.MemoryClear:
                    MemoryClear(instruction.Parameters[0].Register, instruction.Parameters[1].Value);
                    break;
                case OperationCode.PopRegister:
                    PopRegister(instruction.Parameters[0].Register);
                    break;
                case OperationCode.PopMemory:
                    PopMemory(instruction.Parameters[0].Register);
                    break;
            }
        }

        #region CPU Operations
        private void NoOperation()
        {
            //InstructionPointer++;
        }


        private void Increment(RegisterType register)
        {
            Registers[(int)register]++;
        }


        private void AddImmediate(RegisterType register, UInt32 value)
        {
            Registers[(int)register] += value;
        }


        private void AddRegister(RegisterType register1, RegisterType register2)
        {
            Registers[(int)register1] += Registers[(int)register2];
        }


        private void PushRegister(long address1, long address2)
        {
            // TODO: complete cpu code for PushRegister
        }


        private void PushImmediate(long address1, long address2)
        {
            // TODO: complete cpu code for PushImmediate
        }


        private void MoveImmediate(RegisterType register, UInt32 value)
        {
            Registers[(int)register] = value;
        }


        private void MoveRegister(RegisterType register, RegisterType register2)
        {
            Registers[(int)register] = Registers[(int)register2];
        }


        private void MoveMemoryToRegister(long address, RegisterType register)
        {
            // TODO: complete cpu code for MoveMemoryToRegister
        }


        private void MoveRegisterToMemory(RegisterType register, long address)
        {
            // TODO: complete cpu code for MoveRegisterToMemory
        }


        private void MoveMemoryToMemory(long address1, long address2)
        {
            // TODO: complete cpu code for MoveMemoryToMemory
        }


        private void PrintRegister(RegisterType register)
        {
            // TODO: complete cpu code for PrintRegister
        }


        private void PrintMemory(long address)
        {
            // TODO: complete cpu code for PrintMemory
        }

        private void Jump(long address)
        {
            // TODO: complete cpu code for Jump
        }


        private void CompareImmediate(RegisterType register, UInt32 value)
        {
            ZeroFlag = false;
            if (Registers[(int)register] < value)
                SignFlag = true;
            else
                SignFlag = true;
            if (Registers[(int)register] == value)
                ZeroFlag = true;
        }


        private void CompareRegister(RegisterType register, RegisterType register2)
        {
            ZeroFlag = false;
            if (Registers[(int)register] < Registers[(int)register2])
                SignFlag = true;
            else
                SignFlag = true;
            if (Registers[(int)register] == Registers[(int)register2])
                ZeroFlag = true;
        }

        private void JumpLessThan(long address1, long address2)
        {
            // TODO: complete cpu code for JumpLessThan
        }


        private void JumpGreaterThan(long address1, long address2)
        {
            // TODO: complete cpu code for JumpGreaterThan
        }


        private void JumpZero(long address1, long address2)
        {
            // TODO: complete cpu code for JumpZero
        }

        private void JumpNonZero(long address1, long address2)
        {
            // TODO: complete cpu code for JumpNonZero
        }


        private void Call(UInt32 value)
        {
            // TODO: complete cpu code for Call
        }


        private void CallMemory(long address1, long address2)
        {
            // TODO: complete cpu code for CallMemory
            InstructionPointer++;
        }


        private void Return(long address1, long address2)
        {
            // TODO: complete cpu code for Return
            InstructionPointer++;
        }


        private void Allocate(UInt32 value)
        {
            // TODO: complete cpu code for Allocate
            InstructionPointer++;
        }


        private void AcquireLock(RegisterType register)
        {
            // TODO: complete cpu code for AcquireLock
            InstructionPointer++;
        }


        private void ReleaseLock(RegisterType register)
        {
            // TODO: complete cpu code for ReleaseLock
            InstructionPointer++;
        }


        private void Sleep(UInt32 value)
        {
            // TODO: complete cpu code for Sleep
            InstructionPointer++;
        }


        private void SetPriority(RegisterType register)
        {
            // TODO: complete cpu code for SetPriority
            InstructionPointer++;
        }


        private void Exit()
        {
            // TODO: complete cpu code for Exit
            InstructionPointer++;
        }


        private void FreeMemory(RegisterType register)
        {
            // TODO: complete cpu code for FreeMemory
            InstructionPointer++;
        }


        private void MapSharedMemory(long address1, long address2)
        {
            // TODO: complete cpu code for MapSharedMemory
            InstructionPointer++;
        }


        private void SignalEvent(RegisterType register)
        {
            // TODO: complete cpu code for SignalEvent
            InstructionPointer++;
        }


        private void WaitEvent(RegisterType register)
        {
            // TODO: complete cpu code for WaitEvent
            InstructionPointer++;
        }


        private void Input(RegisterType register)
        {
            // TODO: complete cpu code for Input
            InstructionPointer++;
        }


        private void MemoryClear(RegisterType register, long length)
        {
            // TODO: complete cpu code for MemoryClear
            InstructionPointer++;
        }



        private void PopRegister(RegisterType register)
        {
            // TODO: complete cpu code for PopRegister
            InstructionPointer++;
        }


        private void PopMemory(RegisterType register)
        {
            // TODO: complete cpu code for PopMemory
            InstructionPointer++;
        }
        #endregion
    }
}
