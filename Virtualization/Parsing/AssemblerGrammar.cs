using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtualization.Operations;

namespace Virtualization.Parsing
{
    [Language("VirtualAssembly", "1.0", "Virtual CPU Assembly 1.0")]
    public class AssemblerGrammar : Grammar
    {
        private static NonTerminal NonTerminalFromOperationCode(OperationCode code)
        {
            return new NonTerminal(Instruction.OperationCodes.First(c => c.OperationCode == code).Code);
        }
        public AssemblerGrammar() : base(caseSensitive: false)
        {
            #region Non Terminals
            var program = new NonTerminal("program");
            var line = new NonTerminal("line");
            var lineContentOpt = new NonTerminal("lineContentOpt");
            var commentOpt = new NonTerminal("commentOpt");
            var statement = new NonTerminal("statement");
            var REGISTER = new NonTerminal("register");
            var REGISTER_OFFSET = new NonTerminal("register (with optional offset)");
            var number = new NumberLiteral("NUMBER", NumberOptions.Hex);
            var EXPR = new NonTerminal("EXPR");
            var Register = new ConstantTerminal("Register");
            var BINARY_OP = new NonTerminal("Operator");
            //var HEXADECIMAL = new NonTerminal("HEXADECIMAL");
            //var letter = new NonTerminal("letter");
            //var digit = new NonTerminal("number");
            number.AddPrefix("0x", NumberOptions.Hex);
            //HEXADECIMAL.Rule = digit | letter | HEXADECIMAL + digit | HEXADECIMAL + letter;
            //digit.Rule = ToTerm("1") | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" | "0";
            //letter.Rule = ToTerm("A") | "B" | "C" | "D" | "E" | "F";
            
            var comment = new CommentTerminal("Comment", ";", "\n");

            var OffsetRegister = new NonTerminal("Register With Offset");
            #endregion

            var comma = ToTerm(",");
            EXPR.Rule = number;
            REGISTER.Rule = Register;
            REGISTER_OFFSET.Rule = OffsetRegister;

            OffsetRegister.Rule = ToTerm("[") + Register + BINARY_OP + number + "]";

            BINARY_OP.Rule = ToTerm("+") | "-";
            
            foreach (RegisterType register in Enum.GetValues(typeof(RegisterType)))
            {
                Register.Add(register.ToString(), register);
            }

            // set the program to be the root node of Assembler programs
            this.Root = program;
            // BNF Rules
            program.Rule = MakePlusRule(program, line);
            // A line can be an empty line, or a statement ended by a new-line
            line.Rule = lineContentOpt + commentOpt + NewLine | SyntaxError + NewLine;
            line.NodeCaptionTemplate = "Line #{0}";

            // A statement list is 1 or more statements separated by the ':' character
            lineContentOpt.Rule = Empty | statement;
            commentOpt.Rule = comment | Empty;

            // A statement can be one of a number of types
            var opRegExpr = new NonTerminal("INSTRUCTION");
            var opRegReg = new NonTerminal("INSTRUCTION");
            var opReg = new NonTerminal("INSTRUCTION");
            var opRegRegOffset = new NonTerminal("INSTRUCTION");
            var opRegOffset = new NonTerminal("INSTRUCTION");
            var op = new NonTerminal("INSTRUCTION");
            statement.Rule = opRegExpr | opRegReg | opReg | opRegRegOffset | opRegOffset | op;

            #region OP REG, EXPR
            var opRegExprKeyword = new NonTerminal("Keyword");
            opRegExprKeyword.Rule = ToTerm("addi") | "cmpi" | "pushi" | "movi" | "memc" | "incr"; // TODO: identify these from the Instruction object dynamically
            opRegExpr.Rule = opRegExprKeyword + REGISTER + comma + EXPR;
            #endregion

            #region OP REG, REG
            var opRegRegKeyword = new NonTerminal("Keyword");
            opRegReg.Rule = opRegRegKeyword + REGISTER + comma + REGISTER;
            opRegRegOffset.Rule = opRegRegKeyword + REGISTER + comma + "[" + REGISTER + "+" + EXPR + "]";
            opRegRegKeyword.Rule = ToTerm("addr") | "pushr" | "movr" | "movmr" | "movmm" | "movrm" | "cmpr" | "map";
            #endregion

            #region op REG
            var opRegKeyword = new NonTerminal("Keyword");
            opReg.Rule = opRegKeyword + REGISTER;
            opRegOffset.Rule = opRegKeyword + "[" + REGISTER + "+" + EXPR + "]";
            opRegKeyword.Rule = ToTerm("jmp") | "jlt" | "jgt" | "jz" | "jnz" | "call" | "callm" | "alloc" | "free" | "wait" | "sig" | "inp" | "popr" | "popm";
            #endregion

            #region OP
            var opKeyword = new NonTerminal("Keyword");
            op.Rule = opKeyword;
            opKeyword.Rule = ToTerm("ret") | "noop" ;
            #endregion

            MarkTransient(REGISTER, EXPR, lineContentOpt, commentOpt);
            MarkPunctuation(",", ";", "[", "]", "+", "-");

            this.LanguageFlags = LanguageFlags.NewLineBeforeEOF; // LanguageFlags.CreateAst | 

        }                    
    }                         
}                             
                              