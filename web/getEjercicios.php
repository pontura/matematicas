<?php 
        include("connect.php");
 
        $userID = $_GET['userID'];
	
		$sth = $dbh->query("SELECT * FROM block WHERE `userID` = '$userID'");
		
        $sth->setFetchMode(PDO::FETCH_ASSOC);
 
		$result = $sth->fetchAll();
		if(count($result) > 0) {
			foreach($result as $r) {
				echo $r['title'] . ":"  . $r['content'] . "</n>";
			}
		}
		
?><key>CFBundleURLTypes</key>
<array>
  <dict>
  <key>CFBundleURLSchemes</key>
  <array>
    <string>fb1761306117446766</string>
  </array>
  </dict>
</array>
<key>FacebookAppID</key>
<string>1761306117446766</string>
<key>FacebookDisplayName</key>
<string>Combate Space</string>