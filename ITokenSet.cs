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
 * ITokenSet.cs
 *
 * Public interface for token set type.
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

namespace M2SF.M2Sharp {

public interface ITokenSet {

/* --------------------------------------------------------------------------
 * constructor newFromList(token, ...)
 * --------------------------------------------------------------------------
 * Returns a newly allocated tokenset object that includes the tokens passed
 * as arguments of a variadic argument list.
 * ----------------------------------------------------------------------- */

// public static TokenSet newFromList (params Token[] tokenList);


/* --------------------------------------------------------------------------
 * constructor newFromUnion(set, ...)
 * --------------------------------------------------------------------------
 * Returns a newly allocated tokenset object that represents the set union of
 * the tokensets passed as arguments of a non-empty variadic argument list.
 * ----------------------------------------------------------------------- */

// public static TokenSet newFromUnion (params TokenSet[] setList);


/* --------------------------------------------------------------------------
 * method Count()
 * --------------------------------------------------------------------------
 * Returns the number of elements in the receiver.
 * ----------------------------------------------------------------------- */

public uint Count ();


/* --------------------------------------------------------------------------
 * method IsElement(token)
 * --------------------------------------------------------------------------
 * Returns true if token is an element of the receiver, else false.
 * ----------------------------------------------------------------------- */

public bool IsElement (Token token);


/* --------------------------------------------------------------------------
 * method IsSubset(set)
 * --------------------------------------------------------------------------
 * Returns true if each element in set is also in the receiver, else false.
 * ----------------------------------------------------------------------- */

public bool IsSubset (TokenSet set);


/* --------------------------------------------------------------------------
 * method IsDisjunct(set)
 * --------------------------------------------------------------------------
 * Returns true if set has no common elements with the receiver, else false.
 * ----------------------------------------------------------------------- */

public bool IsDisjunct (TokenSet set);


/* --------------------------------------------------------------------------
 * method ElementList()
 * --------------------------------------------------------------------------
 * Returns a token list of all elements in the receiver.
 * ----------------------------------------------------------------------- */

public List<Token> ElementList ();


/* --------------------------------------------------------------------------
 * method PrintSet(label)
 * --------------------------------------------------------------------------
 * Prints a human readable representation of the receiver.
 * Format: label = { comma-separated list of tokens };
 * ----------------------------------------------------------------------- */

public void PrintSet (string label);


/* --------------------------------------------------------------------------
 * method PrintList()
 * --------------------------------------------------------------------------
 * Prints a human readable list of tokens in the receiver.
 * Format: first, second, third, ..., secondToLast or last
 * ----------------------------------------------------------------------- */

public void PrintList ();


/* --------------------------------------------------------------------------
 * method PrintLiteralStruct(ident)
 * --------------------------------------------------------------------------
 * Prints a struct definition for a tokenset literal for the receiver.
 * Format: struct ident { uint s0; uint s1; uint s2; ...; uint n };
 * ----------------------------------------------------------------------- */

public void PrintLiteralStruct (string ident);


/* --------------------------------------------------------------------------
 * method PrintLiteral()
 * --------------------------------------------------------------------------
 * Prints a sequence of hex values representing the bit pattern of receiver.
 * Format: ( 0xHHHHHHHH, 0xHHHHHHHH, ..., count );
 * ----------------------------------------------------------------------- */

public void PrintLiteral ();


} /* ITokenSet */

} /* M2SF.M2Sharp */

/* END OF FILE */