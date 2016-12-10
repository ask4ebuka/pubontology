<?php
require_once( "sparqllib.php" );
if (isset($sub)&& isset($pred)&& isset($obj) ){
$subject = $sub;
$predicate = $pred;
$object =$obj;
}
if (isset($cn)&& isset($prop)){
$className =$cn;
$property= $prop;
}

if (isset($_GET['s_box'])){
$game = $_GET['s_box'];

}

if (isset($port)&&isset($ds)){
$localhost_port = $port;
$dataset_name = $ds;

//echo ($localhost_port);
//echo($ds);
//echo($class_name); 
if(isset($game))
{
include ('SearchQuery.php');
}
elseif (!isset($className))
{
include ('query.php');
}
else
{
include ('query2.php');

}
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
}}
print "</table>";
}
else{echo ("Values not set");}
?>
 