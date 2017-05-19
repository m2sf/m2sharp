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
 * NonTerminals.cs
 * 
 * provides FIRST() and FOLLOW() sets for each non-terminal symbol //SAM CHANGE
 * used by the parser class for syntax analysis
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

    using System;
    using System.Collections.Generic;

public class NonTerminals : INonTerminals {

    public static Production firstConstParamDependent = Production.FormalType,
                             lastConstParamDependent = Production.AttribFormalParams,
                             firstNoVariantRecDependent = Production.TypeDeclarationTail,
                             lastNoVariantRecDependent = Production.TypeDeclarationTail,
                             firstOptionDependent = firstConstParamDependent,
                             lastOptionDependent = lastNoVariantRecDependent;
    public static uint alternateSetOffset = (uint)lastOptionDependent - (uint)firstOptionDependent + 1;               
    
    TokenSet[] followSet = new TokenSet[Count()];
    TokenSet[] firstSet = new TokenSet[Count()];

    /* --------------------------------------------------------------------------
     * method Count() -- Returns the number of productions
     * ----------------------------------------------------------------------- */ //SAM CHANGE

    static uint Count() {
        return (uint)Enum.GetNames(typeof(Production)).Length;
    } /* end Count */


    /* --------------------------------------------------------------------------
     * method IsOptionDependent(p)
     * --------------------------------------------------------------------------
     * Returns true if p is dependent on any compiler option, else false.
     * ----------------------------------------------------------------------- */ //SAM CHANGE

    bool IsOptionDependent(Production p) {
        return p >= firstOptionDependent;
    } /* end IsOptionDependent */


    /* --------------------------------------------------------------------------
     * method IsConstParamDependent(p)
     * --------------------------------------------------------------------------
     * Returns true if p is dependent on CONST parameter option, else false.
     * ----------------------------------------------------------------------- */ //SAM CHANGE

    bool IsConstParamDependent(Production p)
    {
        return p >= firstConstParamDependent && p <= lastConstParamDependent;
    } /* end IsConstParamDependent */


    /* --------------------------------------------------------------------------
     * method IsVariantRecordDependent(p)
     * --------------------------------------------------------------------------
     * Returns true if p is dependent on variant record type option, else false.
     * ----------------------------------------------------------------------- */ //SAM CHANGE

    bool IsVariantRecordDependent(Production p) {
        return p >= firstNoVariantRecDependent && p <= lastNoVariantRecDependent;
    }

    /* --------------------------------------------------------------------------
     * method FIRST(p)
     * --------------------------------------------------------------------------
     * Returns a tokenset with the FIRST set of production p.
     * ----------------------------------------------------------------------- */

    TokenSet FIRST(Production p) {
        TokenSet tokenset = null;
        uint index = 0;

        if (IsConstParamDependent(p))
        {
            index = Convert.ToUInt32(p) + alternateSetOffset;
        } /* end if */
        if (IsVariantRecordDependent(p) && CompilerOptions.VariantRecords())
        {
            index = Convert.ToUInt32(p) + alternateSetOffset;
        } /* end if */

        tokenset = firstSet[index];

        return tokenset;
    } /* end FIRST */


    /* --------------------------------------------------------------------------
     * method FOLLOW(p)
     * --------------------------------------------------------------------------
     * Returns a tokenset with the FOLLOW set of production p.
     * ----------------------------------------------------------------------- */

    TokenSet FOLLOW(Production p) {
        TokenSet tokenset = null;
        uint index = 0;

        if (IsConstParamDependent(p)) {
            index = Convert.ToUInt32(p) + alternateSetOffset;
        } /* end if */
        if (IsVariantRecordDependent(p) && !CompilerOptions.VariantRecords()) {
            index = Convert.ToUInt32(p) + alternateSetOffset;
        } /* end if */

        tokenset = followSet[index];

        return tokenset;
    } /* end FOLLOW */


    /* --------------------------------------------------------------------------
     * method NameForProduction(p)
     * --------------------------------------------------------------------------
     * Returns a string with a human readable name for production p.
     * ----------------------------------------------------------------------- */

    string NameForProduction(Production p);



} /* NonTerminals */

} /* namespace */