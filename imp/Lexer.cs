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
 * Lexer.cs
 *
 * Lexer class.
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


public class Lexer : ILexer {

private const uint DefaultMaxIdentLength = 32;
private const uint DefaultCommentNestingLimit = 100;

private struct Symbol {
  public Token token;
  public uint line;
  public uint column;
  public string lexeme;
} /* end Symbol */

private Infile infile;
private Symbol currentSym;
private Symbol lookaheadSym;

private uint errorCount;
private LexerStatus status;


/* ---------------------------------------------------------------------------
 * Lexical limits
 * ------------------------------------------------------------------------ */

public uint MaxIdentLength() {
  return DefaultMaxIdentLength;
} /* end MaxIdentLength */

public uint CommentNestingLimit () {
  return DefaultCommentNestingLimit;
} /* end CommentNestingLimit */


/* ---------------------------------------------------------------------------
 * factory method newLexer(filename)
 * ---------------------------------------------------------------------------
 * Creates a new lexer instance, opens an input file, associates the file with
 * the newly created lexer and returns a Result pair with the lexer reference
 * and a status value.
 *
 * pre-conditions:
 * o  filename must refer to an existing and accessible input file 
 *
 * post-conditions:
 * o  lexer is created
 * o  status is set to Success
 *
 * error-conditions:
 * o  if the file represented by filename cannot be found
 *    lexer is set to null, status is set to FileNotFound
 * o  if the file represented by filename cannot be accessed
 *    lexer is set to null, status is set to FileAccessDenied
 * ----------------------------------------------------------------------- */

public static Result<ILexer, LexerStatus> NewLexer (string filename) {
  return new Result<ILexer, LexerStatus> (null, LexerStatus.Success);
} /* end NewLexer */


/* ---------------------------------------------------------------------------
 * private constructor Lexer ()
 * ---------------------------------------------------------------------------
 * Prevents clients from invoking the constructor. Clients must use NewLexer()
 * ------------------------------------------------------------------------ */

private Lexer () {
  // no operation
} /* end Lexer */


/* --------------------------------------------------------------------------
 * method ReadSym()
 * --------------------------------------------------------------------------
 * Reads the lookahead symbol from the source file associated with lexer and
 * consumes it, thus advancing the current reading position, then returns
 * the symbol's token.
 *
 * pre-conditions:
 * o  lexer instance must have been created with constructor NewLexer()
 *    so that it is associated with an input source file
 *
 * post-conditions:
 * o  character code of lookahead character or EOF is returned
 * o  current reading position and line and column counters are updated
 * o  file status is set to Success
 *
 * error-conditions:
 * o  if no source file is associated with lexer, no operation is carried out
 *    and status is set to NotInitialized
 * ----------------------------------------------------------------------- */

public Token ReadSym() {

  /* lookahead symbol becomes current symbol */
  currentSym = lookaheadSym;
  
  /* read new lookahead symbol */
  GetNewLookaheadSym();
  
  /* return current token */
  return currentSym.token;

} /* end ReadSym */


/* --------------------------------------------------------------------------
 * method NextSym()
 * --------------------------------------------------------------------------
 * Reads the lookahead symbol from the source file associated with lexer but
 * does not consume it, thus not advancing the current reading position,
 * then returns the symbol's token.
 *
 * pre-conditions:
 * o  lexer instance must have been created with constructor NewLexer()
 *    so that it is associated with an input source file
 *
 * post-conditions:
 * o  token of lookahead symbol is returned
 * o  current reading position and line and column counters are NOT updated
 * o  file status is set to Success
 *
 * error-conditions:
 * o  if no source file is associated with lexer, no operation is carried out
 *    and status is set to NotInitialized
 * ----------------------------------------------------------------------- */

public Token NextSym () {
  return lookaheadSym.token;
} /* end NextSym */


/* --------------------------------------------------------------------------
 * method ConsumeSym()
 * --------------------------------------------------------------------------
 * Consumes the lookahead symbol and returns the token of the new lookahead
 * symbol.
 * ----------------------------------------------------------------------- */

public Token ConsumeSym () {

  /* lookahead symbol becomes current symbol */
  currentSym = lookaheadSym;
  
  /* read new lookahead symbol and return it */
  GetNewLookaheadSym();

  return lookaheadSym.token;

} /* end ConsumeSym */


/* --------------------------------------------------------------------------
 * method Filename()
 * --------------------------------------------------------------------------
 * Returns the filename associated with the lexer instance.
 * ----------------------------------------------------------------------- */

public string Filename () {
  return infile.Filename();
} /* end Filename */


/* --------------------------------------------------------------------------
 * method Status()
 * --------------------------------------------------------------------------
 * Returns the status of the last operation on lexer.
 * ----------------------------------------------------------------------- */

public LexerStatus Status () {
  return status;
} /* end Status */


/* --------------------------------------------------------------------------
 * method LookaheadLexeme()
 * --------------------------------------------------------------------------
 * Returns the lexeme of the lookahead symbol.
 * ----------------------------------------------------------------------- */

public string LookaheadLexeme () {
  return lookaheadSym.lexeme;
} /* end LookaheadLexeme */


/* --------------------------------------------------------------------------
 * method CurrentLexeme()
 * --------------------------------------------------------------------------
 * Returns the lexeme of the most recently consumed symbol.
 * ----------------------------------------------------------------------- */

public string CurrentLexeme () {
  return currentSym.lexeme;
} /* end CurrentLexeme */


/* --------------------------------------------------------------------------
 * method LookaheadLine()
 * --------------------------------------------------------------------------
 * Returns the line counter of the lookahead symbol.
 * ----------------------------------------------------------------------- */

public uint LookaheadLine () {
  return lookaheadSym.line;
} /* end LookaheadLine */


/* --------------------------------------------------------------------------
 * method CurrentLine()
 * --------------------------------------------------------------------------
 * Returns the line counter of the most recently consumed symbol.
 * ----------------------------------------------------------------------- */

public uint CurrentLine () {
  return currentSym.line;
} /* end CurrentLine */


/* --------------------------------------------------------------------------
 * method lookaheadColumn()
 * --------------------------------------------------------------------------
 * Returns the column counter of the lookahead symbol.
 * ----------------------------------------------------------------------- */

public uint LookaheadColumn () {
  return lookaheadSym.column;
} /* end LookaheadColumn */


/* --------------------------------------------------------------------------
 * method CurrentColumn()
 * --------------------------------------------------------------------------
 * Returns the column counter of the most recently consumed symbol.
 * ----------------------------------------------------------------------- */

public uint CurrentColumn () {
  return currentSym.column;
} /* end CurrentColumn */


/* --------------------------------------------------------------------------
 * method PrintLineAndMarkColumn(line, column)
 * --------------------------------------------------------------------------
 * Prints the given source line of the current symbol to the console and
 * marks the given coloumn with a caret '^'.
 * ----------------------------------------------------------------------- */

public void PrintLineAndMarkColumn (uint line, uint column) {

} /* end PrintLineAndMarkColumn */


/* --------------------------------------------------------------------------
 * private method GetNewLookaheadSym()
 * --------------------------------------------------------------------------
 * Reads the next symbol from infile, sets currentSym and lookaheadSym.
 * ----------------------------------------------------------------------- */

private void GetNewLookaheadSym () {
  Token token;
  char nextChar;
  uint line = 0;
  uint column = 0;

  /* no token yet */
  token = Token.Unknown;

  /* get the lookahead character */
  nextChar = infile.NextChar();

  while (token == Token.Unknown) {
  
    /* skip all whitespace and line feeds */
    while ((nextChar == ASCII.SPACE) ||
           (nextChar == ASCII.TAB) ||
           (nextChar == ASCII.LF)) {
      
      /* consume the character and get new lookahead */
      nextChar = infile.ConsumeChar();
    } /* end while */

    line = infile.CurrentLine();
    column = infile.CurrentColumn();

    switch (nextChar) {

      case ASCII.EOT :
        /* End-of-File marker */
        if (infile.Status() == InfileStatus.AttemptToReadPastEOF) {
          token = Token.EndOfFile;
        }
        else /* invalid char */ {
          // TO DO : report error with offending character
          token = Token.Unknown;
        } /* end if */
        break;

      case '!' :
        /* line comment */
        if (Capabilities.LineComments()) {
          nextChar = SkipLineComment();
        }
        else /* illegal character */ {
          // TO DO : report error with offending character
          token = Token.Unknown;
        } /* end if */
        break;

      case '"' :
        /* string literal */
        nextChar = GetStringLiteral(out token);
        if (token == Token.MalformedString) {
          // TO DO : report error with offending position
        } /* end if */
        break;

      case '#' :
        /* not-equal operator */
        nextChar = infile.ConsumeChar();
        token = Token.NotEqual;
        break;

      case '&' :
        /* ampersand synonym */
        if (Capabilities.Synonyms()) {
          nextChar = infile.ConsumeChar();
          token = Token.AND;
        }
        else /* illegal character */ {
          // TO DO : report error with offending character
          token = Token.Unknown;
        } /* end if */
        break;

      case '\'' :
        /* string literal */
        nextChar = GetStringLiteral(out token);
        if (token == Token.MalformedString) {
          // TO DO : report error with offending position
        } /* end if */
        break;

      case '(' :
        /* left parenthesis */
        if (infile.LA2Char() != '*') {
          nextChar = infile.ConsumeChar();
          token = Token.LeftParen;
        }
        else /* block comment */ {
          nextChar = SkipBlockComment();
          token = Token.Unknown;
        }
        break;

      case ')' :
        /* right parenthesis */
          nextChar = infile.ConsumeChar();
          token = Token.RightParen;
        break;

      case '*' :
        /* asterisk operator */
          nextChar = infile.ConsumeChar();
          token = Token.Asterisk;
        break;

      case '+' :
        /* plus operator */
          nextChar = infile.ConsumeChar();
          token = Token.Plus;
        break;

      case ',' :
        /* comma */
          nextChar = infile.ConsumeChar();
          token = Token.Comma;
        break;

      case '-' :
        /* minus operator */
          nextChar = infile.ConsumeChar();
          token = Token.Minus;
        break;

      case '.' :
        /* range or period */
        nextChar = infile.ConsumeChar();
        if /* range */ (nextChar == '.') {
          nextChar = infile.ConsumeChar();
          token = Token.Range;
        }
        else /* period */ {
          token = Token.Period;
        } /* end if */
        break;

      case '/' :
        /* solidus operator */
          nextChar = infile.ConsumeChar();
          token = Token.Solidus;
        break;

      case '0' :
      case '1' :
      case '2' :
      case '3' :
      case '4' :
      case '5' :
      case '6' :
      case '7' :
      case '8' :
      case '9' :
        /* number literal */
        nextChar = GetNumberLiteral(out token);
        if (token == Token.MalformedInteger) {
          // TO DO : report error with position
        }
        else if (token == Token.MalformedReal) {
          // TO DO : report error with position
        } /* end if */
        break;

      case ':' :
        /* assignment or colon*/
        nextChar = infile.ConsumeChar();
        if /* assignment */ (nextChar == '=') {
          nextChar = infile.ConsumeChar();
          token = Token.Assign;
        }
        else /* colon */ {
          token = Token.Colon;
        } /* end if */
        break;

      case ';' :
        /* semicolon */
        nextChar = infile.ConsumeChar();
        token = Token.Semicolon;
        break;

      case '<' :
        if (Capabilities.IsoPragmaDelimiters() && (infile.LA2Char() == '*')) {
          /* pragma */
          nextChar = GetPragma();
          token = Token.Pragma;
          break;
        } /* end if */

        /* not-equal, less-equal or less operator */
        nextChar = infile.ConsumeChar();
        if (Capabilities.Synonyms() && (nextChar == '>')) {
          /* not-equal synonym */
          nextChar = infile.ConsumeChar();
          token = Token.NotEqual;
        }
        else if /* less-equal */ (nextChar == '=') {
          nextChar = infile.ConsumeChar();
          token = Token.LessEqual;
        }
        else /* less */ {
          token = Token.Less;
        } /* end if */
        break;

      case '=' :
        /* equal operator */
        nextChar = infile.ConsumeChar();
        token = Token.Equal;
        break;

      case '>' :
        /* greater-equal or greater operator */
        nextChar = infile.ConsumeChar();
        if /* greater-equal */ (nextChar == '=') {
          nextChar = infile.ConsumeChar();
          token = Token.GreaterEqual;
        }
        else /* greater */ {
          token = Token.Greater;
        } /* end if */
        break;

      case '?' :
        /* disabled code section tag */
        if ((column == 1) && (infile.LA2Char() == '<')) {
          nextChar = SkipCodeSection();
        }
        else /* invalid character */ {
          // TO DO : report error with offending character
          token = Token.Unknown;
        } /* end if */
        break;

      case 'A' :
      case 'B' :
      case 'C' :
      case 'D' :
      case 'E' :
      case 'F' :
      case 'G' :
      case 'H' :
      case 'I' :
      case 'J' :
      case 'K' :
      case 'L' :
      case 'M' :
      case 'N' :
      case 'O' :
      case 'P' :
      case 'Q' :
      case 'R' :
      case 'S' :
      case 'T' :
      case 'U' :
      case 'V' :
      case 'W' :
      case 'X' :
      case 'Y' :
      case 'Z' :
        /* identifier or reserved word */
        nextChar = GetIdentOrResword(out token);
        break;

      case '[' :
        /* left bracket */
        nextChar = infile.ConsumeChar();
        token = Token.LeftBracket;
        break;

      case ASCII.BACKSLASH :
        /* backslash */
        if (Capabilities.BackslashSetDiffOp()) {
          nextChar = infile.ConsumeChar();
          token = Token.Backslash;
        }
        else /* illegal character */ {
          // TO DO : report error with offending character
          token = Token.Unknown;
        } /* end if */
        break;

      case ']' :
        /* right bracket */
        nextChar = infile.ConsumeChar();
        token = Token.RightBracket;
        break;

      case '^' :
        /* caret */
        nextChar = infile.ConsumeChar();
        token = Token.Deref;
        break;

      case 'a' :
      case 'b' :
      case 'c' :
      case 'd' :
      case 'e' :
      case 'f' :
      case 'g' :
      case 'h' :
      case 'i' :
      case 'j' :
      case 'k' :
      case 'l' :
      case 'm' :
      case 'n' :
      case 'o' :
      case 'p' :
      case 'q' :
      case 'r' :
      case 's' :
      case 't' :
      case 'u' :
      case 'v' :
      case 'w' :
      case 'x' :
      case 'y' :
      case 'z' :
        /* identifier */
        nextChar = GetIdent();
        token = Token.Identifier;
        break;

      case '{' :
        /* left brace */
        nextChar = infile.ConsumeChar();
        token = Token.LeftBrace;
        break;

      case '|' :
        /* vertical bar */
        nextChar = infile.ConsumeChar();
        token = Token.Bar;
        break;

      case '}' :
        /* right brace */
        nextChar = infile.ConsumeChar();
        token = Token.RightBrace;
        break;

      case '~' :
        /* tilde synonym */
        if (Capabilities.Synonyms()) {
          nextChar = infile.ConsumeChar();
          token = Token.NOT;
        }
        else /* illegal character */ {
          // TO DO : report error with offending character
          token = Token.Unknown;
        } /* end if */
        break;

      default :
        /* invalid character */
        break;

    } /* end switch */
  } /* end while */

  /* update lexer's lookahead symbol */
  lookaheadSym.token = token;
  lookaheadSym.line = line;
  lookaheadSym.column = column;

  return;
} /* end GetNewLookaheadSym */


/* ---------------------------------------------------------------------------
 * private method SkipLineComment()
 * ------------------------------------------------------------------------ */

private char SkipLineComment () {
  char nextChar;

  /* consume opening '!' */
  nextChar = infile.ConsumeChar();

  while ((nextChar != ASCII.LF) && (!infile.EOF())) {

    /* check for illegal characters */
    if (ASCII.IsCtrl(nextChar) && (nextChar != ASCII.TAB)) {
      /* invalid input character */

      // TO DO : report error with offending char

    } /* end if */

    nextChar = infile.ConsumeChar();
  } /* end while */

  return nextChar;
} /* end SkipLineComment */


/* ---------------------------------------------------------------------------
 * private method SkipBlockComment()
 * ------------------------------------------------------------------------ */

private char SkipBlockComment () {
  uint line, column, nestLevel = 1;
  char nextChar;

  /* consume opening '(' and '*' */
  nextChar = infile.ConsumeChar();
  nextChar = infile.ConsumeChar();

  while (nestLevel > 0) {

    /* check for opening block comment */
    if (nextChar == '(') {
      nextChar = infile.ConsumeChar();
      if (nextChar == '*') {
        nextChar = infile.ConsumeChar();
        nestLevel++;
      } /* end if */
    }

    /* check for closing block comment */
    else if (nextChar == '*') {
      nextChar = infile.ConsumeChar();
      if (nextChar == ')') {
        nextChar = infile.ConsumeChar();
        nestLevel--;
      } /* end if */
    }

    /* other characters permitted within block comments */
    else if ((!ASCII.IsCtrl(nextChar)) ||
             (nextChar == ASCII.TAB) ||
             (nextChar == ASCII.LF)) {
      nextChar = infile.ConsumeChar();
    }
    
    else /* error */ {
      line = infile.CurrentLine();
      column = infile.CurrentColumn();
      
      /* end-of-file reached */
      if (infile.EOF()) {
        // report error with offending position
        // premature EOF within block comment
      }
      else /* illegal character */ {
        // report error with offending char
        // invalid input character
        nextChar = infile.ConsumeChar();
      } /* end if */
    } /* end if */
  } /* end while */

  return nextChar;
} /* end SkipBlockComment */


/* ---------------------------------------------------------------------------
 * private method SkipCodeSection()
 * ------------------------------------------------------------------------ */

private char SkipCodeSection () {
  bool delimiterFound = false;
  uint firstLine;
  char nextChar;  

  /* remember line number for warning */
  firstLine = infile.CurrentLine();

  /* consume opening '?' and '<' */
  nextChar = infile.ConsumeChar();
  nextChar = infile.ConsumeChar();

  while ((!delimiterFound) && (!infile.EOF())) {

    /* check for closing delimiter */
    if ((nextChar == '>') && (infile.LA2Char() == '?') &&
       /* first column */ (infile.CurrentColumn() == 1)) {
      
      /* closing delimiter */
      delimiterFound = true;
        
      /* consume closing '>' and '?' */
      nextChar = infile.ConsumeChar();
      nextChar = infile.ConsumeChar();
      break;
    } /* end if */

    /* check for illegal control characters */
    if ((ASCII.IsCtrl(nextChar)) &&
        (nextChar != ASCII.TAB) &&
        (nextChar != ASCII.LF)) {
      /* invalid input character */
      // report error with offending char
    } /* end if */
    
    nextChar = infile.ConsumeChar();
  } /* end while */

  // TO DO : emit warning about disabled code section
  //         with line numbers of first and last lines

  return nextChar;
} /* end SkipCodeSection */


/* ---------------------------------------------------------------------------
 * private method GetPragma()
 * ------------------------------------------------------------------------ */

private char GetPragma () {
  bool delimiterFound = false;
  uint line, column;
  char nextChar;  

  infile.MarkLexeme();

  /* consume opening '<' and '*' */
  nextChar = infile.ConsumeChar();
  nextChar = infile.ConsumeChar();

  while (!delimiterFound) {

    if /* closing delimiter */
      ((nextChar == '*') && (infile.LA2Char() == '>')) {
      
      delimiterFound = true;
            
      /* consume closing '*' and '>' */
      nextChar = infile.ConsumeChar();
      nextChar = infile.ConsumeChar();
      
      /* get lexeme */
      lookaheadSym.lexeme = infile.ReadMarkedLexeme();
    }

    /* other non-control characters */
    else if (!ASCII.IsCtrl(nextChar)) {
      nextChar = infile.ConsumeChar();
    }
    
    else /* error */ {
      line = infile.CurrentLine();
      column = infile.CurrentLine();
      
      /* end-of-file reached */
      if (infile.EOF()) {
        // report error with offending position
        // premature EOF within pragma at line and column
      }
      else /* illegal character */ {
        // report error with offending character
        // invalid input character at line and column
        nextChar = infile.ConsumeChar();
      } /* end if */
      errorCount++;
    } /* end if */
  } /* end while */

  return nextChar;
} /* end GetPragma */


/* ---------------------------------------------------------------------------
 * private method GetIdent()
 * ------------------------------------------------------------------------ */

private char GetIdent () {
  char nextChar;
  
  infile.MarkLexeme();
  nextChar = infile.NextChar();

  if (CompilerOptions.LowlineIdentifiers()) {

   /* get alpha-numeric or foreign identifier */  
    while (ASCII.IsAlnum(nextChar)) {
      nextChar = infile.ConsumeChar();

      /* check for lowline in between two alpha-numeric characters */
      if ((nextChar == '_') && (ASCII.IsAlnum(infile.LA2Char()))) {
        nextChar = infile.ConsumeChar();
      } /* end if */

    } /* end while */
  }
  else /* no lowline identifiers */ {

   /* get alpha-numeric identifier */
    while (ASCII.IsAlnum(nextChar)) {
      nextChar = infile.ConsumeChar();
    } /* end while */
  } /* end if */
  
  /* get lexeme */
  lookaheadSym.lexeme = infile.ReadMarkedLexeme();
    
  return nextChar;
} /* end GetIdent */


/* ---------------------------------------------------------------------------
 * private method GetIdentOrResword()
 * ------------------------------------------------------------------------ */

private char GetIdentOrResword (out Token token) {
  char nextChar;
  Token intermediate;
  bool possiblyResword = true;

  infile.MarkLexeme();
  nextChar = infile.NextChar();

  if (CompilerOptions.LowlineIdentifiers()) {

   /* get alpha-numeric or foreign identifier */  
    while (ASCII.IsAlnum(nextChar)) {
      /* check for uppercase */
      if (ASCII.IsUpper(nextChar) == false) {
        possiblyResword = false;
      } /* end if */

      nextChar = infile.ConsumeChar();

      /* check for lowline in between two alpha-numeric characters */
      if ((nextChar == '_') && (ASCII.IsAlnum(infile.LA2Char()))) {
        nextChar = infile.ConsumeChar();
        possiblyResword = false;
      } /* end if */

    } /* end while */
  }
  else /* no lowline identifiers */ {

   /* get alpha-numeric identifier */
    while (ASCII.IsAlnum(nextChar)) {

      /* check for uppercase */
      if (ASCII.IsUpper(nextChar) == false) {
        possiblyResword = false;
      } /* end if */

      nextChar = infile.ConsumeChar();
    } /* end while */
  } /* end if */

  lookaheadSym.lexeme = infile.ReadMarkedLexeme();

  /* check for reserved word */
  if (possiblyResword) {
    intermediate = Terminals.TokenForResword(lookaheadSym.lexeme);

    if (intermediate == Token.Unknown) {
      token = Token.Identifier;
    }
    else {
      token = intermediate;
    } /* end if */
  }
  else {
    token = Token.Identifier;
  } /* end if */

  return nextChar;
} /* end GetIdentOrResword */


/* ---------------------------------------------------------------------------
 * private method GetStringLiteral()
 * ------------------------------------------------------------------------ */

private char GetStringLiteral (out Token token) {
  uint line, column;
  Token intermediate;
  char nextChar, delimiter;
  
  intermediate = Token.StringLiteral;
  
  /* consume opening delimiter */
  delimiter = infile.ReadChar();
  
  infile.MarkLexeme();
  nextChar = infile.NextChar();
  
  while (nextChar != delimiter) {
    
    /* check for control character */
    if (ASCII.IsCtrl(nextChar)) {
      line = infile.CurrentLine();
      column = infile.CurrentColumn();
      
      intermediate = Token.MalformedString;
      
      /* newline */
      if (nextChar == ASCII.LF) {
        // report error with offending position
        // newline in string literal
        break;
      }
      /* end-of-file marker */
      else if (infile.EOF()) {
        // report error with offending position
        // premature end of file within string literal
        break;
      }
      else /* any other control character */ {
        /* invalid input character */
        // report error with offending character
      } /* end if */
    } /* end if */
    
    if (Capabilities.EscapeTabAndNewline() &&
       (nextChar == ASCII.BACKSLASH)) {
      line = infile.CurrentLine();
      column = infile.CurrentColumn();
      nextChar = infile.ConsumeChar();
      
      if ((nextChar != 'n') && (nextChar != 't') &&
          (nextChar != ASCII.BACKSLASH)) {
        /* invalid escape sequence */
        // report error with offending character
      } /* end if */
    } /* end if */
    
    nextChar = infile.ConsumeChar();
  } /* end while */
  
  /* get lexeme */
  lookaheadSym.lexeme = infile.ReadMarkedLexeme();
  
  /* consume closing delimiter */
  if (nextChar == delimiter) {
    nextChar = infile.ConsumeChar();
  } /* end if */
  
  /* pass back token */
  token = intermediate;
  
  return nextChar;
} /* end GetStringLiteral */


/* ---------------------------------------------------------------------------
 * private method GetNumberLiteral()
 * ------------------------------------------------------------------------ */

private char GetNumberLiteral (out Token token) {
  if (Capabilities.PrefixLiterals()) {
    return GetPrefixedNumber(out token);
  }
  else {
    return GetSuffixedNumber(out token);
  } /* end if */
} /* end GetNumberLiteral */


/* ---------------------------------------------------------------------------
 * private method GetPrefixedNumber()
 * ------------------------------------------------------------------------ */

private char GetPrefixedNumber (out Token token) {
  Token intermediate;
  char nextChar, la2Char;

  infile.MarkLexeme();
  nextChar = infile.NextChar();
  la2Char = infile.LA2Char();

  if /* prefix for base-16 integer or character code found */
    ((nextChar == 0) && ((la2Char == 'x') || (la2Char == 'u'))) {

    /* consume '0' */
    nextChar = infile.ConsumeChar();
    
    if /* base-16 integer prefix */ (nextChar == 'x') {
      intermediate = Token.IntLiteral;
    }
    else /* character code prefix */ {
      intermediate = Token.CharLiteral;
    } /* end if */
   
    /* consume prefix */
    nextChar = infile.ConsumeChar();
    
    /* consume all digits */
    while (ASCII.IsDigit(nextChar) || ASCII.IsAtoF(nextChar)) {
      nextChar = infile.ConsumeChar();
    } /* end while */
  }
  else /* decimal integer or real number */ {
    
    /* consume all digits */
    while (ASCII.IsDigit(nextChar)) {
      nextChar = infile.ConsumeChar();
    } /* end while */
    
    if /* real number literal found */ 
      ((nextChar == '.') && (infile.LA2Char() != '.')) {
      
      nextChar = GetNumberLiteralFractionalPart(out intermediate);
    }
    else {
      intermediate = Token.IntLiteral;
    } /* end if */
  } /* end if */
  
  /* get lexeme */
  lookaheadSym.lexeme = infile.ReadMarkedLexeme();
  
  /* pass back token */
  token = intermediate;

  return nextChar;
} /* end GetPrefixedNumber */


/* ---------------------------------------------------------------------------
 * private method GetSuffixedNumber()
 * ------------------------------------------------------------------------ */

private char GetSuffixedNumber (out Token token) {
  Token intermediate;
  uint charCount0to7 = 0;
  uint charCount8to9 = 0;
  uint charCountAtoF = 0;
  char nextChar, lastChar;

  infile.MarkLexeme();
  lastChar = ASCII.NUL;
  nextChar = infile.NextChar();

  /* consume any characters '0' to '9' and 'A' to 'F' */
  while (ASCII.IsDigit(nextChar) || ASCII.IsAtoF(nextChar)) {
    
    if ((nextChar >= '0') && (nextChar <= '7')) {
      charCount0to7++;
    }
    else if ((nextChar == '8') || (nextChar == '9')) {
      charCount8to9++;
    }
    else {
      charCountAtoF++;
    } /* end if */
    
    lastChar = nextChar;
    nextChar = infile.ConsumeChar();
  } /* end while */

  if /* base-16 integer found */ (nextChar == 'H') {
    
    nextChar = infile.ConsumeChar();
    intermediate = Token.IntLiteral;
  }
  else if /* base-10 integer or real number found */
    (charCountAtoF == 0) {
    
    if /* real number literal found */ 
      ((nextChar == '.') && (infile.LA2Char() != '.')) {
      
      nextChar = GetNumberLiteralFractionalPart(out intermediate);
    }
    else /* decimal integer found */ {
      intermediate = Token.IntLiteral;
    } /* end if */
  }
  else if /* base-8 integer found */
    (CompilerOptions.OctalLiterals() &&
     (charCount8to9 == 0) && (charCountAtoF == 1) && 
     ((lastChar == 'B') || (lastChar == 'C'))) {
    
    if (lastChar == 'B') {
      intermediate = Token.IntLiteral;
    }
    else /* last_char == 'C' */ {
      intermediate = Token.CharLiteral;
    } /* end if */    
  }
  else /* malformed base-16 integer */ {
    intermediate = Token.MalformedInteger;
  } /* end if */

  lookaheadSym.lexeme = infile.ReadMarkedLexeme();

  token = intermediate;

  return nextChar;
} /* end GetSuffixedNumber */


/* ---------------------------------------------------------------------------
 * private method GetNumberLiteralFractionalPart()
 * ------------------------------------------------------------------------ */

private char GetNumberLiteralFractionalPart (out Token token) {
  Token intermediate;
  char nextChar;

  intermediate = Token.RealLiteral;

  /* consume the decimal point */
  nextChar = infile.ConsumeChar();

  /* consume any fractional digits */
  while (ASCII.IsDigit(nextChar)) {
    nextChar = infile.ConsumeChar();
  } /* end if */
  
  if /* exponent prefix found */ (nextChar == 'E') {
  
    /* consume exponent prefix */
    nextChar = infile.ConsumeChar();
    
    if /* exponent sign found*/
      ((nextChar == '+') || (nextChar == '-')) {
      
      /* consume exponent sign */
      nextChar = infile.ConsumeChar();
    } /* end if */
    
    if /* exponent digits found */ (ASCII.IsDigit(nextChar)) {
    
      /* consume exponent digits */
      while (ASCII.IsDigit(nextChar)) {
        nextChar = infile.ConsumeChar();
      } /* end while */
    }
    else /* exponent digits missing */ {
      intermediate = Token.MalformedReal;
    } /* end if */
  } /* end if */

  token = intermediate;

  return nextChar;
} /* end GetNumberLiteralFractionalPart */


} /* Lexer */


} /* namespace */

/* END OF FILE */