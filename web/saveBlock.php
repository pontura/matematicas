<?php 
	include("connect.php");
	
	$userID = $_GET['userID'];	
	$title = $_GET['title']; 
	$content = $_GET['content']; 
	$hash = $_GET['hash']; 
	
	
	$realHash = md5($userID . $title . $content . $secretKey); 
	
	echo ($realHash . " " .  $hash);
	
	if($realHash == $hash) { 
		$sth = $dbh->prepare("INSERT INTO  `block` 
								(`userID` ,`title`, `content`)
								 VALUES 
								('$userID',  '$title', '$content')");
		try {
			$sth->execute($_GET);
			//$lastId = $dbh->lastInsertId();
			//echo $lastId;		
			echo "OK";			
		} catch(Exception $e) {
			echo 'error';
		}
	} 
?>