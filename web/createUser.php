<?php 
	include("connect.php");
	
	$username = $_GET['username'];	
	$hash = $_GET['hash']; 
	$email = $_GET['email']; 
	$password = $_GET['password']; 
	
	$realHash = md5($username . $email . $password . $secretKey); 
	if($realHash == $hash) { 
		$sth = $dbh->prepare("INSERT INTO  `users` 
								(`username` ,`email`, `password`)
								 VALUES 
								('$username',  '$email', '$password')");
		try {
			$sth->execute($_GET);
			$lastId = $dbh->lastInsertId();
			echo $lastId;			
		} catch(Exception $e) {
			echo 'error';
		}
	} 
?>