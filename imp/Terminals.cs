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
	      }

	      else {
	        return Token.Unknown;
	      } /* end if */
	
	    case 'D' :
	      /* DO */
	      if (lexeme[1] == 'O') {
	        return Token.DO;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	
	    case 'I' :
	      /* IF */
	      if (lexeme[1] == 'F') {
	        return Token.IF;
	      }
	  	    
	      /* IN */
	      else if (lexeme[1] == 'N') {
	        return Token.IN;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	    
	    case 'O' :
	      /* OF */
	      if (lexeme[1] == 'F') {
	        return Token.OF;
	      }
	      
	      /* OR */
	      else if (lexeme[1] == 'R') {
	        return Token.OR;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	    
	    case 'T' :
	      /* TO */
	      if (lexeme[1] == 'O') {
	        return Token.TO;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	    
	    default :
	      return Token.Unknown;
	  } /* end switch */
	
    case /* length = 3 */ 3 :
      switch (lexeme[0]) {
      
	    case 'A' :
	      /* AND */
        if (string.CompareOrdinal(lexeme, "AND") == 0) {
	        return Token.AND;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
        	
	    case 'D' :
	      /* DIV */
        if (string.CompareOrdinal(lexeme, "DIV") == 0) {
	        return Token.DIV;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	
	    case 'E' :
	      /* END */
        if (string.CompareOrdinal(lexeme, "END") == 0) {
	        return Token.END;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'F' :
	      /* FOR */
        if (string.CompareOrdinal(lexeme, "FOR") == 0) {
	        return Token.FOR;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'M' :
	      /* MOD */
        if (string.CompareOrdinal(lexeme, "MOD") == 0) {
	        return Token.MOD;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'N' :
	      /* NOT */
        if (string.CompareOrdinal(lexeme, "NOT") == 0) {
	        return Token.NOT;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'S' :
	      /* SET */
        if (string.CompareOrdinal(lexeme, "SET") == 0) {
	        return Token.SET;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'V' :
	      /* VAR */
        if (string.CompareOrdinal(lexeme, "VAR") == 0) {
	        return Token.VAR;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    default :
	      return Token.Unknown;
	  } /* end switch */
	
    case /* length = 4 */ 4 :
      switch (lexeme[1]) {
      
	    case 'A' :
	      /* CASE */
        if (string.CompareOrdinal(lexeme, "CASE") == 0) {
	        return Token.CASE;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'H' :
	      /* THEN */
        if (string.CompareOrdinal(lexeme, "THEN") == 0) {
	        return Token.THEN;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'I' :
	      /* WITH */
        if (string.CompareOrdinal(lexeme, "WITH") == 0) {
	        return Token.WITH;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'L' :
	      /* ELSE */
        if (string.CompareOrdinal(lexeme, "ELSE") == 0) {
	        return Token.ELSE;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'O' :
	      /* LOOP */
        if (string.CompareOrdinal(lexeme, "LOOP") == 0) {
	        return Token.LOOP;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'R' :
	      /* FROM */
        if (string.CompareOrdinal(lexeme, "FROM") == 0) {
	        return Token.FROM;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'X' :
	      /* EXIT */
        if (string.CompareOrdinal(lexeme, "EXIT") == 0) {
	        return Token.EXIT;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
        case 'Y' :
          /* TYPE */
        if (string.CompareOrdinal(lexeme, "TYPE") == 0) {
	        return Token.TYPE;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    default :
	      return Token.Unknown;
	  } /* end switch */
	
    case /* length = 5 */ 5 :
      switch (lexeme[0]) {
      
	    case 'A' :
	      /* ARRAY */
        if (string.CompareOrdinal(lexeme, "ARRAY") == 0) {
	        return Token.ARRAY;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'B' :
	      /* BEGIN */
        if (string.CompareOrdinal(lexeme, "BEGIN") == 0) {
	        return Token.BEGIN;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'C' :
	      /* CONST */
        if (string.CompareOrdinal(lexeme, "CONST") == 0) {
	        return Token.CONST;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'E' :
	      /* ELSIF */
        if (string.CompareOrdinal(lexeme, "ELSIF") == 0) {
	        return Token.ELSIF;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'U' :
	      /* UNTIL */
        if (string.CompareOrdinal(lexeme, "UNTIL") == 0) {
	        return Token.UNTIL;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'W' :
	      /* WHILE */
        if (string.CompareOrdinal(lexeme, "WHILE") == 0) {
	        return Token.WHILE;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    default :
	      return Token.Unknown;
	  } /* end switch */
	
    case /* length 6 */ 6 :
      switch (lexeme[5]) {
      
	    case 'E' :
	      /* MODULE */
        if (string.CompareOrdinal(lexeme, "MODULE") == 0) {
	        return Token.MODULE;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'D' :
	      /* RECORD */
        if (string.CompareOrdinal(lexeme, "RECORD") == 0) {
	        return Token.RECORD;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'N' :
	      /* RETURN */
        if (string.CompareOrdinal(lexeme, "RETURN") == 0) {
	        return Token.RETURN;
	      }
	      
	      else {
	        return Token.Unknown;
	      } /* end if */
	      
	    case 'T' :
	      switch (lexeme[0]) {
	      
	        case 'E' :
	          /* EXPORT */
        if (string.CompareOrdinal(lexeme, "EXPORT") == 0) {
	            return Token.EXPORT;
	          }
	          
	          else {
	            return Token.Unknown;
	          } /* end if */
	        
	        case 'I' :
	          /* IMPORT */
        if (string.CompareOrdinal(lexeme, "IMPORT") == 0) {
	            return Token.IMPORT;
	          }
	          
	          else {
	            return Token.Unknown;
	          } /* end if */
	        
	        case 'R' :
	          /* REPEAT */
        if (string.CompareOrdinal(lexeme, "REPEAT") == 0) {
	            return Token.REPEAT;
	          }
	          
	          else {
	            return Token.Unknown;
	          } /* end if */
	          
	        default :
	          return Token.Unknown;
	      } /* end switch */
	      
	    default :
	      return Token.Unknown;
	  } /* end switch */
	
    case /* length = 7 */ 7 :
      /* POINTER */
        if (string.CompareOrdinal(lexeme, "POINTER") == 0) {
	    return Token.POINTER;
      }
      
      else {
	    return Token.Unknown;
      } /* end if */
      
    case /* length = 9 */ 9 :
      switch (lexeme[0]) {
      
        case 'P' :
          /* PROCEDURE */
        if (string.CompareOrdinal(lexeme, "PROCEDURE") == 0) {
	        return Token.PROCEDURE;
          }
          
          else {
	        return Token.Unknown;
          } /* end if */
        
        case 'Q' :
          /* QUALIFIED */
        if (string.CompareOrdinal(lexeme, "QUALIFIED") == 0) {
	        return Token.QUALIFIED;
          }
          
          else {
	        return Token.Unknown;
          } /* end if */
        
        default :
	      return Token.Unknown;
      } /* end switch */
	
    case /* length = 10 */ 10 :
      /* DEFINITION */
        if (string.CompareOrdinal(lexeme, "DEFINITION") == 0) {
	    return Token.DEFINITION;
      }
      
      else {
	      return Token.Unknown;
      } /* end if */
    
    case /* length = 14 */ 14 :
      /* IMPLEMENTATION */
        if (string.CompareOrdinal(lexeme, "IMPLEMENTATION") == 0) {
	      return Token.IMPLEMENTATION;
      }
      
      else {
	      return Token.Unknown;
      } /* end if */
    
    default :
      return Token.Unknown;
  } /* end switch (length) */


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


} /* ITerminals */

} /* namespace */

/* END OF FILE */