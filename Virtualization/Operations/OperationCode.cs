using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtualization.Operations
{
    /// <summary>
	/// This enum provides an easy conversion between numerical opCodes like "2" and text 
	/// and easy to remember consts like "Addi"
	/// </summary>
	public enum OperationCode
    {
        /// <summary>
        /// No op
        /// </summary>
        NoOperation,

        /// <summary>
        /// Increments register
        /// </summary>
        Increment,

        /// <summary>
        ///  Adds constant 1 to register 1
        /// </summary>
        AddImmediate,

        /// <summary>
        /// Adds r2 to r1 and stores the value in r1
        /// </summary>
        AddRegister,

        /// <summary>
        /// Pushes contents of register 1 onto stack
        /// </summary>
        PushRegister,

        /// <summary>
        /// Pushes constant 1 onto stack
        /// </summary>
        PushImmediate,

        /// <summary>
        /// Pop the contents at the top of the stack into register r1 
        /// </summary>
        PopRegister,

        /// <summary>
        /// Pop the contents at the top of the stack into the memory pointed to by register r1 
        /// </summary>
        PopMemory,

        /// <summary>
        /// Moves constant 1 into register 1
        /// </summary>
        MoveImmediate,

        /// <summary>
        /// Moves contents of register2 into register 1
        /// </summary>
        MoveRegister,

        /// <summary>
        /// Moves contents of memory pointed to register 2 into register 1
        /// </summary>
        MoveMemoryToRegister,

        /// <summary>
        /// Moves contents of register 2 into memory pointed to by register 1
        /// </summary>
        MoveRegisterToMemory,

        /// <summary>
        /// Moves contents of memory pointed to by register 2 into memory pointed to by register 1
        /// </summary>
        MoveMemoryToMemory,

        /// <summary>
        /// Compare contents of r1 with 1.  If r1 &lt; 9 set sign flag.  If r1 &gt; 9 clear sign flag.
        /// If r1 == 9 set zero flag.
        /// </summary>
        CompareImmediate,

        /// <summary>
        /// Compare contents of r1 with r2.  If r1 &lt; r2 set sign flag.  If r1 &gt; r2 clear sign flag.
        /// If r1 == r2 set zero flag.
        /// </summary>
        CompareRegister,

        /// <summary>
        /// Control transfers to the instruction whose address is r1 bytes relative to the current instruction. 
        /// r1 may be negative.
        /// </summary>
        Jump,

        /// <summary>
        /// If the sign flag is set, jump to the instruction that is offset r1 bytes from the current instruction
        /// </summary>
        JumpLessThan,

        /// <summary>
        /// If the sign flag is clear, jump to the instruction that is offset r1 bytes from the current instruction
        /// </summary>
        JumpGreaterThan,

        /// <summary>
        /// If the zero flag is set, jump to the instruction that is offset r1 bytes from the current instruction
        /// </summary>
        JumpZero,

        /// <summary>
        /// If the zero flag is not set, jump to the instruction that is offset r1 bytes from the current instruction
        /// </summary>
        JumpNonZero,

        /// <summary>
        /// Call the procedure at offset r1 bytes from the current instrucion.  
        /// The address of the next instruction to excetute after a return is pushed on the stack
        /// </summary>
        Call,

        /// <summary>
        /// Call the procedure at offset of the bytes in memory pointed by r1 from the current instrucion.  
        /// The address of the next instruction to excetute after a return is pushed on the stack
        /// </summary>
        CallMemory,

        /// <summary>
        /// Pop the return address from the stack and transfer control to this instruction
        /// </summary>
        Return,

        /// <summary>
        /// Allocate memory of the size equal to r1 bytes and return the address of the new memory in r2.  
        /// If failed, r2 is cleared to 0.
        /// </summary>
        Allocate,

        /// <summary>
        /// Free the memory allocated whose address is in r1
        /// </summary>
        Free,

        /// <summary>
        /// set the bytes starting at address r1 of length r2 to zero
        /// </summary>
        MemoryClear,

        /// <summary>
        /// Map the shared memory region identified by r1 and return the start address in r2
        /// </summary>
        Map,

        /// <summary>
        /// Sleep the # of clock cycles as indicated in r1.  
        /// Another process or the idle process 
        /// must be scheduled at this point.  
        /// If the time to sleep is 0, the process sleeps infinitely
        /// </summary>
        Sleep,

        /// <summary>
        /// This opcode causes an exit and the process's memory to be unloaded.  
        /// Another process or the idle process must now be scheduled
        /// </summary>
        Exit,

        /// <summary>
        /// Signal the event indicated by the value in register r1
        /// </summary>
        SignalEvent,

        /// <summary>
        /// Wait for the event in register r1 to be triggered resulting in a context-switch
        /// </summary>
        WaitEvent,

        /// <summary>
        /// Read the next 32-bit value into register r1
        /// </summary>
        Input,

        /// <summary>
        /// Terminate the process whose id is in the register r1
        /// </summary>
        TerminateProcess
    };
}
