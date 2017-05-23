MODULE EmptyStmtSeq;

PROCEDURE Foo ( bar : Bar );
BEGIN
  (* empty statement sequence *)
END Foo;

BEGIN
  WITH foo DO (* empty statement sequence *) END;
  
  IF foo THEN (* empty statement sequence *) END;
  
  IF foo THEN bar ELSIF baz THEN (* empty statement sequence *) END;
  
  IF foo THEN bar ELSE (* empty statement sequence *) END;
  
  CASE foo OF
    bar : (* empty statement sequence *)
  | baz : (* empty statement sequence *)
  ELSE
    (* empty statement sequence *)
  END;
  
  LOOP (* empty statement sequence *) END;
  
  WHILE foo DO (* empty statement sequence *) END;
    
  REPEAT (* empty statement sequence *) UNTIL foo;
  
  FOR i := 0 TO 99 DO (* empty statement sequence *) END
  
END EmptyStmtSeq.
