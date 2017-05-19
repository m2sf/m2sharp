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
 * Terminals.cs
 *
 * Terminal symbols' token and lexeme lookup.
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

public class Terminals : ITerminals {

const Token FirstResWord = Token.AND;
const Token LastResWord = Token.WITH;

const Token FirstLiteral = Token.StringLiteral;
const Token LastLiteral = Token.CharLiteral;

const Token FirstMalformedLiteral = Token.MalformedString;
const Token LastMalformedLiteral = Token.MalformedReal;

const Token FirstSpecialSymbol = Token.Plus;
const Token LastSpecialSymbol = Token.RightBrace;


/* ---------------------------------------------------------------------------
 * method IsValid(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a valid token, otherwise false.
 * ------------------------------------------------------------------------ */

public static bool IsValid (Token token) {
  return (token != Token.Unknown) && !IsMalformedLiteral(token);
} /* end IsValid */


/* ---------------------------------------------------------------------------
 * method IsResword(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a reserved word, otherwise false.
 * ------------------------------------------------------------------------ */

public static bool IsResword (Token token) {
  return (token >= FirstResWord) && (token <= LastResWord);
} /* end IsResword */


/* ---------------------------------------------------------------------------
 * method IsLiteral(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a literal, otherwise false.
 * ------------------------------------------------------------------------ */

public static bool IsLiteral (Token token) {
  return (token >= FirstLiteral) && (token <= LastLiteral);
} /* end IsLiteral */


/* ---------------------------------------------------------------------------
 * method IsMalformedLiteral(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a malformed literal, otherwise false.
 * ------------------------------------------------------------------------ */

public static bool IsMalformedLiteral (Token token) {
  return (token >= FirstMalformedLiteral) && (token <= LastMalformedLiteral);
} /* end IsMalformedLiteral */


/* ---------------------------------------------------------------------------
 * method IsSpecialSymbol(token)
 * ---------------------------------------------------------------------------
 * Returns true if token represents a special symbol, otherwise false.
 * ------------------------------------------------------------------------ */

public static bool IsSpecialSymbol (Token token) {
  return (token >= FirstSpecialSymbol) && (token <= LastSpecialSymbol);
} /* end IsSpecialSymbol */


/* ---------------------------------------------------------------------------
 * method TokenForResword(lexeme)
 * ---------------------------------------------------------------------------
 * Tests if the given lexeme represents a reserved word and returns the
 * corresponding token or Unknown if it does not match a reserved word.
 * ------------------------------------------------------------------------ */

public static Token TokenForResword (string lexeme) {
  int length;

  /* check pre-conditions */
  if (lexeme == null) {
    return Token.Unknown;
  } /* end if */

  length = lexeme.Length;

  if ((length < 2) || (length > 14)) {
    return Token.Unknown;
  } /* end if */

  switch (length) {
    case /* length = 2 */ 2 :
      switch (lexeme[0]) {

        case 'B' :
          /* BY */
          if (lexeme[1] == 'Y') {
            return Token.BY;
          } /* end if */
          break;

        case 'D' :
          /* DO */
          if (lexeme[1] == 'O') {
            return Token.DO;
          } /* end if */
          break;

        case 'I' :
          /* IF */
          if (lexeme[1] == 'F') {
            return Token.IF;
          }
          
          /* IN */
          else if (lexeme[1] == 'N') {
            return Token.IN;
          } /* end if */
          break;

        case 'O' :
          /* OF */
          if (lexeme[1] == 'F') {
            return Token.OF;
          }
        
          /* OR */
          else if (lexeme[1] == 'R') {
            return Token.OR;
          } /* end if */
          break;

        case 'T' :
          /* TO */
          if (lexeme[1] == 'O') {
            return Token.TO;
          } /* end if */
          break;

      } /* end switch */
      break;

    case /* length = 3 */ 3 :
      switch (lexeme[0]) {

        case 'A' :
          /* AND */
          if (string.CompareOrdinal(lexeme, "AND") == 0) {
            return Token.AND;
          } /* end if */
          break;

        case 'D' :
          /* DIV */
          if (string.CompareOrdinal(lexeme, "DIV") == 0) {
            return Token.DIV;
          } /* end if */
          break;

        case 'E' :
          /* END */
          if (string.CompareOrdinal(lexeme, "END") == 0) {
            return Token.END;
          } /* end if */
          break;

        case 'F' :
          /* FOR */
          if (string.CompareOrdinal(lexeme, "FOR") == 0) {
            return Token.FOR;
          } /* end if */
          break;

        case 'M' :
          /* MOD */
          if (string.CompareOrdinal(lexeme, "MOD") == 0) {
            return Token.MOD;
          } /* end if */
          break;

        case 'N' :
          /* NOT */
          if (string.CompareOrdinal(lexeme, "NOT") == 0) {
            return Token.NOT;
          } /* end if */
          break;

        case 'S' :
          /* SET */
          if (string.CompareOrdinal(lexeme, "SET") == 0) {
            return Token.SET;
          } /* end if */
          break;

        case 'V' :
          /* VAR */
          if (string.CompareOrdinal(lexeme, "VAR") == 0) {
            return Token.VAR;
          } /* end if */
          break;

      } /* end switch */
      break;

    case /* length = 4 */ 4 :
      switch (lexeme[1]) {

        case 'A' :
          /* CASE */
          if (string.CompareOrdinal(lexeme, "CASE") == 0) {
            return Token.CASE;
          } /* end if */
          break;

        case 'H' :
          /* THEN */
          if (string.CompareOrdinal(lexeme, "THEN") == 0) {
            return Token.THEN;
          } /* end if */
          break;

        case 'I' :
          /* WITH */
          if (string.CompareOrdinal(lexeme, "WITH") == 0) {
            return Token.WITH;
          } /* end if */
          break;

        case 'L' :
          /* ELSE */
          if (string.CompareOrdinal(lexeme, "ELSE") == 0) {
            return Token.ELSE;
          } /* end if */
          break;

        case 'O' :
          /* LOOP */
          if (string.CompareOrdinal(lexeme, "LOOP") == 0) {
            return Token.LOOP;
          } /* end if */
          break;

        case 'R' :
          /* FROM */
          if (string.CompareOrdinal(lexeme, "FROM") == 0) {
            return Token.FROM;
          } /* end if */
          break;

        case 'X' :
          /* EXIT */
          if (string.CompareOrdinal(lexeme, "EXIT") == 0) {
            return Token.EXIT;
          } /* end if */
          break;

        case 'Y' :
          /* TYPE */
          if (string.CompareOrdinal(lexeme, "TYPE") == 0) {
            return Token.TYPE;
          } /* end if */
          break;

      } /* end switch */
      break;

    case /* length = 5 */ 5 :
      switch (lexeme[0]) {

        case 'A' :
          /* ARRAY */
          if (string.CompareOrdinal(lexeme, "ARRAY") == 0) {
            return Token.ARRAY;
          } /* end if */
          break;

        case 'B' :
          /* BEGIN */
          if (string.CompareOrdinal(lexeme, "BEGIN") == 0) {
            return Token.BEGIN;
          } /* end if */
          break;

        case 'C' :
          /* CONST */
          if (string.CompareOrdinal(lexeme, "CONST") == 0) {
            return Token.CONST;
          } /* end if */
          break;

        case 'E' :
          /* ELSIF */
          if (string.CompareOrdinal(lexeme, "ELSIF") == 0) {
            return Token.ELSIF;
          } /* end if */
          break;

        case 'U' :
          /* UNTIL */
          if (string.CompareOrdinal(lexeme, "UNTIL") == 0) {
            return Token.UNTIL;
          } /* end if */
          break;

        case 'W' :
          /* WHILE */
          if (string.CompareOrdinal(lexeme, "WHILE") == 0) {
            return Token.WHILE;
          } /* end if */
          break;

      } /* end switch */
      break;

    case /* length 6 */ 6 :
      switch (lexeme[2]) {

        case 'D' :
          /* MODULE */
          if (string.CompareOrdinal(lexeme, "MODULE") == 0) {
            return Token.MODULE;
          } /* end if */
          break;

        case 'A' :
          /* OPAQUE */
          if (string.CompareOrdinal(lexeme, "OPAQUE") == 0) {
            return Token.OPAQUE;
          } /* end if */
          break;

        case 'C' :
          /* RECORD */
          if (string.CompareOrdinal(lexeme, "RECORD") == 0) {
            return Token.RECORD;
          } /* end if */
          break;

        case 'T' :
          /* RETURN */
          if (string.CompareOrdinal(lexeme, "RETURN") == 0) {
            return Token.RETURN;
          } /* end if */
          break;

        case 'P' :
          switch (lexeme[0]) {

            case 'E' :
              /* EXPORT */
              if (string.CompareOrdinal(lexeme, "EXPORT") == 0) {
                return Token.EXPORT;
              } /* end if */
              break;

            case 'I' :
              /* IMPORT */
              if (string.CompareOrdinal(lexeme, "IMPORT") == 0) {
                return Token.IMPORT;
              } /* end if */
              break;

            case 'R' :
              /* REPEAT */
              if (string.CompareOrdinal(lexeme, "REPEAT") == 0) {
                return Token.REPEAT;
              } /* end if */
              break;

          } /* end switch */
          break;

      } /* end switch */
      break;

    case /* length = 7 */ 7 :
      switch (lexeme[0]) {

        case 'A' :
          /* ARGLIST */
          if (string.CompareOrdinal(lexeme, "ARGLIST") == 0) {
            return Token.ARGLIST;
          } /* end if */
          break;

        case 'P' :
          /* POINTER */
          if (string.CompareOrdinal(lexeme, "POINTER") == 0) {
            return Token.POINTER;
          } /* end if */
          break;

      } /* end switch */
      break;

    case /* length = 9 */ 9 :
      switch (lexeme[0]) {

        case 'P' :
          /* PROCEDURE */
          if (string.CompareOrdinal(lexeme, "PROCEDURE") == 0) {
            return Token.PROCEDURE;
          } /* end if */
          break;

        case 'Q' :
          /* QUALIFIED */
          if (string.CompareOrdinal(lexeme, "QUALIFIED") == 0) {
            return Token.QUALIFIED;
          } /* end if */
          break;

      } /* end switch */
      break;

    case /* length = 10 */ 10 :
      /* DEFINITION */
      if (string.CompareOrdinal(lexeme, "DEFINITION") == 0) {
        return Token.DEFINITION;
      } /* end if */
      break;

    case /* length = 14 */ 14 :
      /* IMPLEMENTATION */
      if (string.CompareOrdinal(lexeme, "IMPLEMENTATION") == 0) {
        return Token.IMPLEMENTATION;
      } /* end if */
      break;

  } /* end switch (length) */

  return Token.Unknown;
} /* end TokenForResword */


/* ---------------------------------------------------------------------------
 * method LexemeForResword(token)
 * ---------------------------------------------------------------------------
 * Returns a string with the lexeme for the reserved word represented by
 * token.  Returns null if the token does not represent a reserved word.
 * ------------------------------------------------------------------------ */

public static string LexemeForResword (Token token) {
  if (IsResword(token) == false) {
    return null;
  } /* end if */
  return token.ToString();
} /* end LexemeForResword */


/* ---------------------------------------------------------------------------
 * method LexemeForSpecialSymbol(token)
 * ---------------------------------------------------------------------------
 * Returns a string with the lexeme for the special symbol represented by
 * token.  Returns null if the token does not represent a special symbol.
 * ------------------------------------------------------------------------ */

public static string LexemeForSpecialSymbol (Token token) {
  if (IsSpecialSymbol(token) == false) {
    return null;
  } /* end if */
  return ""; // TO DO
} /* end LexemeForSpecialSymbol */


/* ---------------------------------------------------------------------------
 * method NameForToken(token)
 * ---------------------------------------------------------------------------
 * Returns a string with a human readable name for token.  Returns null if
 * token is not a valid token.
 * ------------------------------------------------------------------------ */

public static string NameForToken (Token token) {
  return token.ToString();
} /* NameForToken */


} /* Terminals */

} /* namespace */

/* END OF FILE */
