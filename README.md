## M2Sharp — A CLR hosted Modula-2 to C# Translator ##
Welcome to the M2Sharp Modula-2 to C# Translator and Compiler Project


### Objective ###

The objective of this project is to develop a CLR hosted Modula-2 to C# translator
and via-C# compiler that generates CLR executable code.

In translator mode, M2Sharp translates Modula-2 source to C# source files. In compiler
mode, M2Sharp compiles Modula-2 source via C# source files to object code or executables
using the host system's C# compiler.


### Language ###

M2Sharp supports the bootstrap kernel (BSK) subset of Modula-2 R10 (M2R10).

An online version of the language specification is here:

https://github.com/m2sf/m2bsk/wiki/Language-Specification

The authoritative language specification (PDF) is available for download:

https://github.com/m2sf/PDFs/blob/master/M2BSK%20Language%20Description.pdf

**M2C does not support the earlier PIM or ISO dialects.**


### Grammar ###

The grammar of M2C's command line interface is in the project repository

https://github.com/m2sf/m2c/blob/main/grammar/cli-grammar.gll

The grammar of Modula-2 R10 is in the project repository

https://github.com/m2sf/m2c/blob/main/grammar/m2c-grammar.gll

For a graphical representation of the grammar, see section
[Syntax Diagrams](https://github.com/m2sf/m2bsk/wiki/Language-Specification-(D)-:-Syntax-Diagrams).


### Targets ###

M2Sharp will generate C# sources compileable with any C# compiler.

**There are no dependencies on any third party libraries.**


### OS support ###

M2Sharp will compile and run on any target system with a CLR execution environment.


### Development Languages ###

* M2Sharp itself is written in C#.
* The syntax diagram generator script is written in TCL/TK (not required to build M2Sharp)
* Build configuration scripts are written in the prevalent shell language of the hosting platform


### Project Wiki ###

For more details please visit the project wiki at the URL:
https://github.com/m2sf/m2sharp/wiki


### Contact ###

If you have questions or would like to contribute to the project, get in touch via

* [Modula2 Telegram group](https://t.me/+hTKSWC2mWoM1OGVl) chat

* [email](mailto:REMOVE+REVERSE.com.gmail@trijezdci) to the project maintainer

+++
