<?php 
	include("connect.php");		
	
	$email = $_GET['email'];
	
	$p1 = $_GET['p1'];
	$p2 = $_GET['p2']; 
	$p3 = $_GET['p3'];
	$p4 = $_GET['p4'];
	$p5 = $_GET['p5'];
	$p6 = $_GET['p6'];
	$p7 = $_GET['p7'];
	$p8 = $_GET['p8'];
	$p9 = $_GET['p9'];
	$p10 = $_GET['p10'];
	$p11 = $_GET['p11'];
	$p12 = $_GET['p12'];
	$p13 = $_GET['p13'];
	$p14 = $_GET['p14'];
	$p15 = $_GET['p15'];
	$p16 = $_GET['p16'];
	$p17 = $_GET['p17'];
	$p18 = $_GET['p18'];
	$p19 = $_GET['p19'];
	
	$a1 = $_GET['a1'];
	$a2 = $_GET['a2'];
	$a3 = $_GET['a3'];
	$a4 = $_GET['a4'];
	$a5 = $_GET['a5'];
	$a6 = $_GET['a6'];
	$a7 = $_GET['a7'];
	
	$g1 = $_GET['g1'];
	$g2 = $_GET['g2'];
	$g3 = $_GET['g3'];
	$g4 = $_GET['g4'];
	$g5 = $_GET['g5'];
	$g6 = $_GET['g6'];
	
	$distance = $_GET['di'];
	$island_active = $_GET['is'];
	$mission_active = $_GET['mi'];
	$sex = $_GET['se'];
	$clothes = $_GET['cl'];
	$legs = $_GET['le'];
	$shoes = $_GET['sh'];
	$skin = $_GET['sk'];
	$hairs = $_GET['ha'];

	$hash = $_GET['hash'];
	
	$realHash = md5($email . $secretKey);
	
	//echo $realHash;
	//echo "   ";
	//echo $hash;
	
	
	
	if($realHash == $hash) { 
	
		$data = "UPDATE `users` SET 
		`progressIsland_1` =  '$p1',
		`progressIsland_2` =  '$p2',
		`progressIsland_3` =  '$p3',
		`progressIsland_4` =  '$p4',
		`progressIsland_5` =  '$p5',
		`progressIsland_6` =  '$p6',
		`progressIsland_7` =  '$p7',
		`progressIsland_8` =  '$p8',
		`progressIsland_9` =  '$p9',
		`progressIsland_10` =  '$p10',
		`progressIsland_11` =  '$p11',
		`progressIsland_12` =  '$p12',
		`progressIsland_13` =  '$p13',
		`progressIsland_14` =  '$p14',
		`progressIsland_15` =  '$p15',
		`progressIsland_16` =  '$p16',
		`progressIsland_17` =  '$p17',
		`progressIsland_18` =  '$p18',
		`progressIsland_19` =  '$p19',
		
		`a1` =  '$a1',
		`a2` =  '$a2',
		`a3` =  '$a3',
		`a4` =  '$a4',
		`a5` =  '$a5',
		`a6` =  '$a6',
		`a7` =  '$a7',
		`g1` =  '$g1',
		`g2` =  '$g2',
		`g3` =  '$g3',
		`g4` =  '$g4',
		`g5` =  '$g5',
		`g6` =  '$g6',
		
		`distance` =  '$distance',
		`island_active` =  '$island_active',
		`mission_active` =  '$mission_active',
		`sex` =  '$sex',
		`clothes` =  '$clothes',
		`legs` =  '$legs',
		`shoes` =  '$shoes',
		`skin` =  '$skin',
		`hairs` =  '$hairs'
		
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