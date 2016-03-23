using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtualization.Operations
{
    public class OperationParameter
    {
        public const UInt32 SIZE_REGISTER = 2; // 16bit Unsigned Integer
        public const UInt32 SIZE_MEMORY = 8; // 64bit Unsigned Integer
        public const UInt32 SIZE_VALUE = 4; // 32bit Unsigned Integer

        public ParameterType ParameterType { get; set; }
        public long Address { get; set; }
        public UInt32 Value { get; set; }
        public RegisterType Register { get; set; }
        public bool Optional { get; set; }
        public UInt32 Length { get { return ParameterType == ParameterType.Register ? SIZE_REGISTER : 
                                            ParameterType == ParameterType.Address ? SIZE_MEMORY :
                                                                                           SIZE_VALUE; } }
    }
}
