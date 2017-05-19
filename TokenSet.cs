/* M2Sharp -- Modula-2 to C# Translator & Compiler
 *
 * Copyright (c) 2016 The Modula-2 Software Foundation
 *
 * Author & Maintainer: Benjamin Kowarsch <trijezdci@org.m2sf>
 *
 * @synopsis
 *
 * M2Sharp is a multi-dialect Modula-2 to C# translator and via-C# compiler.
 * It supports the dialects described in the 3rd and 4th editions of Niklaus
 * Wirth's book "Programming in Modula-2" (PIM) published by Springer Verlag,
 * and an extended mode with select features from the revised language by
 * B.Kowarsch and R.Sutcliffe "Modula-2 Revision 2010" (M2R10).
 *
 * In translator mode, M2Sharp translates Modula-2 source to C# source files.
 * In compiler mode, M2Sharp compiles Modula-2 source via C# source files
 * to object code or executables using the host system's C# compiler.
 *
 * @repository
 *
 * https://github.com/m2sf/m2sharp
 *
 * @file
 *
 * TokenSet.cs
 * 
 * A set of Token type variables which is used to pass First and Follow sets
 *
 * @license
 *
 * M2Sharp is free software: you can redistribute and/or modify it under the
 * terms of the GNU Lesser General Public License (LGPL) either version 2.1
 * or at your choice version 3 as published by the Free Software Foundation.
 * However, you may not alter the copyright, author and license information.
 *
 * M2Sharp is distributed in the hope that it will be useful,  but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  Read the license for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with M2Sharp. If not, see <https://www.gnu.org/copyleft/lesser.html>.
 *
 * NB: Components in the domain part of email addresses are in reverse order.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.m2sf.m2sharp
{

    public class TokenSet : ITokenSet {

        /* Lexeme Table */
        public static string[] lexemeTable = {
  /* Null Token */
  
  "UNKNOWN",
  
  /* Reserved Words */

  "AND", 
  "ARGLIST",
  "ARRAY", 
  "BEGIN", 
  "BY",
  "CASE",
  "CONST",
  "DEFINITION",
  "DIV",
  "DO",
  "ELSE",
  "ELSIF",
  "END",
  "EXIT",
  "EXPORT",
  "FOR",
  "FROM",
  "IF",
  "IMPLEMENTATION",
  "IMPORT",
  "IN",
  "LOOP",
  "MOD",
  "MODULE",
  "NOT",
  "OF",
  "OR",
  "POINTER",
  "PROCEDURE",
  "QUALIFIED",
  "RECORD",
  "REPEAT",
  "RETURN",
  "SET",
  "THEN",
  "TO",
  "TYPE",
  "UNTIL",
  "VAR",
  "WHILE",
  "WITH",
  
  /* Identifiers */
  
  "IDENTIFIER",
  
  /* Literals */
  
  "STRING-LITERAL",
  "INTEGER-LITERAL",
  "REAL-LITERAL",
  "CHAR-LITERAL",
  
  "MALFORMED-STRING",
  "MALFORMED-INTEGER",
  "MALFORMED-REAL",
  
  /* Pragmas */
  
  "PRAGMA",
  
  /* Special Symbols */
  
  "PLUS",
  "MINUS",
  "EQUAL",
  "NOTEQUAL",
  "LESS-THAN",
  "LESS-OR-EQUAL",
  "GREATER-THAN",
  "GREATER-OR-EQUAL",
  "ASTERISK",
  "SOLIDUS",
  "BACKSLASH",
  "ASSIGNMENT",
  "COMMA",
  "PERIOD",
  "COLON",
  "SEMICOLON",
  "RANGE",
  "DEREF",
  "VERTICAL-BAR",
  "LEFT-PAREN",
  "RIGHT-PAREN",
  "LEFT-BRACKET",
  "RIGHT-BRACKET",
  "LEFT-BRACE",
  "RIGHT-BRACE",
  "END-OF-FILE"

}; /* end m2c_token_name_table */

        public static const int segmentCount = (Enum.GetNames(typeof(Token)).Length / 32) + 1;

        public struct TokenSetBits
        {
            public uint[] segments = new uint[segmentCount];
            public uint elemCount;
        } /* end struct */

        TokenSetBits dataStored;

        /* ---------------------------------------------------------------------------
         * private constructor TokenSet ()
         * ---------------------------------------------------------------------------
         * Prevents clients from invoking the default constructor.
         * ------------------------------------------------------------------------ */

        private TokenSet()
        {
            // no operation
        } /* end TokenSet */

        /* --------------------------------------------------------------------------
         * constructor newFromList(token, ...)
         * --------------------------------------------------------------------------
         * Returns a newly allocated tokenset object that includes the tokens passed
         * as arguments of a variadic argument list.
         * ----------------------------------------------------------------------- */

        public static TokenSet newFromList(params Token[] tokenList)
        {
            TokenSet newSet = new TokenSet();
            uint bit, segmentIndex;
            Token token;

            /* allocate new set */
            newSet.dataStored.segments = new uint[segmentCount];

            /* initialise */
            for (segmentIndex = 0; segmentIndex < segmentCount; segmentIndex++)
            {
                newSet.dataStored.segments[segmentIndex] = 0;
            } /* end For */

            /* store tokens from list */
            token = tokenList[0];
            for (int i = 1; token != Token.Unknown; i++)
            {

                if (token <= Token.EndOfFile)
                {
                    segmentIndex = (uint)token / 32;
                    bit = (uint)token % 32;
                    newSet.dataStored.segments[segmentIndex] = (newSet.dataStored.segments[segmentIndex] | (uint)(1 << (int)bit));
                } /* end if */

                /* get next token in list */
                token = tokenList[i];
            } /* end while */

            /* update element counter */
            newSet.dataStored.elemCount = CountBits(newSet);

            return newSet;
        } /* end newFromList */


        /* --------------------------------------------------------------------------
         * constructor newFromUnion(set, ...)
         * --------------------------------------------------------------------------
         * Returns a newly allocated tokenset object that represents the set union of
         * the tokensets passed as arguments of a non-empty variadic argument list.
         * ----------------------------------------------------------------------- */

        public static TokenSet newFromUnion(params TokenSet[] setList)
        {
            uint segmentIndex;
            TokenSet set,
                newSet = new TokenSet();


            /* initialise */
            newSet.dataStored.segments = new uint[segmentCount];
            for (segmentIndex = 0; segmentIndex < segmentCount; segmentIndex++)
            {
                newSet.dataStored.segments[segmentIndex] = 0;
            } /* end for */

            set = setList[0];
            /* calculate union with each set in list */
            for (int i = 0; set != null; i++)
            {
                /* for each segment ... */
                while (segmentIndex < segmentCount)
                {
                    /* ... store union of corresponding segments */
                    newSet.dataStored.segments[segmentIndex] =
                        newSet.dataStored.segments[segmentIndex] | newSet.dataStored.segments[segmentIndex];

                    /* next segment */
                    segmentIndex++;
                } /* end while */

                /*get next set in list */
                if (i < setList.Length)
                    set = setList[i];
                else
                    set = null;

            } /* end for */

            /* update element counter */
            newSet.dataStored.elemCount = CountBits(newSet);

            return newSet;
        } /* end newFromUnion

/* --------------------------------------------------------------------------
 * method Count()
 * --------------------------------------------------------------------------
 * Returns the number of elements in the receiver.
 * ----------------------------------------------------------------------- */

        public uint Count()
        {

            return this.dataStored.elemCount;
        } /* end IsElement */


        /* --------------------------------------------------------------------------
         * method IsElement(token)
         * --------------------------------------------------------------------------
         * Returns true if token is an element of the receiver, else false.
         * ----------------------------------------------------------------------- */

        public bool IsElement(Token token)
        {
            int segmentIndex, bit;

            if (token > Token.EndOfFile)
            {
                return false;
            } /* end if */

            segmentIndex = (int)token / 32;
            bit = (int)token % 32;

            return (this.dataStored.segments[segmentIndex] & (1 << bit)) != 0;
        } /* end IsElement */


        /* --------------------------------------------------------------------------
         * method IsSubset(set)
         * --------------------------------------------------------------------------
         * Returns true if each element in set is also in the receiver, else false.
         * ----------------------------------------------------------------------- */

        public bool IsSubset(TokenSet set)
        {

            for (uint segmentIndex = 0; segmentIndex < segmentCount; segmentIndex++)
            {

                if (((set.dataStored.segments[segmentIndex] & this.dataStored.segments[segmentIndex])
                    ^ this.dataStored.segments[segmentIndex]) != 0)
                {

                    return false;

                } /* end if */

            } /* end for */

            return true;

        } /* end IsSubset */


        /* --------------------------------------------------------------------------
         * method IsDisjunct(set)
         * --------------------------------------------------------------------------
         * Returns true if set has no common elements with the receiver, else false.
         * ----------------------------------------------------------------------- */

        public bool IsDisjunct(TokenSet set)
        {

            for (uint segmentIndex = 0; segmentIndex < segmentCount; segmentIndex++)
            {

                if ((set.dataStored.segments[segmentIndex] & this.dataStored.segments[segmentIndex]) != 0)
                {

                    return false;

                } /* end if */

            } /* end for */

            return true;

        } /* end IsDisjunct */

        /* --------------------------------------------------------------------------
         * method ElementList()
         * --------------------------------------------------------------------------
         * Returns a token list of all elements in the receiver.
         * ----------------------------------------------------------------------- */
        //TODO

        public List<Token> ElementList()
        {
            List<Token> allElements = new List<Token>();
            uint segmentIndex, count;
            int bit;
            Token token;

            if (this.dataStored.elemCount == 0)
            {
                return null;
            } /* end if */

            token = 0;
            count = 0;

            while ((count <= this.dataStored.elemCount) && (token <= Token.EndOfFile))
            {
                segmentIndex = (uint)token / 32;
                bit = (int)token % 32;

                if (((this.dataStored.segments[segmentIndex]) & (1 << (int)bit)) != 0)
                {
                    count++;
                    allElements.Add(token);
                } /* end if */
                token++;
            } /* end while */

            return allElements;

        } /* end ElementList */


        /* --------------------------------------------------------------------------
         * method PrintSet(label)
         * --------------------------------------------------------------------------
         * Prints a human readable representation of the receiver.
         * Format: label = { comma-separated list of tokens };
         * ----------------------------------------------------------------------- */

        public void PrintSet(string label)
        {
            uint segmentIndex, count;
            int bit;
            Token token;

            Console.Write(label + " = {");
            if (this.dataStored.elemCount == 0)
            {
                Console.Write(" ");
            } /* end if */

            token = 0;
            count = 0;

            while ((count <= this.dataStored.elemCount) && (token <= Token.EndOfFile))
            {
                segmentIndex = (uint)token / 32;
                bit = (int)token % 32;

                if (((this.dataStored.segments[segmentIndex]) & (1 << (int)bit)) != 0)
                {
                    count++;

                    if (count <= this.dataStored.elemCount)
                    {

                        Console.Write("\n {0},", lexemeTable[(uint)token]);
                    }
                    else
                    {
                        Console.WriteLine("\n {0}", lexemeTable[(uint)token]);
                    } /* end if */
                } /* end if */
                token++;
            } /* end while */

            Console.WriteLine("};");
        } /* end PrintSet */


        /* --------------------------------------------------------------------------
         * method PrintList()
         * --------------------------------------------------------------------------
         * Prints a human readable list of tokens in the receiver. 
         * Format: first, second, third, ..., secondToLast or last
         * ----------------------------------------------------------------------- */

        public void PrintList()
        {
            uint bit, segmentIndex, count;
            Token token;

            if (this.dataStored.elemCount == 0)
            {
                Console.WriteLine("(nil)");
            }

            count = 0;
            token = 0;
            while ((count <= this.dataStored.elemCount) && (token <= Token.EndOfFile))
            {
                segmentIndex = (uint)token / 32;
                bit = (uint)token % 32;

                if (((this.dataStored.segments[segmentIndex] & (1 << (int)bit)) != 0))
                {
                    count++;
                    if (count > 1)
                    {
                        if (count <= this.dataStored.elemCount)
                        {
                            Console.Write(", ");
                        }
                        else
                        {
                            Console.Write(" or ");
                        } /* end if */
                    } /* end if */

                    Console.Write(lexemeTable[(uint)token]);
                }
                token++;
            }

            Console.WriteLine(".");
        } /* end PrintList */


        /* --------------------------------------------------------------------------
         * method PrintLiteralStruct(ident)
         * --------------------------------------------------------------------------
         * Prints a struct definition for a tokenset literal for the receiver.
         * Format: struct ident { uint s0; uint s1; uint s2; ...; uint n };
         * ----------------------------------------------------------------------- */

        public void PrintLiteralStruct(string ident)
        {
            uint segmentIndex;

            Console.Write("struct {0} {{ uint s0", ident);

            for (segmentIndex = 1; segmentIndex < segmentCount; segmentIndex++)
            {
                Console.Write("; s" + segmentIndex);
            } /* end for */

            Console.WriteLine("; n };");
            Console.WriteLine("typedef struct {0} {0};", ident);

        } /* end PrintLiteralStruct */


        /* --------------------------------------------------------------------------
         * method PrintLiteral()
         * --------------------------------------------------------------------------
         * Prints a sequence of hex values representing the bit pattern of receiver.
         * Format: ( 0xHHHHHHHH, 0xHHHHHHHH, ..., count );
         * ----------------------------------------------------------------------- */

        public void PrintLiteral()
        {
            uint segmentIndex;

            Console.Write("( /* bits: */ 0x" + this.dataStored.segments[0].ToString("x08"));

            for (segmentIndex = 1; segmentIndex < segmentCount; segmentIndex++)
            {

                Console.Write(", 0x" + this.dataStored.segments[segmentIndex].ToString("x08"));
            } /* end for */

            Console.WriteLine(", /* counter: */ " + this.dataStored.elemCount + " );");
        } /* end PrintLiteral */

        /* --------------------------------------------------------------------------
         * method CountBits()
         * --------------------------------------------------------------------------
         * Returns the number of set bits in set.
         * ----------------------------------------------------------------------- */

        static private uint CountBits(TokenSet set)
        {
            int bit;
            uint segmentIndex,
                bitCount = 0;

            for (segmentIndex = 0; segmentIndex < segmentCount; segmentIndex++)
            {

                for (bit = 0; bit < 32; bit++)
                {

                    if ((set.dataStored.segments[segmentIndex] & (1 << bit)) != 0)
                    {
                        bitCount++;
                    } /* end if */

                } /* end for */

            } /* end for */

            return bitCount;
        } /* end CountBits */

    } /* end TokenSet */

} /* end namespace */
