using System;
using System.Collections.Generic;

namespace Assembler
{
    public class SymbolAnalyzer
    {
        public Dictionary<string, int> CreateSymbolsTable(string[] instructionsWithLabels,
            out string[] instructionsWithoutLabels)
        {
            Dictionary<string, int> symbolTable = new Dictionary<string, int>();
            InitializePredefinedSymbols(symbolTable);
            List<string> instructionsList = new List<string>();
            int instructionCounter = 0;
            foreach (string instruction in instructionsWithLabels)
            {
                if (IsLabel(instruction))
                {
                    string labelName = instruction.Substring(1, instruction.Length - 2);
                    symbolTable[labelName] = instructionCounter;
                }
                else
                {
                    instructionsList.Add(instruction);
                    instructionCounter++;
                }
            }
            instructionsWithoutLabels = instructionsList.ToArray();
            return symbolTable;
        }

        private void InitializePredefinedSymbols(Dictionary<string, int> symbolTable)
        {
            for (int i = 0; i <= 15; i++)
            {
                symbolTable[$"R{i}"] = i;
            }
            symbolTable["SP"] = 0;
            symbolTable["LCL"] = 1;
            symbolTable["ARG"] = 2;
            symbolTable["THIS"] = 3;
            symbolTable["THAT"] = 4;
            symbolTable["SCREEN"] = 0x4000;
            symbolTable["KBD"] = 0x6000;    
		}

        private bool IsLabel(string instruction)
        {
            return instruction.StartsWith("(") && instruction.EndsWith(")");
        }
    }
}