
<html>

<body>
<?php
require_once( "sparqllib.php" );
$query ='
 PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
PREFIX owl: <http://www.w3.org/2002/07/owl#>
PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
SELECT ?subject ?predicate ?object
WHERE {
 ?subject ?predicate ?object
  
}
LIMIT 25';
$data = sparql_get( "http://localhost:3030/one", $query);
if( isset($data)) {
 print "<table class='example_table'><tr>";
 foreach( $data->fields() as $field ) {
print "<th>$field</th>";
 }
 print "</tr>";
 foreach( $data as $row ) {
print "<tr>";
foreach( $data->fields() as $field ) {
print "<td>$row[$field]</td>";
}
print "</tr>";
}}
print "</table>";
?>
</body>
</html>    