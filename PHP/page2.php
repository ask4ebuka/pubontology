
<html>

<body>
<?php
require_once( "sparqllib.php" );
 
$db = sparql_connect( "http://localhost:3030" );
if( !$db ) { print $db->errno() . ": " . $db->error(). "\n"; exit; }
$db->ns( "one","http://localhost:3030/dataset.html?tab=query&ds=/one" );
 
$sparql = "SELECT ?subject ?predicate ?object WHERE { ?subject ?predicate ?object  } LIMIT 5";
$result = $db->query( $sparql ); 
if( !$result ) { print $db->errno() . ": " . $db->error(). "\n"; exit; }
 
$fields = $result->field_array( $result );
 
print "<p>Number of rows: ".$result->num_rows( $result )." results.</p>";
print "<table class='example_table'>";
print "<tr>";
foreach( $fields as $field )
{
	print "<th>$field</th>";
}
print "</tr>";
while( $row = $result->fetch_array() )
{
	print "<tr>";
	foreach( $fields as $field )
	{
		print "<td>$row[$field]</td>";
	}
	print "</tr>";
}
print "</table>";
?>
</body>
</html>



    