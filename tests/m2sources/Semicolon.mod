MODULE Semicolon; (* Extended version *)

(* Ordinary Record Type *)
TYPE R = RECORD i : INTEGER; (* errant semicolon *) END;

(* Extensible Record Type *)
TYPE R = RECORD ( NIL )
  i : INTEGER; (* errant semicolon *)
END;

(* Variable Size Record Type *)
TYPE VLA = VAR RECORD
  size : CARDINAL; (* errant semicolon *)
IN
  buffer : ARRAY size OF CHAR; (* errant semicolon *)
END;

(* Formal Parameter List *)
PROCEDURE Foo ( bar : Bar; baz : Baz; (* errant semicolon *) );
BEGIN
  Barbaz; (* errant semicolon *)
END Foo;

(* Statement Sequence *)
BEGIN
  WITH foo DO bar; (* errant semicolon *) END;
  
  IF foo THEN bar; (* errant semicolon *) END;
  
  IF foo THEN bar ELSIF baz THEN bam; (* errant semicolon *) END;
  
  IF foo THEN bar ELSE baz; (* errant semicolon *) END;
  
  CASE foo OF
  | bar : bam; (* errant semicolon *)
  | baz : boo; (* errant semicolon *)
  ELSE
    dodo; (* errant semicolon *)
  END;
  
  LOOP bar; (* errant semicolon *) END;
  
  WHILE foo DO bar; (* errant semicolon *) END;
    
  REPEAT bar; (* errant semicolon *) UNTIL foo;
  
  FOR i := 0 TO 99 DO bar; (* errant semicolon *) END;
  
  Foobar; Bazbam; (* errant semicolon *)
  
END Semicolon.
