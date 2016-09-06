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
 * IAstNode.cs
 *
 * Public abstract syntax tree (AST) interface.
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

/* ---------------------------------------------------------------------------
 * AST status codes
 * ------------------------------------------------------------------------ */

public enum AstNodeStatus {
  Success,
  TODO
} /* AstNodeStatus */


public interface IAstNode {

/* ---------------------------------------------------------------------------
 * method EmptyNode()
 * ---------------------------------------------------------------------------
 * Returns the empty node singleton.
 * ------------------------------------------------------------------------ */

Result<IAstNode, AstNodeStatus> EmptyNode ();


/* ---------------------------------------------------------------------------
 * constructor NewNode(nodeType, subnode0, subnode1, subnode2, ...)
 * ---------------------------------------------------------------------------
 * Creates new branch node of the given node type, stores the subnodes of
 * the argument list in the node and returns the node, or null on failure.
 *
 * pre-conditions:
 * o  node_type must be a valid node type
 * o  a non-empty list of valid ast nodes must be passed
 *    and type and number of subnodes must match the given node type.
 *
 * post-conditions:
 * o  newly created ast node is returned
 *
 * error-conditions:
 * o  if node_type is invalid, no node is created and null is returned
 * o  if type and number of subnodes does not match the given node type,
 *    no node is created and null is returned
 * ------------------------------------------------------------------------ */

Result<IAstNode, AstNodeStatus>
  NewNode (IAstNodeType nodeType, params IAstNode[] subnodes);


/* ---------------------------------------------------------------------------
 * method NewListNode(nodeType, nodeList)
 * ---------------------------------------------------------------------------
 * Allocates a new branch node of the given node type, stores the subnodes of
 * the given node list in the node and returns the node, or null on failure.
 * ------------------------------------------------------------------------ */

Result<IAstNode, AstNodeStatus>
  NewListNode (IAstNodeType nodeType, NodeList list);


/* ---------------------------------------------------------------------------
 * method NewTerminalNode(nodeType, value)
 * ---------------------------------------------------------------------------
 * Allocates a new terminal node of the given node type, stores the given
 * terminal value in the node and returns the node, or null on failure.
 * ------------------------------------------------------------------------ */

Result<IAstNode, AstNodeStatus>
  NewTerminalNode (IAstNodeType nodeType, string value);


/* ---------------------------------------------------------------------------
 * method NewTerminalListNode(nodeType, terminalValueList)
 * ---------------------------------------------------------------------------
 * Allocates a new terminal node of the given node type, stores the values of
 * the given value list in the node and returns the node, or null on failure.
 * ------------------------------------------------------------------------ */

Result<IAstNode, AstNodeStatus>
  NewTerminalListNode (IAstNodeType nodeType, TermList list);


/* ---------------------------------------------------------------------------
 * method NodeTypeOf(node)
 * ---------------------------------------------------------------------------
 * Returns the node type of node, or null if node is null.
 * ------------------------------------------------------------------------ */

IAstNodeType NodeTypeOf (IAstNode node);


/* ---------------------------------------------------------------------------
 * method SubnodeCountOf(node)
 * ---------------------------------------------------------------------------
 * Returns the number of subnodes or values of node. 
 * ------------------------------------------------------------------------ */

int SubnodeCountOf (IAstNode node);


/* ---------------------------------------------------------------------------
 * method SubnodeForIndex(node, index)
 * ---------------------------------------------------------------------------
 * Returns the subnode of node with the given index or null if no subnode of
 * the given index is stored in node.
 * ------------------------------------------------------------------------ */

Result<IAstNode, AstNodeStatus> SubnodeForIndex (IAstNode node, int index);


/* ---------------------------------------------------------------------------
 * method ValueForIndex(node, index)
 * ---------------------------------------------------------------------------
 * Returns the value stored at the given index in a terminal node,
 * or NULL if the node does not store any value at the given index.
 * ------------------------------------------------------------------------ */

string ValueForIndex (IAstNode node, int index);


/* ---------------------------------------------------------------------------
 * convenience method Value(node)
 * ---------------------------------------------------------------------------
 * Invokes ValueForIndex() with an index of zero. 
 * ------------------------------------------------------------------------ */

string value (IAstNode node);


/* ---------------------------------------------------------------------------
 * method replaceSubnode(inNode, atIndex, withSubnode)
 * ---------------------------------------------------------------------------
 * Replaces a subnode and returns the replaced node, or null on failure.
 * ------------------------------------------------------------------------ */

Result<IAstNode, AstNodeStatus>
  ReplaceSubnode (IAstNode inNode, int atIndex, IAstNode withSubnode);


/* ---------------------------------------------------------------------------
 * method ReplaceValue(inNode, atIndex, withValue)
 * ---------------------------------------------------------------------------
 * Replaces a value and returns the replaced value, or null on failure.
 * ------------------------------------------------------------------------ */

string ReplaceValue (IAstNode inNode, int atIndex, string withValue);


} /* IAstNode */

} /* namespace */

/* END OF FILE */
