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
 * PlatformInfo.cs
 *
 * platform information
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
using Mono.Unix.Native;

namespace org.m2sf.m2sharp {


/* ---------------------------------------------------------------------------
 * singleton class PlatformInfo
 * ---------------------------------------------------------------------------
 * All methods are static. All methods return singleton values.
 * ------------------------------------------------------------------------ */

public sealed class PlatformInfo : IPlatformInfo {

/* ---------------------------------------------------------------------------
 * private class variable initialized
 * ---------------------------------------------------------------------------
 * Set to true if class variables have been initialised, otherwise false.
 * ------------------------------------------------------------------------ */
  
  private static bool initialized = false;


/* ---------------------------------------------------------------------------
 * private class variable name
 * ---------------------------------------------------------------------------
 * Holds the human readable name of the current operating system.
 * ------------------------------------------------------------------------ */

  private static string name;


/* ---------------------------------------------------------------------------
 * private class variable uname
 * ---------------------------------------------------------------------------
 * Holds the human readable name of the current Unix kernel.
 * The name will be the empty string on non-Unix operating systems.
 * ------------------------------------------------------------------------ */

  private static string uname;


/* ---------------------------------------------------------------------------
 * private class variable type
 * ---------------------------------------------------------------------------
 * Holds the enumerated value of the current operating system.
 * ------------------------------------------------------------------------ */

  private static PlatformOSType type = PlatformOSType.Unsupported;


/* ---------------------------------------------------------------------------
 * private class variable vmajor
 * ---------------------------------------------------------------------------
 * Holds the major version of the current operating system.
 * ------------------------------------------------------------------------ */

  private static int vmajor;


/* ---------------------------------------------------------------------------
 * private class variable vminor
 * ---------------------------------------------------------------------------
 * Holds the minor version of the current operating system.
 * ------------------------------------------------------------------------ */

  private static int vminor;


/* ---------------------------------------------------------------------------
 * private class variable build
 * ---------------------------------------------------------------------------
 * Holds the build number of the current operating system.
 * ------------------------------------------------------------------------ */

  private static int build;


/* ---------------------------------------------------------------------------
 * private constructor PlatformInfo()
 * ---------------------------------------------------------------------------
 * Prevents clients from invoking the constructor.
 * ------------------------------------------------------------------------ */

  private PlatformInfo() {
   // no operation
  } /* end PlatformInfo */


/* ---------------------------------------------------------------------------
 * private initialiser Init()
 * ---------------------------------------------------------------------------
 * Initialises all class variables from the current environment.
 * ------------------------------------------------------------------------ */

  private static void Init () {
    if (initialized) {
      return;
    } /* end if */
    
    /* obtain platform ID */
    OperatingSystem os = Environment.OSVersion;
    switch (os.Platform) {
      case PlatformID.MacOSX :
        name = PlatformOSName.MacOSX;
        type = PlatformOSType.MacOSX;
        break;
      case PlatformID.Unix :
        name = PlatformOSName.Posix;
        type = PlatformOSType.Posix;
        break;
      case PlatformID.Win32NT :
        name = PlatformOSName.Windows;
        type = PlatformOSType.Windows;
        break;
      default :
        name = PlatformOSName.Unsupported;
        type = PlatformOSType.Unsupported;
        break;
    } /* end switch */
    
    /* obtain uname on Unix platforms */
    if ((os.Platform == PlatformID.MacOSX) ||
        (os.Platform == PlatformID.Unix)) {
      Utsname uts;
      if (Syscall.uname(out uts) == 0) {
        /* $ uname -s */
        uname = uts.sysname;
      }
      else /* uname call failed */ {
        uname = "";
      } /* end if */
    }
    else /* not a Unix platform */ {
      uname = "";
    } /* end if */
    
    /* fix incorrect result of Environment.OSVersion for MacOS X */ 
    if (string.Compare(uname, "darwin", true) == 0) {
      name = PlatformOSName.MacOSX;
      type = PlatformOSType.MacOSX;
    } /* end if */
    
    /* obtain version */
    Version version = os.Version;
    vmajor = version.Major;
    vminor = version.Minor;
    build = version.Build;
    
    /* remember initialisation */
    initialized = true;

  } /* end Init */


/* ---------------------------------------------------------------------------
 * method Name()
 * ---------------------------------------------------------------------------
 * Returns the human readable name of the current operating system.
 * ------------------------------------------------------------------------ */

  public static string Name () {
    if (initialized == false) {
      PlatformInfo.Init();
    } /* end if */
    return name;
  } /* end Name */
  

/* ---------------------------------------------------------------------------
 * method Uname()
 * ---------------------------------------------------------------------------
 * Returns the human readable name of the current Unix kernel.
 * Returns an empty string on non-Unix operating systems.
 * ------------------------------------------------------------------------ */

  public static string Uname () {
    if (initialized == false) {
      PlatformInfo.Init();
    } /* end if */
    return uname;
  } /* end Uname */


/* ---------------------------------------------------------------------------
 * method OSType()
 * ---------------------------------------------------------------------------
 * Returns an enumerated value indicating the current operating system.
 * ------------------------------------------------------------------------ */
 
 public static PlatformOSType OSType () {
    if (initialized == false) {
      PlatformInfo.Init();
    } /* end if */
    return type;
  } /* end OSType */
  

/* ---------------------------------------------------------------------------
 * method VersionMajor()
 * ---------------------------------------------------------------------------
 * Returns the major version of the current operating system.
 * ------------------------------------------------------------------------ */

  public static int VersionMajor () {
    if (initialized == false) {
      PlatformInfo.Init();
    } /* end if */
    return vmajor;
  } /* end VersionMajor */


/* ---------------------------------------------------------------------------
 * method VersionMinor()
 * ---------------------------------------------------------------------------
 * Returns the minor version of the current operating system.
 * ------------------------------------------------------------------------ */

  public static int VersionMinor () {
    if (initialized == false) {
      PlatformInfo.Init();
    } /* end if */
    return vminor;
  } /* end VersionMinor */


/* ---------------------------------------------------------------------------
 * method Build()
 * ---------------------------------------------------------------------------
 * Returns the build number of the current operating system.
 * ------------------------------------------------------------------------ */

  public static int Build () {
    if (initialized == false) {
      PlatformInfo.Init();
    } /* end if */
    return build;
  } /* end Build */


/* ---------------------------------------------------------------------------
 * method IsSupported()
 * ---------------------------------------------------------------------------
 * Returns true if the current operating system is supported, else false.
 * ------------------------------------------------------------------------ */

  public static bool IsSupported () {
    if (initialized == false) {
      PlatformInfo.Init();
    } /* end if */
    return (type != PlatformOSType.Unsupported);
  } /* end IsSupported */


/* ---------------------------------------------------------------------------
 * method IsUnsupported()
 * ---------------------------------------------------------------------------
 * Returns true if the current operating system is unsupported, else false.
 * ------------------------------------------------------------------------ */

  public static bool IsUnsupported () {
    if (initialized == false) {
      PlatformInfo.Init();
    } /* end if */
    return (type == PlatformOSType.Unsupported);
  } /* end IsSupported */

} /* PlatformInfo */
} /* namespace */

/* END OF FILE */
