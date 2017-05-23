MODULE Comments; (* PIM version *)

(* Block comment with line feeds
   comment line 2
   comment line 3 *)

(* Block comment with ->	<-tab *)

BEGIN
(*
  (* WriteString("*)");
  (* WriteString('*)');
*)

(* disabling a code section *)
?<
  WriteString("*)");
  WriteString('*)');
>?
END Comments.
