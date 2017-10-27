<?php 
        include("connect.php");
 
        $email = $_GET['email'];
	
		$sth = $dbh->query("SELECT * FROM users WHERE `email` = '$email'");
        $sth->setFetchMode(PDO::FETCH_ASSOC);
 
		$result = $sth->fetchAll();
		if(count($result) > 0) {
			foreach($result as $r) {
				echo ":" . $r['id'] . ":" . 
				$r['username'] . ":"  . 
				$r['password'] . ":" . 
				$r['email'] . ":" . 
				$r['achievements']. ":" . 
				$r['distance']. ":" . 
				$r['island_active']. ":" . 
				$r['mission_active']. ":" . 
				$r['sex']. ":" . 
				$r['clothes']. ":" . 
				$r['legs']. ":" . 
				$r['shoes']. ":" . 
				$r['skin']. ":" . 
				$r['hairs']. ":" . 
				
				$r['progressIsland_1']. ":" . 
				$r['progressIsland_2']. ":" . 
				$r['progressIsland_3']. ":" . 
				$r['progressIsland_4']. ":" . 
				$r['progressIsland_5']. ":" . 
				$r['progressIsland_6']. ":" . 
				$r['progressIsland_7']. ":" . 
				$r['progressIsland_8']. ":" . 
				$r['progressIsland_9']. ":" . 
				$r['progressIsland_10']. ":" . 
				$r['progressIsland_11']. ":" . 
				$r['progressIsland_12']. ":" . 
				$r['progressIsland_13']. ":" . 
				$r['progressIsland_14']. ":" . 
				$r['progressIsland_15']. ":" . 
				$r['progressIsland_16']. ":" . 
				$r['progressIsland_17']. ":" . 
				$r['progressIsland_18']. ":" . 
				$r['progressIsland_19']. ":" . 
				
				$r['a1']. ":" . 
				$r['a2']. ":" . 
				$r['a3']. ":" . 
				$r['a4']. ":" . 
				$r['a5']. ":" . 
				$r['a6']. ":" . 
				$r['a7']. ":" . 
				
				$r['g1']. ":" . 
				$r['g2']. ":" . 
				$r['g3']. ":" . 
				$r['g4']. ":" . 
				$r['g5']. ":" . 
				$r['g6'];
			}
		}
		
?>