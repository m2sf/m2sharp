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
 * ICSharpReswords.cs
 *
 * Public interface for C# reserved word recogniser.
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

namespace org.m2sf.m2sharp {

public interface ICSharpReswords {

/* ---------------------------------------------------------------------------
 * function IsResword(lexeme)
 * ---------------------------------------------------------------------------
 * Tests if lexeme matches reserved words and contextual reserved words of
 * the C# language and returns true in case of a match, otherwise false.
 *
 * Reserved words:
 *   abstract, as, base, bool, break, byte, case, catch, char, checked, class,
 *   const, continue, decimal, default, delegate, do, double, else, enum,
 *   event, explicit, extern, false, finally, fixed, float, for, foreach,
 *   goto, if, implicit, in, int, interface, internal, is, lock, long,
 *   namespace, new, null, object, operator, out, override, params, private,
 *   protected, public, readonly, ref, return, sbyte, sealed, short, sizeof,
 *   stackalloc, static, string, struct, switch, this, throw, true, try,
 *   typeof, uint, ulong, unchecked, unsafe, ushort, using, virtual, void,
 *   volatile, while;
 *
 * Contextual reserved words:
 *   add, alias, ascending, async, await, descending, dynamic, from, get,
 *   global, group, into, join, let, orderby, partial, remove, select, set,
 *   value, var, where, yield; 
 * ------------------------------------------------------------------------ */

bool IsResword (string lexeme);


} /* ICSharpReswords */

} /* namespace */

/* END OF FILE */
