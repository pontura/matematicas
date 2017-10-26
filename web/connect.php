<?php 
        //$hostname = 'mysql.hostinger.com.ar';
        //$username = 'u662729789_pont';
        //$password = 'ranlogic2008';
        //$database = 'u662729789_mat';
 
		$hostname = 'localhost';
        $username = 'chacmool';
        $password = '5e7b2404';
        $database = 'chacmool';
		
        $secretKey = "mySecretKey"; 
 
        try {
            $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
        } catch(PDOException $e) {
            echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
        }
		
?>

