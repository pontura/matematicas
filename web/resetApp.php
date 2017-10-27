<?php 
	include("connect.php");
	
	$email = $_GET['email'];	
	$hash = $_GET['hash']; 
	
	
	$realHash = md5($email . $secretKey); 
	
	//echo ($realHash . " " .  $hash);
	
	if($realHash == $hash) { 
		$data = "UPDATE `users` SET 
		`achievements` =  '0',
		`progressIsland_1` =  '0',
		`progressIsland_2` =  '0',
		`progressIsland_3` = '0',
		`progressIsland_4` = '0',
		`progressIsland_5` =  '0',
		`progressIsland_6` =  '0',
		`progressIsland_7` =  '0',
		`progressIsland_8` =  '0',
		`progressIsland_9` =  '0',
		`progressIsland_10` =  '0',
		`progressIsland_11` =  '0',
		`progressIsland_12` = '0',
		`progressIsland_13` =  '0',
		`progressIsland_14` = '0',
		`progressIsland_15` =  '0',
		`progressIsland_16` =  '0',
		`progressIsland_17` =  '0',
		`progressIsland_18` =  '0',
		`progressIsland_19` =  '0',
		
		`a1` =  '0',
		`a2` =  '0',
		`a3` =  '0',
		`a4` =  '0',
		`a5` =  '0',
		`a6` = '0',
		`a7` =  '0',
		`g1` =  '0',
		`g2` =  '0',
		`g3` =  '0',
		`g4` =  '0',
		`g5` =  '0',
		`g6` =  '0',
		
		`distance` =  '0',
		`island_active` =  '0',
		`mission_active` =  '0',
		`sex` =  '0',
		`clothes` =  '0',
		`legs` =  '0',
		`shoes` =  '0',
		`skin` =  '0',
		`hairs` =  '0'
		
		WHERE `email` = '$email' ";
		
		echo $data;
		
		$sth = $dbh->prepare($data);
			
		try {
			$sth->execute($_GET);
			echo "si";
		} catch(Exception $e) {
			echo 'error';
		}
	} 
?>