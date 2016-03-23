using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtualization.Operations
{
    public class Operation
    {
        public const UInt32 SIZE_OPCODE = 2;
        public OperationCode OperationCode { get; private set; }
        public string Code { get; private set; }
        public List<OperationParameter> Parameters { get; set; }
        public UInt32 Length { get; private set; }

        public Operation(OperationCode instructionType, string code, params OperationParameter[] parameters)
        {
            OperationCode = instructionType;
            Code = code;
            Parameters = new List<OperationParameter>();
            Parameters.AddRange(parameters);
            Length = SIZE_OPCODE + (UInt32)Parameters.Sum(p => p.Length);
        }
        
    }
}
