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
 * IAstNodeQueue.cs
 *
 * Public interface for AST node queue type.
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

public interface IAstNodeQueue {

/* --------------------------------------------------------------------------
 * constructor newFromList(node, ...)
 * --------------------------------------------------------------------------
 * Returns a newly allocated AST node queue object that includes the nodes
 * passed as arguments of a variadic argument list.
 * ----------------------------------------------------------------------- */

// public static AstNodeQueue newFromList (params AstNode[] nodeList);


/* --------------------------------------------------------------------------
 * method Count()
 * --------------------------------------------------------------------------
 * Returns the number of nodes in the receiver.
 * ----------------------------------------------------------------------- */

public uint Count ();


/* --------------------------------------------------------------------------
 * method Contains(node)
 * --------------------------------------------------------------------------
 * Returns true if node is stored in the receiver, else false.
 * ----------------------------------------------------------------------- */

public bool Contains (AstNode node);


/* --------------------------------------------------------------------------
 * method Enqueue(node)
 * --------------------------------------------------------------------------
 * Enqueues node in the receiver.  Returns true on success, else false.
 * ----------------------------------------------------------------------- */

public bool Enqueue (AstNode node);


/* --------------------------------------------------------------------------
 * method EnqueueUnique(node)
 * --------------------------------------------------------------------------
 * Enqueues node in the receiver if and only if the node is not already
 * present in the receiver.  Returns true on success, else false.
 * ----------------------------------------------------------------------- */

public bool EnqueueUnique (AstNode node);


/* --------------------------------------------------------------------------
 * method Dequeue()
 * --------------------------------------------------------------------------
 * Removes the tail of the receiver and returns it, or null on failure.
 * ----------------------------------------------------------------------- */

public AstNode Dequeue ();


/* --------------------------------------------------------------------------
 * method Reset()
 * --------------------------------------------------------------------------
 * Removes all entries from the receiver.
 * ----------------------------------------------------------------------- */

public void Reset ();


} /* IAstNodeQueue */

} /* M2SF.M2Sharp */

/* END OF FILE */