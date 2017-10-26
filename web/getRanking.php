<?php
	include("connect.php");
 
    $sth = $dbh->query('SELECT * FROM users ORDER BY achievements DESC LIMIT 99');

    $sth->setFetchMode(PDO::FETCH_ASSOC);
 
    $result = $sth->fetchAll();
 
    if(count($result) > 0) {
        foreach($result as $r) {
            echo $r['id'] . ":" . $r['username'] .  ":" .  $r['achievements'] . "</n>";
        }
    }
?>