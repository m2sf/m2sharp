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
 * ITerminals.cs
 *
 * Public interface for terminal symbols' token and lexeme lookup.
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
 * type Token
 * ---------------------------------------------------------------------------
 * Enumerated token values representing Modula-2 terminal symbols.
 * ------------------------------------------------------------------------ */

public enum Token {
  /* Null Token */

  Unknown, /* invalid token */

  /* Reserved Words */

  AND, ARGLIST, ARRAY, BEGIN, BY, CASE, CONST, DEFINITION, DIV, DO, ELSE,
  ELSIF, END, EXIT, EXPORT, FOR, FROM, IF, IMPLEMENTATION, IMPORT, IN, LOOP,
  MOD, MODULE, NOT, OF, OPAQUE, OR, POINTER, PROCEDURE, QUALIFIED, RECORD,
  REPEAT, RETURN, SET, THEN, TO, TYPE, UNTIL, VAR, WHILE, WITH,

  /* Identifiers */

  Identifier,

  /* Literals */

  StringLiteral, IntLiteral, RealLiteral, CharLiteral,

  /* Malformed Literals */

  MalformedString, MalformedInteger, MalformedReal, /* invalid tokens */

  /* Pragmas */

  Pragma,

  /* Special Symbols */

  Plus,            /* '+'  */
  Minus,           /* '-'  */
  Equal,           /* '+'  */
  NotEqual,        /* '#'  */
  Less,            /* '<'  */
  LessEqual,       /* '<=' */
  Greater,         /* '>'  */
  GreaterEqual,    /* '>=' */
  Asterisk,        /* '*'  */
  Solidus,         /* '/'  */
  Backslash,       /* '\\' */
  Assign,          /* ':=' */
  Comma,           /* ','  */
  Period,          /* '.'  */
  Colon,           /* ':'  */
  Semicolon,       /* ';'  */
  Range,           /* '..' */
  Deref,           /* '^'  */
  Bar,             /* '|'  */
  LeftParen,       /* '('  */
  RightParen,      /* ')'  */
  LeftBracket,     /* '['  */
  RightBracket,    /* ']'  */
  LeftBrace,       /* '{'  */
  RightBrace,      /* '}'  */
  EndOfFile

  /* Synonyms */

  /*  '&' is a synonym for AND, mapped to token AND */
  /*  '~' is a synonym for NOT, mapped to token NOT */
  /* '<>' is a synonym for '#', mapped to token NOTEQUAL */

} /* Token */


/* ---------------------------------------------------------------------------
 * interface ITerminals
 * ---------------------------------------------------------------------------
 * This interface describes a singleton class.
 * Since C# does not fully support the concept of information hiding, this
 * interface is entirely comprised of comments for documentation purposes.
 * ------------------------------------------------------------------------ */

interface ITerminals {

/* ---------------------------------------------------------------------------
 * method IsValid(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a valid token, otherwise false.
 * ------------------------------------------------------------------------ */

// public static bool IsValid (Token token);


/* ---------------------------------------------------------------------------
 * method IsResword(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a reserved word, otherwise false.
 * ------------------------------------------------------------------------ */

// public static bool IsResword (Token token);


/* ---------------------------------------------------------------------------
 * method IsLiteral(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a literal, otherwise false.
 * ------------------------------------------------------------------------ */

// public static bool IsLiteral (Token token);


/* ---------------------------------------------------------------------------
 * method IsMalformedLiteral(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a malformed literal, otherwise false.
 * ------------------------------------------------------------------------ */

// public static bool IsMalformedLiteral (Token token);


/* ---------------------------------------------------------------------------
 * method IsSpecialSymbol(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a special symbol, otherwise false.
 * ------------------------------------------------------------------------ */

// public static bool IsSpecialSymbol (Token token);


/* ---------------------------------------------------------------------------
 * method TokenForResword(lexeme)
 * ---------------------------------------------------------------------------
 * Tests if the given lexeme represents a reserved word and returns the
 * corresponding token or Unknown if it does not match a reserved word.
 * ------------------------------------------------------------------------ */

// public static Token TokenForResword (string lexeme);


/* ---------------------------------------------------------------------------
 * method LexemeForResword(token)
 * ---------------------------------------------------------------------------
 * Returns a string with the lexeme for the reserved word represented by
 * token.  Returns null if the token does not represent a reserved word.
 * ------------------------------------------------------------------------ */

// public static string LexemeForResword (Token token);


/* ---------------------------------------------------------------------------
 * method LexemeForSpecialSymbol(token)
 * ---------------------------------------------------------------------------
 * Returns a string with the lexeme for the special symbol represented by
 * token.  Returns null if the token does not represent a special symbol.
 * ------------------------------------------------------------------------ */

// public static string LexemeForSpecialSymbol (Token token);


/* ---------------------------------------------------------------------------
 * method NameForToken(token)
 * ---------------------------------------------------------------------------
 * Returns a string with a human readable name for token.  Returns null if
 * token is not a valid token.
 * ------------------------------------------------------------------------ */

// public static string NameForToken (Token token);


} /* ITerminals */

} /* namespace */

/* END OF FILE */
