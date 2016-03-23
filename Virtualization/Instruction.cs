using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtualization.Operations;

namespace Virtualization
{
    public class Instruction
    {
        public Operation Operation { get; set; }

        public List<OperationParameter> Parameters { get; set; }

        public UInt32 Length { get { return Operation.Length; }  }

        public Instruction()
        {
            Parameters = new List<OperationParameter>();
        }

        public static bool TryParse(string text, ref Instruction instruction)
        {
            return false;
        }

        // provides a list of operation codes and defines their parameters and assembly code aliases
        public static readonly List<Operation> OperationCodes = new List<Operation>()
        {
            new Operation(OperationCode.AddImmediate, "ADDI", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Value }),
            new Operation(OperationCode.CompareImmediate, "CMPI", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Value}),
            new Operation(OperationCode.PushImmediate, "PUSHI", new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Value }),
            new Operation(OperationCode.MoveImmediate, "MOVI", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Value }),
            new Operation(OperationCode.MemoryClear, "MEMC", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Value }),
            new Operation(OperationCode.Increment, "INCR", new OperationParameter { ParameterType = ParameterType.Register }),

            new Operation(OperationCode.AddRegister, "ADDR", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.PushRegister, "PUSHR", new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.MoveRegister, "MOVR", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.MoveMemoryToRegister, "MOVMR", new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.MoveMemoryToMemory, "MOVMM", new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.MoveRegisterToMemory, "MOVRM", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.CompareRegister, "CMPR", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Register}, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.Map, "MAP", new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Address }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),

            new Operation(OperationCode.Jump, "JMP", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.JumpLessThan, "JLT", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.JumpGreaterThan, "JGT", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.JumpZero, "JZ", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.JumpNonZero, "JNZ", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.Call, "CALL", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.CallMemory, "CALLM", new OperationParameter { ParameterType = ParameterType.Value }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.Allocate, "ALLOC", new OperationParameter { ParameterType = ParameterType.Value }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.Free, "FREE", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.WaitEvent, "WAIT", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.SignalEvent, "SIG", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.Input, "INP", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.PopRegister, "POPR", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),
            new Operation(OperationCode.PopMemory, "POPM", new OperationParameter { ParameterType = ParameterType.Register }, new OperationParameter { ParameterType = ParameterType.Address, Optional=true }),

            new Operation(OperationCode.NoOperation, "NOOP"),
            new Operation(OperationCode.Return, "RET" )
        };
    }
}
