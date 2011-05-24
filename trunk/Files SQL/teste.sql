
/*seleccionar todas as caracteristicas*/
SELECT * FROM caracteristics;

SELECT id_software 
	FROM software_list, caracteristics
	WHERE caracteristics.caracteristics_id = 1
	AND software_list.caracteristics_id = caracteristics.caracteristics_id;