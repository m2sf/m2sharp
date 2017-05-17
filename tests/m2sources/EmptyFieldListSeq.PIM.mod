MODULE EmptyFieldListSeq; (* PIM version *)

(* Ordinary Record Type *)
TYPE R = RECORD (* empty field list sequence *) END;

(* Variant Record Type *)
TYPE R = RECORD
  CASE foo : Foo OF
    bar : (* empty field list sequence *)
  | baz : (* empty field list sequence *)
  ELSE
    (* empty field list sequence *)
  END
END;

END EmptyFieldListSeq.
