SELECT C.Nombre, B.Nombre, A.Nombre FROM Temario a
inner join Modulos b on b.IDModulo = a.IDModulo
inner join Cursos  c on b.IDCurso = c.IDCurso
 
