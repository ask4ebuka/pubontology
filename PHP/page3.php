<html>
<body>
<form method= "get" action = "page3.php">
<input type ="textbox" name="s_box"></input>
<input type ="submit" name= "Search"></input>
</form>
<?php
require_once( "sparqllib.php" );
$localhost_port="3030";
$dataset_name ="one";
if (isset($_GET['s_box'])){
$game = $_GET['s_box'];


include ('SearchQuery.php');
$data = sparql_get( "http://localhost:".$localhost_port."/".$dataset_name, $query);
if( isset($data)) {
 print "<table class='example_table' border='2'><tr>";
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
}
print "</table>";
}
else{echo ("Values not set ".$localhost_port.$dataset_name.$query);}
}else{echo("Please enter data in textbox"); }
?>
</body>
</html>