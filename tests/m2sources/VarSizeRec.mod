MODULE VarSizeRec;

TYPE VLA = VAR RECORD
  size : CARDINAL;
  foo : INTEGER;
  bar : REAL
IN
  buffer : ARRAY size OF CHAR
END;

PROCEDURE InitVLA ( VAR r : VLA );
VAR
  index : CARDINAL;
BEGIN
  IF r = NIL THEN RETURN END;
  
  r^.foo := 0;
  r^.bar := 0.0;
  
  FOR i := 0 TO r^.size - 1 DO
    r^.buffer[index] := 0
  END;
  
  RETURN
END InitVLA;

VAR r : VLA;

BEGIN
  NEW(r, 100);
  InitVLA(r)
END VarSizeRec.
