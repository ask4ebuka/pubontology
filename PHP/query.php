

<?php

$query ='
PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
PREFIX owl: <http://www.w3.org/2002/07/owl#>
PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
PREFIX vg: <http://www.videogame.com/game#>
SELECT ?subject ?object ?object
WHERE {
 ?subject ?predicate ?object
  
}
LIMIT 25';
?>
