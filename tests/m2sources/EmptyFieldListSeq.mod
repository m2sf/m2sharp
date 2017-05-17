MODULE EmptyFieldListSeq; (* M2C version *)

(* Ordinary Record Type *)
TYPE R = RECORD (* empty field list sequence *) END;

(* Extensible Record Type *)
TYPE R = RECORD ( NIL )
  (* empty field list sequence *)
END;

(* Variable Size Record Type *)
TYPE VLA = VAR RECORD
  (* empty field list sequence *)
IN
  (* empty field list sequence *)
END;

END EmptyFieldListSeq.
