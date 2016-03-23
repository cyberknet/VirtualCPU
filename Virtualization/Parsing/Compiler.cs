using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtualization.Operations;

namespace Virtualization.Parsing
{
    public class Compiler
    {
        public void Compile(string input, string output)
        {

        }

        public byte[] Compile(string data)
        {
            var bytes = new List<byte>();

            var grammar = new AssemblerGrammar();

            
            var rootNode = getRoot(data, grammar);
            if (rootNode == null)
            {
                // not valid source code
            }
            else
            {
                // valid source code
                foreach(ParseTreeNode node in rootNode.ChildNodes)
                {
                    bytes.AddRange(getInstructions(node));
                }
            }

            return bytes.ToArray();
        }

        private IEnumerable<byte> getInstructions(ParseTreeNode parent)
        {
            var instructions = new List<byte>();
            
            foreach(ParseTreeNode node in parent.ChildNodes)
            {
                if (node.Term != null)
                {
                    if (node.Term.Name == "INSTRUCTION")
                    {
                        instructions.AddRange(ProcessInstruction(node));
                        
                    }
                    else
                        instructions.AddRange(getInstructions(node));
                }
                
            }
            return instructions;
        }

        private IEnumerable<byte> ProcessInstruction(ParseTreeNode node)
        {
            var instructions = new List<byte>();

            ParseTreeNode keyword = node.ChildNodes.FirstOrDefault(n => n.Term.Name == "Keyword");
            var instruction = Instruction.OperationCodes.FirstOrDefault(i => i.Code.ToUpper().Trim() == keyword.ChildNodes[0].Term.Name.ToUpper().Trim());

            if (instruction != null)
            {
                instructions.AddRange(BitConverter.GetBytes((Int16) instruction.OperationCode));
                for (int param = 0; param < instruction.Parameters.Count; param++)
                {
                    OperationParameter parameter = instruction.Parameters[param];
                    ParseTreeNode paramNode = null;
                    if (node.ChildNodes.Count > param + 1)
                        paramNode = node.ChildNodes[param + 1];

                    switch (parameter.ParameterType)
                    {
                        case Operations.ParameterType.Register:
                            if (paramNode != null)
                            {
                                var register = (RegisterType) paramNode.Token.Value;
                                instructions.AddRange(BitConverter.GetBytes((UInt16) register));
                            }
                            else
                            {
                                instructions.AddRange(BitConverter.GetBytes((UInt16)0));
                            }
                            break;
                        default:
                            if (paramNode != null)
                            {
                                instructions.AddRange(BitConverter.GetBytes(Convert.ToUInt32(paramNode.Token.Value)));
                            }
                            else
                            {
                                instructions.AddRange(BitConverter.GetBytes((UInt32)0));
                            }
                            break;
                    }
                }
            }
            return instructions;
        }

        private ParseTreeNode getRoot(string sourceCode, Grammar grammar)

        {
            var language = new LanguageData(grammar);

            var parser = new Parser(language);

            ParseTree parseTree = parser.Parse(sourceCode);

            ParseTreeNode root = parseTree.Root;

            return root;

        }
    }
}
