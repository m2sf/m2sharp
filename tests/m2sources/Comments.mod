MODULE Comments; (* M2C version *)

! Single line comment

! Single line comment with ->	<-tab

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
